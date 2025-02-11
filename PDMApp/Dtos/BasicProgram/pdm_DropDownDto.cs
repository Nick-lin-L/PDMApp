using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class pdm_DropDownDto
    {
        // 下拉選單預設三個參數
        public int Id { get; set; } // ID值
        public string Value { get; set; } // 內存值
        public string Text { get; set; } // 外顯值
    }
}
