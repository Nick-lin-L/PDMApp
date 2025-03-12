using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class UserInfoDto
    {
        // 為https://iamlab.pouchen.com/auth/realms/pcg/protocol/openid-connect/userinfo 取回來的資料格式以下為資料型態
        /*
         * {
                "pccuid": "1234",
                "sub": "69403d1d-932b-43c7-9a3e-23",
                "uid": "rrr",
                "employee_type": "集團員工",
                "email_verified": false,
                "name": "Min Wang 王大明",
                "preferred_username": "min.wang",
                "given_name": "Min Wang",
                "family_name": "王大明",
                "email": "min.wang@pouchen.com"
            }
         */
        public string Sub { get; set; }  // 唯一識別碼
        public string Pccuid { get; set; } // 內部識別碼
        public string Uid { get; set; }  // 使用者帳號
        public string Name { get; set; } // 姓名
        public string Email { get; set; }  // Email
        public bool EmailVerified { get; set; }  // 是否驗證 Email
    }
}
