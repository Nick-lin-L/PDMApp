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
            // 檢查是否有 RequirePermission 特性
            var permissionAttributes = context.ActionDescriptor
                .EndpointMetadata
                .OfType<RequirePermissionAttribute>()
                .ToList();

            if (!permissionAttributes.Any())
            {
                await next(); // 沒有標記權限需求，直接放行
                return;
            }

            // 檢查每個權限
            foreach (var attr in permissionAttributes)
            {
                bool hasPermission = await _permissionService.HasPermissionAsync(attr.PermissionId, attr.Action);

                if (!hasPermission)
                {
                    // 使用 APIResponseHelper 生成統一的錯誤回應
                    var response = APIResponseHelper.HandleApiError<object>(
                        errorCode: "40301",
                        message: $"您沒有執行此操作的權限 (PermissionId: {attr.PermissionId}, Action: {attr.Action})",
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
