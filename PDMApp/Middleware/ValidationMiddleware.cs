using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace PDMApp.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

            // 檢查是否有模型驗證錯誤
            if (!context.Response.HasStarted && context.Items.ContainsKey("ModelValidationErrors"))
            {
                await HandleValidationErrorsAsync(context);
            }
        }

        private async Task HandleValidationErrorsAsync(HttpContext context)
        {
            var modelStateErrors = context.Items["ModelValidationErrors"] as Dictionary<string, string>;

            var errors = new Dictionary<string, string[]>();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null // 不使用駝峰命名
            };
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.ContentType = "application/json";
            var data = modelStateErrors.Values;
            await context.Response.WriteAsJsonAsync(new
            {
                ErrorCode = "Error",
                Message = string.Join(";", modelStateErrors.Values),
                Data = modelStateErrors
            }, options);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(new
            {
                Code = "SERVER_ERROR",
                Message = "發生伺服器錯誤",
                // 在開發環境可以顯示詳細錯誤: exception.Message
            });
        }


    }
    public static class ValidationExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationMiddleware>();
        }
    }



}