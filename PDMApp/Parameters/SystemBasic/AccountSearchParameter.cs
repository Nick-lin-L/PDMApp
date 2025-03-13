
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



}
