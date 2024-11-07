using PDMApp.Models;
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
        //public string? Text { get; set; }
        //public string? GroupKey { get; set; }
        public string? MoldNo { get; set; }
        public string? Factory { get; set; }
        public string? Shfactory { get; set; }
        public string? ItemNameEng { get; set; }
        public string? ItemNameJpn { get; set; }
        public string? ItemNo { get; set; }
        public string? DevNo { get; set; }
        public string? DevColorDispName { get; set; }
        public string? ColorNo { get; set; }
        public string? Entrymode { get; set; }
        public string? Cbdlockmk { get; set; }
        public string? ProductMId { get; set; }
        public string? Heelheight { get; set; }
        public string? ProductDId { get; set; }
        public string? OutMoldNo { get; set; }
        public ICollection<pdm_spec_itemDto> pdm_Spec_ItemDtos { get; set; }
    }
}
