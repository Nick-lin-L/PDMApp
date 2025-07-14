using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PDMApp.Utils.Converters;

namespace PDMApp.Dtos.BasicProgram
{
    /// <summary>
    /// 使用者角色分配請求 DTO
    /// </summary>
    public class UserRoleAssignRequest
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string DevFactoryNo { get; set; }
    }

    /// <summary>
    /// 批次使用者角色分配請求 DTO
    /// </summary>
    public class BatchUserRoleAssignRequest
    {
        public int RoleId { get; set; }
        public List<long> UserIds { get; set; } = new List<long>();
        public string DevFactoryNo { get; set; }
    }

    /// <summary>
    /// 使用者角色查詢結果 DTO
    /// </summary>
    public class UserRoleDto
    {
        public string DevFactoryNo { get; set; }
        public string RoleId { get; set; }
        public string PccuId { get; set; }
        public string UserName { get; set; }
        public string LocalName { get; set; }
        public string SsoAcct { get; set; }
        public string Email { get; set; }
        public string IsSso { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        [JsonConverter(typeof(DateTimeConverterHms))]
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        [JsonConverter(typeof(DateTimeConverterHms))]
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// 使用者角色分配結果 DTO
    /// </summary>
    public class UserRoleAssignResultDto
    {
        public int UserRoleId { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string DevFactoryNo { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// 批次分配結果 DTO
    /// </summary>
    public class BatchAssignResultDto
    {
        public List<UserRoleAssignResultDto> Results { get; set; } = new List<UserRoleAssignResultDto>();
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
    }

    /// <summary>
    /// 批次角色使用者請求 DTO (以角色為中心)
    /// </summary>
    public class BatchRoleUserRequest
    {
        public int RoleId { get; set; }
        public List<long> UserIds { get; set; } = new List<long>();
    }

    /// <summary>
    /// 使用者角色移除結果 DTO
    /// </summary>
    public class UserRoleRemoveResultDto
    {
        public int UserRoleId { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string DevFactoryNo { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// 批次移除結果 DTO
    /// </summary>
    public class BatchRemoveResultDto
    {
        public List<UserRoleRemoveResultDto> Results { get; set; } = new List<UserRoleRemoveResultDto>();
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
    }
}