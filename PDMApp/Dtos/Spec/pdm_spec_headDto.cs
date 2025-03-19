using PDMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos
{
    public class pdm_spec_headDto
    {
        public string? Specmid { get; set; }
        public string? Factory { get; set; }
        public string? Shfactory { get; set; }
        public string? Entrymode { get; set; }
        public string? Season { get; set; }
        public string? Year { get; set; }
        public string? Itemno { get; set; }
        public string? Colorno { get; set; }
        public string? Devno { get; set; }
        public string? DevcolordispName { get; set; }
        public string? Stage { get; set; }
        public string? Customerkbn { get; set; }
        public string? Mode { get; set; }
        public string? Moldno { get; set; }
        public string? Outoldno { get; set; }
        public string? Itemnameeng { get; set; }
        public string? Itemnamejpn { get; set; }





        public string? Cbdlockmk { get; set; }
        public string? Productmid { get; set; }
        public string? Heelheight { get; set; }
        public string? Productdid { get; set; }
        
        //以下是表頭用不到，但查詢條件需要的欄位
        public string? Lastno1 { get; set; }
        public string? Lastno2 { get; set; }
        public string? Lastno3 { get; set; }
        public string? Partname { get; set; }
        public string? Partno { get; set; }
        public string? Matcolor { get; set; }
        public string? Material { get; set; }
        public string? Submaterial{ get; set; }
        public string? Supplier { get; set; }
        public string? Width { get; set; }


        public ICollection<pdm_spec_itemDto> pdm_Spec_ItemDtos { get; set; }


    }
}
