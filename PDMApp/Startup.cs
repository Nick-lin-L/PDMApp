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
            /* 原生swagger文件配置
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "PDMApp", Version = "v1" }); });   */

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
            //services.AddControllers();
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
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
