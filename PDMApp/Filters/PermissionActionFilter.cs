using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PDMApp.Attributes;
using PDMApp.Service;
using PDMApp.Service.Basic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Filters
{
    public class PermissionActionFilter : IAsyncActionFilter
    {
        private readonly ICurrentUserPermissionService _permissionService;

        public PermissionActionFilter(ICurrentUserPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var permissionAttributes = context.ActionDescriptor
                .EndpointMetadata
                .OfType<RequirePermissionAttribute>()
                .ToList();

            if (!permissionAttributes.Any())
            {
                await next(); // 沒有標記權限需求，直接放行
                return;
            }

            foreach (var attr in permissionAttributes)
            {
                bool hasPermission = await _permissionService.HasPermissionAsync(attr.PermissionId, attr.Action);

                if (!hasPermission)
                {
                    context.Result = new ForbidResult(); // 或回傳自訂的錯誤格式
                    return;
                }
            }

            await next();
        }
    }
}
