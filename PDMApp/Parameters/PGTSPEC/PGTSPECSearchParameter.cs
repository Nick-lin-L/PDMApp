﻿using System.Collections.Generic;

namespace PDMApp.Parameters.PGTSPEC
{
    public class PGTSPECSearchParameter
    {
        // 接收使用者查詢的參數
#nullable enable
        public string? Brand { get; set; }
        public string? ModelName { get; set; }
        public string? Colorway { get; set; }
        public string? DevelopmentNo { get; set; }
        public string? DevelopmentColorNo { get; set; }
        public string? Stage { get; set; }
        public string? Ver { get; set; }
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }

    public class MatmSearchParameter
    {
        public string? SerpMatNo { get; set; }
        public string? MaterialNo { get; set; }
        public string? MatFullNm { get; set; }
        public string? ColorNo { get; set; }
        public string? ColorNm { get; set; }
    }

    public class CheckSpecExistParameter
    {
        public string? DevelopmentNo { get; set; }
        public string? DevelopmentColorNo { get; set; }
        public string? Stage { get; set; }
    }


    public class InsertSpecParameter
    {
        public string DevelopmentNo { get; set; }
        public string DevelopmentColorNo { get; set; }
        public string Stage { get; set; }
        public string DevFactoryNo { get; set; } // 工廠編號 
        public string SpecSource { get; set; }
        public string Brand { get; set; } // 品牌

    }

    public class CopyToSpecParameter
    {
        public string DevelopmentNo { get; set; }
        public string DevelopmentColorNo { get; set; }
        public string Stage { get; set; }
        public string DevFactoryNo { get; set; } // 開發工廠編號
        public string SpecMId { get; set; } // 被複製的 SPEC_M_ID
    }

    public class DevelopmentFactoryParameter
    {
        public string? DevFactoryNo { get; set; }
    }

    public class SpecOperationParameter
    {
        public string SpecMId { get; set; }
    }
    public class CheckoutSpecParameter : SpecOperationParameter { }
    public class CheckinSpecParameter : SpecOperationParameter { }
    public class SpecLockParameter : SpecOperationParameter { }

    public class PGTSpec5SheetsSearchParameter
    {
        public string SpecMId { get; set; }
        public string? DevFactoryNo { get; set; }
    }


    public class MaterialExportParameter
    {
        public string? DevFactoryNo { get; set; } 
        public List<SpecItemSearchParameter>? MaterialData { get; set; } 
    }

    public class SpecItemSearchParameter
    {
        public decimal? Sort { get; set; } // MATERIAL_SORT
        public string? No { get; set; } //  PARTS_NO
        public string? ActPartNo { get; set; } //  ACT_PART_NO
        public string? Type { get; set; } //  MATERIAL_NEW
        public string? Parts { get; set; } //  PARTS
        public string? Detail { get; set; } //  DETAIL
        public string? ProcessMk { get; set; } //  PROCESS_MK
        public string? Material { get; set; } //  MATERIAL
        public string? Recycle { get; set; } //  RECYCLE
        public string? MaterialComment { get; set; } //  MATERIAL_COMMENT
        public string? Standard { get; set; } //  STANDARD
        public string? Agent { get; set; } //  AGENT
        public string? Supplier { get; set; } //  SUPPLIER
        public string? QuoteSupplier { get; set; } //  QUOTE_SUPPLIER
        public string? Hcha { get; set; } //  HC/HA 
        public string? Sec { get; set; } //  SEC 
        public string? Colors { get; set; } //  MATERIAL_COLOR
        public string? ColorComment { get; set; } //  COLOR_COMMENT
        public string? Memo { get; set; } //  MEMO
        public string? DevFactoryNo { get; set; }
    }

    public class SpecItemByDIdSearchParameter
    {
        public string SpecDId { get; set; }
        public string DevFactoryNo { get; set; } 
    }

    public class PGTSpec5SheetsUpdateParameter
    {
        public List<HeadDataParameter> HeadData { get; set; } // 改為 List
        public List<SpecItemUpdateParameter> UpperData { get; set; } = new List<SpecItemUpdateParameter>();
        public List<SpecItemUpdateParameter> SoleData { get; set; } = new List<SpecItemUpdateParameter>();
        public List<SpecItemUpdateParameter> OtherData { get; set; } = new List<SpecItemUpdateParameter>();
    }

    public class HeadDataParameter
    {
        public string? SpecMId { get; set; } // 要更新的 SPEC_M_ID
        public string? PgtColorName { get; set; }
        public string? RefDevNo { get; set; }
        public string? MoldNo1 { get; set; }
        public string? MoldNo2 { get; set; }
        public string? MoldNo3 { get; set; }
        public string? RemarksSpec { get; set; }
        public string? RemarksProhibit { get; set; }
        public string? MailTo { get; set; }   
        public string? MailCc { get; set; }   
    }

    public class SpecItemUpdateParameter
    {
        public decimal? Sort { get; set; } // material_sort
        public string? No { get; set; } // parts_no
        public string? ActPartNo { get; set; } // act_part_no
        public string? Type { get; set; } // material_new
        public string? Parts { get; set; } // parts
        public string? Detail { get; set; } // detail
        public string? ProcessMk { get; set; } // process_mk
        public string? Material { get; set; } // material
        public string? Recycle { get; set; } // recycle
        public string? MaterialComment { get; set; } // mat_comment
        public string? Standard { get; set; } // standard
        public string? Agent { get; set; } // agent
        public string? Supplier { get; set; } // supplier
        public string? QuoteSupplier { get; set; } // quote_supplier
        public string? Hcha { get; set; } // hcha
        public string? Sec { get; set; } // sec
        public string? Colors { get; set; } // material_color
        public string? ColorComment { get; set; } // clr_comment
        public string? Memo { get; set; } // memo
    }
}
