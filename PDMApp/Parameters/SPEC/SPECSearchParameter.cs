namespace PDMApp.Parameters.SPEC
{
    public class SPECSearchParameter
    {
        // 接收使用者查詢的參數
#nullable enable
        public string? Brand { get; set; }
        public string? EntryMode { get; set; }  
        public string? Season { get; set; }     
        public string? ItemNo { get; set; }     
        public string? DevelopmentNo { get; set; }     
        public string? ColorCode { get; set; }    
        public string? DevelopmentColorNo { get; set; }   
        public string? Stage { get; set; }      
        public string? LastNo { get; set; }     
        public string? PartName { get; set; }   
        public string? Material { get; set; }   
        public string? MaterialColor { get; set; } 
        public string? Supplier { get; set; }  
        public string? HeelHeight { get; set; } 
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }

    public class SPECDetailSearchParameter
    {
        public string? SpecMId { get; set; }
        public string? PartName { get; set; }
        public string? Material { get; set; }
        public string? MaterialColor { get; set; }
        public string? Supplier { get; set; }
        public string? HeelHeight { get; set; }
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }

    public class SPECExportSearchParameter
    {
        public string? SpecMId { get; set; }  
    }


    public class DevelopmentFactoryParameter
    {
        public string? DevFactoryNo { get; set; }
    }
}
