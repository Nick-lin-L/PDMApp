using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDMApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using PDMApp.Configurations;
using Microsoft.AspNetCore.Http;
using PDMApp.Service;
using Microsoft.Extensions.FileProviders;
using System.IO;
using PDMApp.Utils.BasicProgram;
using Microsoft.AspNetCore.Routing;
using System.Reflection;
using PDMApp.Middleware;
using System.IdentityModel.Tokens.Jwt;
using PDMApp.Service.Basic;

namespace PDMApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<pcms_pdm_testContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("PDMConnection")));
            // 原生swagger文件配置
            //services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "PDMApp", Version = "v1" }); });
            services.AddScoped<PdmUsersRepository>(); // 註冊 UserRepository
            // NSwag OpenAPI文件配置
            services.AddOpenApiDocument(config =>
            {
                config.Title = "PDMApp";
                config.Version = "v1";
                config.Description = "PDMApp API 文件 (自動生成)";

            });
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.EnableDebugMode = true; // ?示完整 SQL ??
                options.TrackConnectionOpenClose = false;
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
                // options.Storage = new oidcDemo.Model.PostgreSqlStorage(connectionString, "miniprofiler", "miniprofiler_timings", "miniprofiler_client_timings");
            }).AddEntityFramework();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("https://pcms-mif-test01.pouchen.com", "http://localhost:*") // 指定前端來源
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials() // 如果有 Cookie 或憑證請求，這是必需的
                           .WithExposedHeaders("Message", "FileName"); // 如果又加了新Heads，這邊還要加上前端才能看到
                });
            });
            AddScopedServices(services);
            //services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICurrentUserPermissionService, CurrentUserPermissionService>();
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    // 收集錯誤信息
                    var errors = context.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault()
                        );

                    // 將錯誤信息存儲在 HttpContext.Items 中
                    context.HttpContext.Items["ModelValidationErrors"] = errors;

                    // 返回空結果，讓中間件處理響應
                    return new EmptyResult();
                };
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.Converters.Add(new Utils.Converters.DecimalJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new Utils.Converters.StringJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new Utils.Converters.IntJsonConverter());
            });
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true; // 讓 API URL 變成小寫
            });
            //services.AddAuthorization(); // 啟用授權
            services.AddControllersWithViews();
            // 添加記憶體快取
            services.AddMemoryCache();
            // 添加 HttpClient 工廠
            services.AddHttpClient("SSOValidation", client =>
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                // 可以在這裡配置其他 HttpClient 的預設值
            });
            /*
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

          .AddJwtBearer(options =>
          {
              options.Events = new JwtBearerEvents
              {
                  OnMessageReceived = context =>
                  {
                      // 確保 cookie 中有 JWT Token
                      if (context.Request.Cookies.ContainsKey("PDMToken"))
                      {
                          var token = context.Request.Cookies["PDMToken"];

                          // 解析 JWT Token
                          var handler = new JwtSecurityTokenHandler();
                          var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                          // 提取各種聲明並存入 HttpContext.Items
                          var claims = jsonToken?.Claims.ToList(); // 提取所有聲明

                          if (claims != null)
                          {
                              // 提取需要的聲明
                              var name = claims.FirstOrDefault(c => c.Type == "name")?.Value;
                              var nameEn = claims.FirstOrDefault(c => c.Type == "name_en")?.Value;
                              var pccuid = claims.FirstOrDefault(c => c.Type == "pccuid")?.Value;
                              var email = claims.FirstOrDefault(c => c.Type == "email")?.Value;
                              var userId = claims.FirstOrDefault(c => c.Type == "user_id")?.Value;

                              // 將所有需要的資料存入 HttpContext.Items
                              context.HttpContext.Items["name"] = name;
                              context.HttpContext.Items["name_en"] = nameEn;
                              context.HttpContext.Items["pccuid"] = pccuid;
                              context.HttpContext.Items["email"] = email;
                              context.HttpContext.Items["user_id"] = userId;

                          }
                      }
                      return Task.CompletedTask;
                  }
              };
 
          });
            */
        }
        /// <summary>
        /// 自動掃描並注入所有繼承 IScopedService 的類別
        /// </summary>
        public void AddScopedServices(IServiceCollection services)
        {
            // 自動掃描並註冊所有繼承 IScopedService 的類別
            var assembly = Assembly.GetExecutingAssembly();
            var serviceTypes = assembly.GetTypes()
                .Where(t => t.IsClass &&
                            !t.IsAbstract &&
                            typeof(IScopedService).IsAssignableFrom(t)) // 取得所有實作 IScopedService 的類別
                .Select(t => new
                {
                    Service = t.GetInterfaces().FirstOrDefault(i => typeof(IScopedService).IsAssignableFrom(i) && i != typeof(IScopedService)),
                    Implementation = t
                })
                .Where(t => t.Service != null); //確保有對應的介面

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }/*
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true; // 防止客戶端腳本訪問
                    options.ExpireTimeSpan = TimeSpan.FromHours(2); // Cookie 過期時間
                    options.SlidingExpiration = true; // 每次請求重置過期時間
                }
            */
            ).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.Authority = Configuration["Authentication:PCG:Authority"]; // 設定 SSO 伺服器位址
                options.ClientId = Configuration["Authentication:PCG:ClientId"];   // 設定 Client ID
                options.ClientSecret = Configuration["Authentication:PCG:ClientSecret"]; // 設定 Secret
                options.ResponseType = "code";       // 採用 Authorization Code 模式
                options.SaveTokens = true;           // 保存 Token
                options.Scope.Add("openid");         // 預設範圍
                options.Scope.Add("profile");
                options.CallbackPath = "/signin-oidc";//options.CallbackPath = new PathString("/api/auth/callback"); // 驗證回調路徑 (與設定一致)
                options.SignedOutRedirectUri = Configuration["Authentication:PCG:PostLogoutRedirectUri"]; //options.SignedOutRedirectUri = "http://localhost:44378/signin-oidc"; // 登出重定向 

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // 驗證頒發者
                    ValidateAudience = true, // 驗證受眾
                    ValidateLifetime = true, // 驗證 Token 是否過期
                    ClockSkew = TimeSpan.FromMinutes(10), // 允許的時間偏差
                    ValidIssuer = Configuration["Authentication:PCG:Authority"],
                    ValidAudience = Configuration["Authentication:PCG:ClientId"]
                };

            });

            services.Configure<OAuthConfig>(Configuration.GetSection("Authentication:PCG"));
            // ? 加上 JWT 驗證，從 Cookie["PDMToken"] 解析 JWT
            var jwtSecret = Configuration["Authentication:PCG:ClientSecret"];
            var jwtKey = Encoding.UTF8.GetBytes(jwtSecret);

            services.AddAuthentication()
                .AddJwtBearer("PDMToken", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "PDMAppissu",     // ?? 必須與產生 JWT 時一致
                        ValidAudience = "testclient",   // ?? 同上
                        IssuerSigningKey = new SymmetricSecurityKey(jwtKey)
                    };

                    // 讓 ASP.NET Core 從 Cookie["PDMToken"] 讀取 JWT
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var token = context.Request.Cookies["PDMToken"];
                            if (!string.IsNullOrEmpty(token))
                            {
                                context.Token = token;
                            }
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine($"[JWT 驗證失敗] {context.Exception.Message}");
                            return Task.CompletedTask;
                        }
                    };
                });

            foreach (var type in serviceTypes)
            {
                services.AddScoped(type.Service, type.Implementation);
            }
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseValidationExceptionHandler();

            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseOpenApi(); // OpenAPI 規範文檔 (swagger.json)
                              //app.UseSwagger(); 原生swagger
            app.UseSwaggerUi3(); // NSwag
                                 //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PDMApp v1"));
                                 //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            var exportFolder = Path.Combine(env.ContentRootPath, "ExportedFiles");

            // 如果資料夾不存在，則自動建立
            if (!Directory.Exists(exportFolder))
            {
                Directory.CreateDirectory(exportFolder); // 建立資料夾
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(exportFolder),
                RequestPath = "/ExportedFiles"
            });

            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");

            app.UseAuthentication(); // 啟用 JWT 驗證
            app.UseAuthorization();  // 啟用授權

            app.UseMiniProfiler();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
