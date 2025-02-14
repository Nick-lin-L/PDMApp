using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        // GET: api/<RolePermissionController>
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public RolePermissionController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }

        // 0. Pageload 下拉查詢列表
        /// <summary>
        /// Roles頁面初始化傳入的參數
        /// </summary>
        /// <param name="value">傳入的參數物件，用於判斷是否需要加載特定的初始資料。</param>
        /// <returns>回傳一個包含初始數據的 <see cref="APIStatusResponse{IDictionary}"/> 格式。</returns>
        [ProducesResponseType(typeof(APIStatusResponse<IDictionary<string, object>>), 200)]
        [ProducesResponseType(typeof(object), 500)]
        [HttpPost("initial")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> RolePageInitial([FromBody] PermissionsParameter value)
        {
            try
            {
                // Factory 查詢
                var query = BasicQueryHelper.QueryFactory(_pcms_Pdm_TestContext);
                var factoryq = await query.Distinct().ToListAsync();
                var dynamicData = new Dictionary<string, object>
                {
                    { "DevFactoryNo", factoryq }
                };
                return APIResponseHelper.HandleDynamicMultiPageResponse(dynamicData);
            }
            catch (Exception ex)
            {
                return new ObjectResult(APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: $"查詢過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }
        }

        // 1. 查詢角色列表
        [HttpPost("roles")]
        //public IActionResult Roles([FromBody] RoleQueryRequest request)
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_rolesDto>>>> Roles([FromBody] RolesParameter value)
        {
            try
            {
                var query = BasicQueryHelper.QueryRoles(_pcms_Pdm_TestContext);
                var filters = new List<Expression<Func<pdm_rolesDto, bool>>>();

                if (!string.IsNullOrWhiteSpace(value.RoleName))
                    filters.Add(proles => proles.RoleName.Contains(value.RoleName));
                if (!string.IsNullOrWhiteSpace(value.Description))
                    filters.Add(proles => proles.Description.Contains(value.Description));
                if (!string.IsNullOrWhiteSpace(value.DevFactoryNo))
                    filters.Add(proles => proles.DevFactoryNo.Contains(value.DevFactoryNo));

                if (!string.IsNullOrWhiteSpace(value.IsActive))
                {
                    string TrimIsActive = value.IsActive.Trim();
                    filters.Add(proles => proles.IsActive == TrimIsActive);
                }


                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }

                // 排序,如果需要多重排序的話後面接.ThenBy(條件)即可
                //query = query.OrderBy(proles => proles.RoleId);
                var pagedResult = await query.Distinct().OrderBy(proles => proles.RoleId)
                                             .ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);

                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (Exception ex)
            {
                return new ObjectResult(APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: $"匯出過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }
        }

        // 2. 查詢權限列表
        [HttpPost("permissions")]
        //public async Task<ActionResult<APIStatusResponse<IEnumerable<pdm_permissionsDto>>>> Permissions([FromBody] PermissionsParameter value)
        //public ActionResult<APIStatusResponse<IEnumerable<PermissionsWrapper>>> Permissions([FromBody] PermissionsParameter value)
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> Permissions([FromBody] PermissionsParameter value)
        {
            try
            {
                // permissions 查詢
                var query = BasicQueryHelper.QueryPermissions(_pcms_Pdm_TestContext);
                var filters = await query.Distinct().OrderBy(q=>q.RolePermissionId).ToListAsync();

                // details 查詢
                var queryD = BasicQueryHelper.QueryPermissionDetails(_pcms_Pdm_TestContext);
                var filtersD = await queryD.Distinct().OrderBy(q => q.RolePermissionDetailId).ToListAsync();
                var dynamicData = new Dictionary<string, object>
                {
                    { "Permissions", filters },
                    { "PermissionDetails", filtersD },
                };
                return APIResponseHelper.HandleDynamicMultiPageResponse(dynamicData);
            }
            catch (Exception ex)
            {
                return new ObjectResult(APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: $"匯出過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }
        }

        // 3. 新增或更新角色資料
        [HttpPost("upsert")]
        public async Task<IActionResult> UpsertRolePermission([FromBody] RolePermissionsParameter request)
        {
            using (var transaction = await _pcms_Pdm_TestContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (!int.TryParse(request.UpdatedBy, out int updatedBy))
                    {
                        return BadRequest("Invalid UpdatedBy value.");
                    }

                    pdm_roles role;

                    // 檢查角色是否存在，進行新增或更新
                    if (string.IsNullOrWhiteSpace(request.RoleId))
                    {
                        role = new pdm_roles
                        {
                            role_name = request.RoleName,
                            description = request.Description,
                            dev_factory_no = request.DevFactoryNo,
                            is_active = request.IsActive,
                            created_by = updatedBy,
                            created_at = DateTime.UtcNow,
                            updated_by = updatedBy,
                            updated_at = DateTime.UtcNow
                        };
                        _pcms_Pdm_TestContext.pdm_roles.Add(role);
                        await _pcms_Pdm_TestContext.SaveChangesAsync();
                    }
                    else
                    {
                        if (!int.TryParse(request.RoleId, out int roleId))
                            return BadRequest($"Invalid RoleId: {request.RoleId}");

                        role = await _pcms_Pdm_TestContext.pdm_roles.FindAsync(roleId);
                        if (role == null)
                            return NotFound($"Role with ID {request.RoleId} does not exist.");

                        role.role_name = request.RoleName ?? role.role_name;
                        role.description = request.Description ?? role.description;
                        role.dev_factory_no = request.DevFactoryNo ?? role.dev_factory_no;
                        role.is_active = request.IsActive ?? role.is_active;
                        role.updated_by = updatedBy;
                        role.updated_at = DateTime.UtcNow;
                        await _pcms_Pdm_TestContext.SaveChangesAsync();
                    }
                    /*
                    // 處理 PermissionsDetails 批量查詢與更新
                    if (request.PermissionDetails != null && request.PermissionDetails.Any())
                    {
                        var detailIds = request.PermissionDetails
                            //.Where(d => d.RolePermissionDetailsId.HasValue)
                            //.Select(d => d.RolePermissionDetailId.Value)
                            .ToList();

                        var existingDetails = _pcms_Pdm_TestContext.pdm_role_permission_details
                            .Where(pd => detailIds.Contains(pd.role_permission_detail_id))
                            .ToList();

                        var newDetails = new List<pdm_role_permission_details>();

                        foreach (var detail in request.PermissionDetails)
                        {
                            var existingDetail = existingDetails.FirstOrDefault(ed => ed.role_permission_detail_id == detail.RolePermissionDetailsId);

                            if (existingDetail != null)
                            {
                                // 更新已有的詳細權限
                                existingDetail.permission_key = detail.PermissionKey ?? existingDetail.permission_key;
                                existingDetail.description = detail.DescriptionD ?? existingDetail.description;
                                existingDetail.is_active = detail.IsActiveD ?? existingDetail.is_active;
                                existingDetail.dev_factory_no = detail.DevFactoryNoD ?? existingDetail.dev_factory_no;
                                existingDetail.updated_by = updatedBy;
                                existingDetail.updated_at = DateTime.UtcNow;
                            }
                            else
                            {
                                // 新增新的詳細權限
                                newDetails.Add(new pdm_role_permission_details
                                {
                                    role_permission_id = detail.PermissionId,  // 關聯 PermissionId
                                    permission_key = detail.PermissionKey,
                                    description = detail.DescriptionD,
                                    is_active = detail.IsActiveD ?? "Y",
                                    dev_factory_no = detail.DevFactoryNoD,
                                    created_by = updatedBy,
                                    created_at = DateTime.UtcNow,
                                    updated_by = updatedBy,
                                    updated_at = DateTime.UtcNow
                                });
                            }
                        }

                        // 批量新增新的詳細權限
                        if (newDetails.Any())
                        {
                            _pcms_Pdm_TestContext.pdm_role_permission_details.AddRange(newDetails);
                        }

                        await _pcms_Pdm_TestContext.SaveChangesAsync();
                    }*/

                    await transaction.CommitAsync();
                    return Ok(new { Message = "角色及權限處理成功", RoleId = role.role_id });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"發生錯誤: {ex.Message}");
                }
            }
        }


        private void UpdateRolePermission(pdm_role_permissions existingPerm, PermissionRequest perm, int updatedBy)
        {
            bool isModified = false;

            if (existingPerm.is_active != perm.IsActive)
            {
                existingPerm.is_active = perm.IsActive;
                isModified = true;
            }
            if (existingPerm.createp != perm.CreateP)
            {
                existingPerm.createp = perm.CreateP;
                isModified = true;
            }
            if (existingPerm.readp != perm.ReadP)
            {
                existingPerm.readp = perm.ReadP;
                isModified = true;
            }
            if (existingPerm.updatep != perm.UpdateP)
            {
                existingPerm.updatep = perm.UpdateP;
                isModified = true;
            }
            if (existingPerm.deletep != perm.DeleteP)
            {
                existingPerm.deletep = perm.DeleteP;
                isModified = true;
            }
            if (existingPerm.exportp != perm.ExportP)
            {
                existingPerm.exportp = perm.ExportP;
                isModified = true;
            }
            if (existingPerm.importp != perm.ImportP)
            {
                existingPerm.importp = perm.ImportP;
                isModified = true;
            }
            if (existingPerm.dev_factory_no != perm.DevFactoryNo)
            {
                existingPerm.dev_factory_no = perm.DevFactoryNo;
                isModified = true;
            }

            if (isModified)
            {
                existingPerm.updated_by = updatedBy;
                existingPerm.updated_at = DateTime.UtcNow;
            }
        }
    }
    public class PermissionsWrapper
    {
        public IEnumerable<pdm_permissionsDto> Permissions { get; set; }
    }
}
