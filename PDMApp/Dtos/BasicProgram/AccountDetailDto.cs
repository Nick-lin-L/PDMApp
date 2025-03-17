using System;
<<<<<<< HEAD
=======
using System.Text.Json.Serialization;
>>>>>>> 1b7f315968aa5d9a52fbafa3d39966405b3fd9cf

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

<<<<<<< HEAD
=======
    public class DevelopmentNoDto
    {
        public string? ProductMId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class RoleDto
    {
        public int Value { get; set; } // 內存值
        public string Text { get; set; } // 外顯值
        [JsonIgnore]
        public string DevFactoryNo { get; set; }
    }

    public class DevFactoryNoDto
    {
        public string Value { get; set; } // 內存值
        public string Text { get; set; } // 外顯值
    }

>>>>>>> 1b7f315968aa5d9a52fbafa3d39966405b3fd9cf
}
