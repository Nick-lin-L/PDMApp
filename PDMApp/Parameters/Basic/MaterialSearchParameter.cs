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

    public class MatIdParameter
    {
        public string MatId { get; set; }
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
        public string? SerpMatNo { get; set; }
    }

    public class MaterialSubmitParameter
    {
        public string MatId { get; set; }
    }

    public class MaterialPurchaseParameter
    {
        public string SerpMatNo { get; set; }
        public string MatNo { get; set; }
        public string OrderQty { get; set; }
        public string Price { get; set; }
        public string RequiredDate { get; set; }
        public string Season { get; set; }
        public string Stage { get; set; }
        public string Model { get; set; }
        public string ArticleNo { get; set; }
        public string Purpose { get; set; }
        public string SrDetails { get; set; }
        public string BuyerNote { get; set; }
        public string MaterialCategory { get; set; }
        public string ColorSource { get; set; }
        public string SampleOrder { get; set; }
        public string SoVersion { get; set; }
        public string PartType { get; set; }
        public string PartNo { get; set; }
        public string PartName { get; set; }
        public string PartNameZhTw { get; set; }
        public string Gender { get; set; }
        public string SizeMap { get; set; }
        public string McsNo { get; set; }
        public string OneCOneSNo { get; set; }
        public string Memo { get; set; }
        public string ProcNote { get; set; }
        public string TypeDefinition { get; set; }
        public string Category { get; set; }
        public string DevStyle { get; set; }
        public string MoldNo { get; set; }
        public string Size { get; set; }
        public string LastNo { get; set; }
        public string Brand { get; set; }
        public string ProdCode { get; set; }
        public string MainFactory { get; set; }
        public string Team { get; set; }
        public string Pm { get; set; }
        public string MatFullNm { get; set; }
        public string ColorNo { get; set; }
        public string ColorNm { get; set; }
        public string Uom { get; set; }
        public string ScmBclassNo { get; set; }
        public string ScmMclassNo { get; set; }
        public string? DevFactoryNo { get; set; }
    }


}
