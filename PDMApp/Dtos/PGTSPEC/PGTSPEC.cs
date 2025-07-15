using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dtos.PGTSPEC
{
    
    // Header DTO
    public class PGTSPECHeaderDto
    {
        public string? SpecMId { get; set; }
        public string? Brand { get; set; }
        public string? DevelopmentNo { get; set; }
        public string? DevelopmentColorNo { get; set; }
        public string? ColorCode { get; set; }
        public string? Colorway { get; set; }
        public string? Stage { get; set; }
        public string? ModelName { get; set; }
        public int? Ver { get; set; }
        public string CheckoutMk { get; internal set; }
        public string CheckoutUser { get; internal set; }
        public string SpecLockMk { get; internal set; }
        [JsonConverter(typeof(PDMApp.Utils.Converters.DateTimeConverterHms))]
        public DateTime? UpdateDate { get; internal set; }
        public string UpdateUser { get; internal set; }
        public string EditMk { get; internal set; }
        
    }


    public class DevelopmentNoDto
    {
        public string? ProductMId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class DevelopmentColorNoDto
    { 
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class ComboDto
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class ComboDataDto
    {
        public IEnumerable<ComboDto> BrandCombo { get; set; } = new List<ComboDto>();
        public IEnumerable<ComboDto> SpecSourceCombo { get; set; } = new List<ComboDto>();
        public IEnumerable<ComboDto> StageCombo { get; set; } = new List<ComboDto>();
        public IEnumerable<DevelopmentNoDto> DevelopmentNoCombo { get; set; } = new List<DevelopmentNoDto>();
        public IEnumerable<DevelopmentColorNoDto> DevelopmentColorNoCombo { get; set; } = new List<DevelopmentColorNoDto>();
    }

    public class SpecBasicDTO
    {
        public string SpecMId { get; set; }
        public string DevelopmentNo { get; set; }
        public string ItemNo { get; set; }
        public string ModelName { get; set; }
        public string Factory { get; set; }
        public string Season { get; set; }
        public string SampleSize { get; set; }
        public string SizeRun { get; set; }
        public string SizeRange { get; set; }
        public string Stage { get; set; }
        public string ColorWay { get; set; }
        public string ColorCode { get; set; }
        public string DevelopmentColorNo { get; set; }
        public string MainColor { get; set; }
        public string SubColor { get; set; }
        public string ItemMode { get; set; }
        public string SubItemMode { get; set; }
        public string Gender { get; set; }
        public string Width { get; set; }
        public string Last1 { get; set; }
        public string Last2 { get; set; }
        public string Last3 { get; set; }
        public string SizeMap { get; set; }
        public string Lasting { get; set; }
        public string HeelHeight { get; set; }
        public string ProductType { get; set; }
        public string Category { get; set; }
        public string ProductionLeadTime { get; set; }

    }

    public class SpecHeadDto
    {
        public string? SpecMId { get; set; }
        public string? PgtColorName { get; set; }
        public string? RefDevNo { get; set; }
        public string? MailTo { get; set; }  // (TBD) 目前預設為空值
        public string? MailCc { get; set; }  // (TBD) 目前預設為空值
        public string? MoldNo1 { get; set; }
        public string? MoldNo2 { get; set; }
        public string? MoldNo3 { get; set; }
        public string? RemarksSpec { get; set; }
        public string? RemarksProhibit { get; set; }
    }


    // Upper 規格 DTO
    public class SpecUpperDTO
    {
        [JsonIgnore]
        public string? SpecMId { get; set; }
        public string? SpecDId { get; set; }
        public decimal? Sort { get; set; } // MATERIAL_SORT
        public string? No { get; set; } // PART_NO
        public string? ActPartNo { get; set; } // ACT_PART_NO
        public string? Type { get; set; } // MATERIAL_NEW
        public string? Parts { get; set; } // PARTS
        public string? Detail { get; set; } // DETAIL
        public string? ProcessMk { get; set; } // PROCESS_MK
        public string? SerpMatNo { get; set; }
        public string? MaterialNo { get; set; } // SERP_MATERIAL_NO (需關聯 MATERIAL 取得)
        public string? Material { get; set; } // MATERIAL
        public string? Recycle { get; set; } // RECYCLE
        public string? MaterialComment { get; set; } // MATERIAL_COMMENT
        public string? Standard { get; set; } // STANDARD
        public string? Agent { get; set; } // AGENT
        public string? Supplier { get; set; } // SUPPLIER
        public string? QuoteSupplier { get; set; } // QUOTE_SUPPLIER
        public string? Hcha { get; set; } // HC/HA
        public string? Sec { get; set; } // SEC
        public string? Colors { get; set; } // MATERIAL_COLOR
        public string? ColorComment { get; set; } // COLOR_COMMENT
        public string? Memo { get; set; } // MEMO

        [JsonIgnore]
        public string? MatGroup { get; set; }
    }


    // 標準規格 DTO
    public class SpecStandardDTO
    {
        [JsonIgnore]
        public string? SpecMId { get; set; }
        public int? Seq { get; set; }
        public string? Size { get; set; }
        public string? ShoeLaceLength { get; set; }
        public string? ShoeBox { get; set; }
        public string? GelFore { get; set; }
        public string? GelRear { get; set; }
        public string? Toekeeper { get; set; }
        public string? ShoeBag { get; set; }
        public string? Itemval7 { get; set; }
        public string? Itemval8 { get; set; }
        public string? Itemval9 { get; set; }
        public string? Memo { get; set; }

    }

    // 多頁結果 DTO
    public class MultiPageResultDTO
    {
        public IEnumerable<SpecBasicDTO>? BasicData { get; set; }
        public IEnumerable<SpecHeadDto>? HeadData { get; set; }
        public IEnumerable<SpecUpperDTO>? UpperData { get; set; }
        public IEnumerable<SpecUpperDTO>? SoleData { get; set; }
        public IEnumerable<SpecUpperDTO>? OtherData { get; set; }
        public IEnumerable<SpecStandardDTO>? StandardData { get; set; }
    }

    public class ItemSheetDTO
    {
        public string? SpecMId { get; set; }    //ID
        public decimal? Seqno { get; set; }
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
        public string? DevelopmentColorNo { get; set; }
        public string? SampleSize { get; set; }
        public string? HeelHeight { get; set; }
        public string? ColorNameChn { get; set; }
        public string? ColorEng { get; set; }
        public string? FactoryMoldNo1 { get; set; }
        public string? FactoryMoldNo2 { get; set; }
        public string? FactoryMoldNo3 { get; set; }
        public string? LastNo1 { get; set; }
        public string? LastNo2 { get; set; }
        public string? LastNo3 { get; set; }
        public string? CreateUser { get; set; }
        public string? Type { get; set; }      //Newmaterial
        public string? Parts { get; set; }
        public string? No { get; set; }
        public string? Material { get; set; }    // 材料
        public string? SubMaterial { get; set; }    // 材料
        public string? Colors { get; set; }
        public string? Standard { get; set; }
        public string? Hcha { get; set; }
        public string? Sec { get; set; }
        public string? Supplier { get; set; }    // 供應商
        public object ActNo { get; internal set; }
        public string RemarksProhibit { get; internal set; }
    }

    public class MatmResultDto
    {
        public string? SerpMatNo { get; set; }
        public string? MaterialNo { get; set; }
        public string? MatFullNm { get; set; }
        public string? ColorNo { get; set; }
        public string? ColorNm { get; set; }
        public string? Uom { get; set; }
        public string? Memo { get; set; }
        public string? Standard { get; set; }
        public string? Colors { get; set; }      // COLOR + " " + COLOR_NM
    }

    public class MaterialExportDto
    {
        public string? SpecMId { get; set; } 
        public string? MatFullName { get; set; }
        public string? ColorName { get; set; }  
        public string? Standard { get; set; }    
        public string? Memo { get; set; }        
        public string? MatType { get; set; }
        public string? MatNoPDM { get; set; }
        public string? ColorNo { get; set; }
        public string? UOM { get; set; }
        public string? PDMMatlNo { get; set; } 
        public string? ScmClassL { get; set; }
        public string? ScmClassM { get; set; }
        public string? ScmClassS { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class MaterialInfoDTO
    {
        public string? SerpMatNo { get; set; }
        public string? MaterialNo { get; set; }
    }

    public class ExportFileResponseDto
    {
        public string FileName { get; set; }
        public string FileContent { get; set; }
    }


}

