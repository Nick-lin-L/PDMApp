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
            /* ���swagger���t�m
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "PDMApp", Version = "v1" }); });   */

            // NSwag OpenAPI���t�m
            services.AddOpenApiDocument(config =>
            {
                config.Title = "PDMApp";
                config.Version = "v1";
                config.Description = "PDMApp API ��� (�۰ʥͦ�)";
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("https://pcms-mif-test01.pouchen.com", "http://localhost:*") // ���w�e�ݨӷ�
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials() // �p�G�� Cookie �ξ��ҽШD�A�o�O���ݪ�
                           .WithExposedHeaders("Message", "FileName"); // �p�G�S�[�F�sHeads�A�o���٭n�[�W�e�ݤ~��ݨ�
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
                app.UseOpenApi(); // OpenAPI �W�d���� (swagger.json)
                //app.UseSwagger(); ���swagger
                app.UseSwaggerUi3(); // NSwag
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PDMApp v1"));
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            var exportFolder = Path.Combine(env.ContentRootPath, "ExportedFiles");

            // �p�G��Ƨ����s�b�A�h�۰ʫإ�
            if (!Directory.Exists(exportFolder))
            {
                Directory.CreateDirectory(exportFolder); // �إ߸�Ƨ�
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
