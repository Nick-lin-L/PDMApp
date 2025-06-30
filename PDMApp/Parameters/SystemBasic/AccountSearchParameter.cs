namespace PDMApp.Parameters.Basic
{
    public class AccountSearchParameter
    {
#nullable enable
        public string? LocalName { get; set; }
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }

    public class AccountDetailSearchParameter
    {
        public long UserId { get; set; }
    }

    public class CreateUserRoleParameter
    {
        public long UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class SearchUserBySSOParameter
    {
        public string SsoAcct { get; set; }
    }

    
    public class CreateUserBySSOParameter
    {
        public string SsoAcct { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pccuid { get; set; }
    }

    // 新增 API 回應的 DTO 類別
    public class TokenResponseDto
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public int refresh_expires_in { get; set; }
        public string token_type { get; set; }
        public int not_before_policy { get; set; }
        public string scope { get; set; }
    }

    public class UserInfoApiResponse
    {
        public UserInfoResponseDto[] data { get; set; } 
        /* 這裡是對應 sso API的回傳格式，之中的data。
         * {
         * "timestamp": 1750990839958,
         * "statusCode": 200,
         * "data": [
         * {
        */
    }

    public class UserInfoResponseDto
    {
        public string? id { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public bool? enabled { get; set; }
        public string sso_acct { get; set; }
        public string contact_mail { get; set; }
        public string english_nm { get; set; }
        public string chinese_nm { get; set; }
        public string local_pnl_nm { get; set; }
        public long pccuid { get; set; }
        // 根據實際 API 回應格式調整
    }
}
