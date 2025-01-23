using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.Cbd
{
    public class CbdQueryDto
    {
        public string? Data_m_id { set; get; }
        public string? Product_m_id { set; get; }
        public string? Product_d_id { set; get; }
        public string? Itemtrading_code { set; get; }
        public string? Development_no { set; get; }
        public string? Development_color_no { set; get; }
        public string? Stage { set; get; }
        public string? Stage_display { set; get; }
        public string? Working_name { set; get; }
        public string? Color_code { set; get; }
        public string? Colorway { set; get; }
        public string? Bom { set; get; }
        public string? Colors { set; get; }
        public int? Vssver { set; get; }
        public int? Ver { set; get; }
        public string? Cbd_update_user { set; get; }
        public string? Cbd_update_date { set; get; }
        public string? Update_user { set; get; }
        public string? Update_date { set; get; }
    }
}