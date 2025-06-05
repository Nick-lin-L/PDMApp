#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.ProductionOrder
{
    public class ArtPoParameter
    {
        public class InitialParameter
        {
            public string? DevFactoryNo { get; set; }
        }
        public class QueryParameter
        {
            public string? DevFactoryNo { get; set; }
            public string? Brand { get; set; }
            public string? OrderNo { get; set; }
            public string? ModelName { get; set; }
            public string? DevelopmentNo { get; set; }
            public string? ArticleNo { get; set; }
            public string? Season { get; set; }
            public string? OrderStatus { get; set; }
            public PaginationParameter Pagination { get; set; } = new PaginationParameter();
        }

        public class QueryDetailParameter
        {
            public string? WkMId { get; set; }
        }
        public class QueryPickerParameter
        {
            public string? DevFactoryNo { get; set; }
            public string? Season { get; set; }
            public string? DevelopmentNo { get; set; }
            public string? ModelName { get; set; }
            public string? ColorName { get; set; }
            public string? ColorWay { get; set; }
        }

        public class MainDataParameter
        {
            public string? DevFactoryNo { get; set; }
            public string? WkMId { get; set; }
            public string? Brand { get; set; }
            public string? OrderNo { get; set; }
            public string? OrderPurchase { get; set; }
            public string? OrderKind { get; set; }
            public string? DevelopmentNo { get; set; }
            public string? Season { get; set; }
            public string? ModelName { get; set; }
            public string? ColorNo { get; set; }
            public string? ColorWay { get; set; }
            public string? Stage { get; set; }
            public string? OrderStatus { get; set; }
            public string? ArticleNo { get; set; }
            public string? Category { get; set; }
            public string? Gender { get; set; }
            public string? MoldNo { get; set; }
            public string? LastNo { get; set; }
            public string? LastWidth { get; set; }
            public string? ReqDate { get; set; }
            public string? Definition { get; set; }
            public string? CustomSr { get; set; }
            public string? CustomPm { get; set; }
            public string? SampleSize { get; set; }
            public string? FGType { get; set; }
            public string? DelMk { get; set; }
            public string? DelDate { get; set; }
            public string? Memo { get; set; }
            public string? StepMemo { get; set; }
            public string? SerpErrorMsg { get; set; }
            public string? Memo1 { get; set; }
            public string? Memo2 { get; set; }
            public string? Memo3 { get; set; }
            public string? Memo4 { get; set; }
            public string? Memo5 { get; set; }
            public string? Memo6 { get; set; }
            public string? Memo7 { get; set; }
            public string? Memo8 { get; set; }
            public string? Memo9 { get; set; }
            public string? Memo10 { get; set; }
            public string? Memo11 { get; set; }
            public string? Memo12 { get; set; }
            public string? Memo13 { get; set; }
            public string? Memo14 { get; set; }
            public string? Memo15 { get; set; }
            public string? Memo16 { get; set; }
            public string? Memo17 { get; set; }
            public string? Memo18 { get; set; }
            public string? Memo19 { get; set; }
            public string? Memo20 { get; set; }
            public string? StyleId { get; set; }
            public uint? RowVersion { get; set; }
        }

        public class DetailDataParameter
        {
            public string? DevFactoryNo { get; set; }
            public string? WkMId { get; set; }
            public uint? RowVersion { get; set; }
            public List<DetailData>? DetailData { get; set; } = new List<DetailData>();
        }
        public class DetailData
        {
            public string? WkDId { get; set; }
            public string? Sort { get; set; }
            public string? TransMk { get; set; }
            public string? ShoeKind { get; set; }
            public string? SizeNo { get; set; }
            public decimal? Qty { get; set; }
            public string? DelMk { get; set; } = "N";
            public uint? RowVersion { get; set; }
        }

        public class ProcessParameter
        {
            public string? WkMId { get; set; }
            public uint RowVersion { get; set; }
        }
        public class SubmitParameter
        {
            public string? WkMId { get; set; }
        }

        public class Process
        {

        }
    }
}