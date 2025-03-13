using System;
using System.Text.Json.Serialization;

namespace PDMApp.Dtos.BasicProgram
{
    public class pdm_usersDto
    {
        public long UserId { get; set; } // UserId 
        public decimal PccUid { get; set; } // PCCUID
        public string UserName { get; set; } // 使用者名稱
        public string LocalName { get; set; } // 當地名稱
        public string SsoAcct { get; set; } // 單一登入帳號
        public string Email { get; set; } // 郵件
        public string IsSso { get; set; } // 是否啟用SSO
        public string IsActive { get; set; } // 是否啟用
        [JsonConverter(typeof(PDMApp.Utils.Converters.DateTimeConverterHms))]
        public DateTime? LastLogin { get; set; } // 最後登入時間
        public long? CreatedBy { get; set; } // 建立者ID
        [JsonConverter(typeof(PDMApp.Utils.Converters.DateTimeConverterHms))]
        public DateTime? CreatedAt { get; set; } // 建立時間
        public long? UpdatedBy { get; set; } // 更新者ID
        [JsonConverter(typeof(PDMApp.Utils.Converters.DateTimeConverterHms))]
        public DateTime? UpdatedAt { get; set; } // 更新時間

    }
}
