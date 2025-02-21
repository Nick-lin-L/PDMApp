using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDMApp.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;
using PDMApp.Utils.BasicProgram;
using Microsoft.AspNetCore.Routing;
using System.Reflection;
using PDMApp.Service;


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

            // NSwag OpenAPI文件配置
            services.AddOpenApiDocument(config =>
            {
                config.Title = "PDMApp";
                config.Version = "v1";
                config.Description = "PDMApp API 文件 (自動生成)";

            });

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
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true; // 可選，讓 JSON 格式更易讀

            });
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true; // 讓 API URL 變成小寫
            });
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

            foreach (var type in serviceTypes)
            {
                services.AddScoped(type.Service, type.Implementation);
            }
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
