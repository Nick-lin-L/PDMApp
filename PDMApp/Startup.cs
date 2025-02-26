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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PDMApp", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("https://pcms-mif-test01.pouchen.com") // 指定前端來源
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials(); // 如果有 Cookie 或憑證請求，這是必需的
                });
            });
            //services.AddControllers();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });


            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
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
            });
            services.Configure<OAuthConfig>(Configuration.GetSection("Authentication:PCG"));


            //services.AddAuthorization(); // 啟用授權
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PDMApp v1"));
            //}

            //app.UseHttpsRedirection(); // 使用HTTPS則開放
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("AllowSpecificOrigin");

            app.UseAuthentication(); // 啟用 JWT 驗證
            app.UseAuthorization();  // 啟用授權

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
