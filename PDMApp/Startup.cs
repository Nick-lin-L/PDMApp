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
using PDMApp.Repositories.Basic;
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
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            // ≠Ï•Õswagger§Â•Û∞t∏m
            //services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "PDMApp", Version = "v1" }); });

            // NSwag OpenAPI?á‰ª∂?çÁΩÆ
            services.AddOpenApiDocument(config =>
            {
                config.Title = "PDMApp";
                config.Version = "v1";
                config.Description = "PDMApp API ?á‰ª∂ (?™Â??üÊ?)";
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("https://pcms-mif-test01.pouchen.com", "http://localhost:*") // ?áÂ??çÁ´Ø‰æÜÊ?
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials() // Â¶ÇÊ???Cookie ?ñÊ?Ë≠âË?Ê±ÇÔ??ôÊòØÂøÖÈ???
                           .WithExposedHeaders("Message", "FileName"); // Â¶ÇÊ??àÂ?‰∫ÜÊñ∞HeadsÔºåÈÄôÈ??ÑË??†‰??çÁ´Ø?çËÉΩ?ãÂà∞
                });
            });
            //services.AddControllers();
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.WriteIndented = true; // ?ØÈÅ∏ÔºåË? JSON ?ºÂ??¥Ê?ËÆÄ
            });
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true; // ? ËÆ?API URL ËÆäÊ?Â∞èÂØ´
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseOpenApi(); // OpenAPI Ë¶èÁ??áÊ? (swagger.json)
                //app.UseSwagger(); ?üÁ?swagger
                app.UseSwaggerUi3(); // NSwag
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PDMApp v1"));
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            var exportFolder = Path.Combine(env.ContentRootPath, "ExportedFiles");

            // Â¶ÇÊ?Ë≥áÊ?Â§æ‰?Â≠òÂú®ÔºåÂ??™Â?Âª∫Á?
            if (!Directory.Exists(exportFolder))
            {
                Directory.CreateDirectory(exportFolder); // Âª∫Á?Ë≥áÊ?Â§?
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
