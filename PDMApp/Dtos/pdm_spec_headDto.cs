using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos
{
    public class pdm_spec_headDto
    {
        public string? Spec_m_id { get; set; }
        public string? Year { get; set; }
        public string? Season { get; set; }
        public string? Stage { get; set; }
        public string? Mold_no { get; set; }
        public string? Factory { get; set; }
        public string? Shfactory { get; set; }
        public string? Item_name_eng { get; set; }
        public string? Item_name_jpn { get; set; }
        public string? Item_no { get; set; }
        public string? Dev_no { get; set; }
        public string? Dev_color_disp_name { get; set; }
        public string? Color_no { get; set; }
        public string? Entrymode { get; set; }
        public string? Cbdlockmk { get; set; }
        public string? Product_m_id { get; set; }
        public string? Heelheight { get; set; }
        public string? Product_d_id { get; set; }
        public string? out_mold_no { get; set; }
    }
}
