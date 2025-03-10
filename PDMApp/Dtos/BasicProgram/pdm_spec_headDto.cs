using PDMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class pdm_spec_headDto
    {
#nullable enable
        public string? SpecMId { get; set; }
        public string? Factory { get; set; }
        public string? Shfactory { get; set; }
        public string? EntryMode { get; set; }
        public string? Season { get; set; }
        public string? Year { get; set; }
        public string? ItemNo { get; set; }
        public string? ColorNo { get; set; }
        public string? DevNo { get; set; }
        public string? DevColorDispName { get; set; }
        public string? Stage { get; set; }
        public string? CustomerKbn { get; set; }
        public string? Mode { get; set; }
        public string? MoldNo { get; set; }
        public string? OutMoldNo { get; set; }
        public string? ItemNameEng { get; set; }
        public string? ItemNameJpn { get; set; }





        public string? Cbdlockmk { get; set; }
        public string? ProductMId { get; set; }
        public string? HeelHeight { get; set; }
        public string? ProductDId { get; set; }

        //以下是表頭用不到，但查詢條件需要的欄位
        public string? LastNo1 { get; set; }
        public string? LastNo2 { get; set; }
        public string? LastNo3 { get; set; }
        public string? PartName { get; set; }
        public string? PartNo { get; set; }
        public string? MatColor { get; set; }
        public string? Material { get; set; }
        public string? Submaterial { get; set; }
        public string? Supplier { get; set; }
        public string? Width { get; set; }


        public ICollection<pdm_spec_itemDto>? pdm_Spec_ItemDtos { get; set; }


    }
}
