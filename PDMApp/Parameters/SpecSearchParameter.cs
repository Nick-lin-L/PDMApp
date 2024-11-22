using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters
{
    public class SpecSearchParameter
    {
        //接收user查詢的參數
        public string? SpecMId { get; set; }
        public string? Factory { get; set; }
        public string? EntryMode { get; set; }
        public string? Season { get; set; }
        public string? Year { get; set; }
        public string? ItemNo { get; set; }
        public string? ColorNo { get; set; }
        public string? DevNo { get; set; }
        public string? Devcolorno { get; set; }
        public string? Stage { get; set; }
        public string? CustomerKbn { get; set; }
        public string? ModeName { get; set; }
        public string? OutMoldNo { get; set; }
        public string? LastNo { get; set; }
        public string? ItemNameENG { get; set; }
        public string? ItemNameJPN { get; set; }
        public string? PartName { get; set; } // PDM_SPEC_ITEM.PARS
        public string? PartNo { get; set; } // PDM_SPEC_ITEM.ACT_NO
        public string? MatColor { get; set; } // PDM_SPEC_ITEM.colors
        public string? Material { get; set; }
        public string? SubMaterial { get; set; }
        public string? Supplier { get; set; }
        public string? Width { get; set; }
        public string? HeelHeight { get; set; }
    }
}
