using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PDMApp.Utils.BasicProgram
{
    public static class UserRoleQueryHelper
    {
        /// <summary>
        /// 查詢使用者角色列表
        /// </summary>
        public static IQueryable<UserRoleDto> QueryUserRoles(pcms_pdm_testContext context)
        {
            return from ur in context.pdm_user_roles
                   join u in context.pdm_users on ur.user_id equals u.user_id
                   join r in context.pdm_roles on ur.role_id equals r.role_id
                   join createdBy in context.pdm_users on ur.created_by equals createdBy.user_id into createdByJoin
                   from createdBy in createdByJoin.DefaultIfEmpty()
                   join updatedBy in context.pdm_users on ur.updated_by equals updatedBy.user_id into updatedByJoin
                   from updatedBy in updatedByJoin.DefaultIfEmpty()
                   select new UserRoleDto
                   {
                       RoleId = ur.role_id.ToString(),
                       DevFactoryNo = r.dev_factory_no,
                       PccuId = u.pccuid.ToString(),
                       SsoAcct = u.sso_acct,
                       IsSso = u.is_sso,
                       IsActive = u.is_active,
                       UserName = u.username,
                       LocalName = u.local_name,
                       Email = u.email,
                       CreatedBy = createdBy != null ? createdBy.username : string.Empty,
                       CreatedAt = ur.created_at,
                       UpdatedBy = updatedBy != null ? updatedBy.username : string.Empty,
                       UpdatedAt = ur.updated_at
                   };
        }

        /// <summary>
        /// 查詢特定角色的使用者
        /// </summary>
        public static IQueryable<UserRoleDto> QueryUserRolesByRoleId(pcms_pdm_testContext context, int roleId)
        {
            return QueryUserRoles(context).Where(ur => ur.RoleId.Equals(roleId));
        }

        /// <summary>
        /// 查詢特定廠別的使用者角色
        /// </summary>
        public static IQueryable<UserRoleDto> QueryUserRolesByFactory(pcms_pdm_testContext context, string devFactoryNo)
        {
            return QueryUserRoles(context).Where(ur => ur.DevFactoryNo == devFactoryNo);
        }

        /// <summary>
        /// 檢查使用者是否已有特定角色
        /// </summary>
        public static async Task<bool> CheckUserRoleExists(pcms_pdm_testContext context, long userId, int roleId)
        {
            return await context.pdm_user_roles
                .AnyAsync(ur => ur.user_id == userId && ur.role_id == roleId);
        }

        /// <summary>
        /// 取得使用者的所有角色
        /// </summary>
        public static async Task<List<pdm_roles>> GetUserRoles(pcms_pdm_testContext context, long userId)
        {
            return await context.pdm_user_roles
                .Where(ur => ur.user_id == userId)
                .Include(ur => ur.role)
                .Select(ur => ur.role)
                .ToListAsync();
        }

        /// <summary>
        /// 取得角色的所有使用者
        /// </summary>
        public static async Task<List<pdm_users>> GetRoleUsers(pcms_pdm_testContext context, int roleId)
        {
            return await context.pdm_user_roles
                .Where(ur => ur.role_id == roleId)
                .Include(ur => ur.user)
                .Select(ur => ur.user)
                .ToListAsync();
        }
    }
}