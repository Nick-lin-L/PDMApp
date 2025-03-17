using System;

namespace PDMApp.Dtos.BasicProgram
{
    public class AccountDetailDto
    {
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public decimal PccUid { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string DevFactoryNo { get; set; }
    }

}
