using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dtos.FactorySpec
{  
    public class ItemSheetDTO
    {
        public string? SpecMId { get; set; }    //ID
        public int? Seqno { get; set; }
        public string? PartClass { get; set; }
        public string? MailTo { get; set; }
        public string? MailCC { get; set; }
        public string? Stage { get; set; }
        public string? CreateTime { get; set; }
        public string? DevNo { get; set; }
        public string? RefDevNo { get; set; }
        public string? ItemNameEng { get; set; }
        public string? ItemNo { get; set; }
        public string? ColorNo { get; set; }
        public string? SampleSize { get; set; }
        public decimal? HeelHeight { get; set; }
        public string? ColorNameChn { get; set; }
        public string? ColorEng { get; set; }
        public string? FactoryMoldNo1 { get; set; }
        public string? LastNo1 { get; set; }
        public string? CreateUser { get; set; }
        public string? Type { get; set; }      //Newmaterial
        public string? Parts { get; set; }
        public string? No { get; set; }
        public string? Material { get; set; }    // 材料
        public string? Colors { get; set; }
        public string? Standard { get; set; }
        public string? Hcha { get; set; }
        public string? Sec { get; set; }
        public string? Supplier { get; set; }    // 供應商
    }
    public class StandardSheetDTO
    {
        public string? SpecMId { get; set; }    // 範本ID
        public string? StandardCode { get; set; } // 標準代碼
        public string? StandardName { get; set; } // 標準名稱
        public string? Unit { get; set; }        // 單位
        public string? StandardValue { get; set; } // 標準值
        public string? Supplier { get; set; }    // 供應商
        public string? Remarks { get; set; }     // 備註
    }
    public class UpperFigureSheetDTO
    {
        public string? SpecMId { get; set; }    // 範本ID
        public string? UpperFigureCode { get; set; } // 上層圖代碼
        public string? Material { get; set; }   // 材料
        public string? Color { get; set; }      // 顏色
        public string? Size { get; set; }       // 尺寸
        public string? Description { get; set; } // 描述
        public string? Memo { get; set; }       // 備註
    }
    public class SkiveSheetDTO
    {
        public string? SpecMId { get; set; }    // 範本ID
        public string? SkiveCode { get; set; }  // 削切代碼
        public string? SkiveType { get; set; }  // 削切類型
        public string? SkiveDescription { get; set; } // 削切描述
        public string? Thickness { get; set; }  // 厚度
        public string? Material { get; set; }   // 材料
        public string? Memo { get; set; }       // 備註
    }
    public class SoleFigureSheetDTO
    {
        public string? SpecMId { get; set; }    // 範本ID
        public string? SoleFigureCode { get; set; } // 鞋底圖代碼
        public string? Material { get; set; }   // 材料
        public string? Color { get; set; }      // 顏色
        public string? Size { get; set; }       // 尺寸
        public string? Description { get; set; } // 描述
        public string? Memo { get; set; }       // 備註
    }
}

