namespace PDMApp.Parameters.Basic
{
    public class MaterialSearchParameter
    {
        public string? Attyp { get; set; }
        public string? SerpMatNo { get; set; }
        public string? MatNo { get; set; }
        public string? MatFullNm { get; set; }
        public string? Status { get; set; }
        public string? OrderStatus { get; set; }
        public string? DevFactoryNo { get; set; }
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }

    public class MaterialCreateParameter
    {
        public string? Attyp { get; set; }
        public string? MatNo { get; set; }
        public string? MatNm { get; set; }
        public string? MatFullNm { get; set; }
        public string? Uom { get; set; }
        public string? ColorNo { get; set; }
        public string? ColorNm { get; set; }
        public string? Standard { get; set; }
        public string? CustNo { get; set; }
        public string? Matnr { get; set; }
        public string? ScmBclassNo { get; set; }
        public string? ScmMclassNo { get; set; }
        public string? ScmSclassNo { get; set; }
        public string? Memo { get; set; }
        public string? DevFactoryNo { get; set; }
        public string? Status { get; set; }
    }

    public class MaterialUpdateParameter
    {
        public string? MatId { get; set; } 
        public string? Attyp { get; set; }
        public string? MatNo { get; set; }
        public string? MatNm { get; set; }
        public string? MatFullNm { get; set; }
        public string? Uom { get; set; }
        public string? ColorNo { get; set; }
        public string? ColorNm { get; set; }
        public string? Standard { get; set; }
        public string? CustNo { get; set; }
        public string? Matnr { get; set; }
        public string? ScmBclassNo { get; set; }
        public string? ScmMclassNo { get; set; }
        public string? ScmSclassNo { get; set; }
        public string? Memo { get; set; }
        public string? DevFactoryNo { get; set; }
        public string? Status { get; set; }
        public string? OrderStatus { get; set; }
    }

    public class MaterialSubmitParameter
    {
        public string MatId { get; set; }
    }

}
