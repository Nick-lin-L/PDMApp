using System;
using System.Text.Json.Serialization;

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

}
