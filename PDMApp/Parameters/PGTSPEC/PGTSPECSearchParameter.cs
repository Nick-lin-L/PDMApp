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



    public class InsertSpecParameter
    {
        public string DevelopmentNo { get; set; }
        public string DevelopmentColor { get; set; }
        public string Stage { get; set; }
        public string DevFactoryNo { get; set; } // 工廠編號 
        public string SpecSource { get; set; }

    }

    public class CopyToSpecParameter
    {
        public string DevelopmentNo { get; set; }
        public string DevelopmentColor { get; set; }
        public string Stage { get; set; }
        public string DevFactoryNo { get; set; } // 開發工廠編號
        public string SpecMId { get; set; } // 被複製的 SPEC_M_ID
    }

    public class DevelopmentFactoryParameter
    {
        public string? DevFactoryNo { get; set; }
    }

    public class CheckoutSpecParameter
    {
        public string SpecMId { get; set; }
    }

    public class CheckinSpecParameter
    {
        public string SpecMId { get; set; }
    }

}
