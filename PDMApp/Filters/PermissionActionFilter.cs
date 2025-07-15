using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PDMApp.Attributes;
using PDMApp.Service;
using PDMApp.Service.Basic;
using PDMApp.Utils;
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
            var endpoint = context.ActionDescriptor.EndpointMetadata;

            // 檢查權限，如果沒有檢查權限標記則視為放行
            var permissionAttributes = endpoint.OfType<RequirePermissionAttribute>();
            foreach (var attr in permissionAttributes)
            {
                bool hasPermission;
                if (attr.IsExtendedPermission)
                {
                    hasPermission = await _permissionService.HasExtendedPermissionAsync(attr.PermissionId, attr.Action);
                }
                else
                {
                    hasPermission = await _permissionService.HasPermissionAsync(attr.PermissionId, attr.Action);
                }

                if (!hasPermission)
                {
                    // 使用 APIResponseHelper 生成統一的錯誤回應
                    var response = APIResponseHelper.HandleApiError<object>(
                        errorCode: "40301",
                        message: $"Sorry, you don't have permission to do this. (PermissionId: {attr.PermissionId}, Action: {attr.Action})",
                        data: null
                    );
                    context.Result = response.Result;
                    return;
                }
            }

            await next();
        }
    }
}
