using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters
{
    public class SpecSearchParameter
    {
        //接收user查詢的參數
        public string? Spec_m_id { get; set; }
        public string? Factory { get; set; }
        public string? EntryMode { get; set; }
        public string? Season { get; set; }
        public string? Year { get; set; }
        public string? Item_No { get; set; }
        public string? Color_No { get; set; }
        public string? Dev_No { get; set; }
        public string? Devcolorno { get; set; }
        public string? Stage { get; set; }
        public string? Customer_kbn { get; set; }
        public string? Mode_name { get; set; }
        public string? Out_mold_no { get; set; }
        public string? Last_No1 { get; set; }
        public string? Last_No2 { get; set; }
        public string? Last_No3 { get; set; }
        public string? Item_Name_ENG { get; set; }
        public string? Item_Name_JPN { get; set; }
        public string? Part_Name { get; set; } // PDM_SPEC_ITEM.PARS
        public string? Part_No { get; set; } // PDM_SPEC_ITEM.ACT_NO
        public string? Mat_Color { get; set; } // PDM_SPEC_ITEM.colors
        public string? Material { get; set; }
        public string? SubMaterial { get; set; }
        public string? Supplier { get; set; }
        public string? Width { get; set; }
        public string? HeelHeight { get; set; }
    }
}
