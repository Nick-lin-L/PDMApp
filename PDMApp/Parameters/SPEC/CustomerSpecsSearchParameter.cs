using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.SPEC
{
    public class CustomerSpecsSearchParameter
    {
#nullable enable
        //[Required]
        //public string? SpecMId { get; set; }
        public string? Season { get; set; }
        public string? WorkingName { get; set; }
        public string? DevelopmentNo { get; set; }
        public string? Colorway { get; set; }
        public string? LastUpdate { get; set; }
        public string? LoginFactory { get; set; }
        public string? Stage { get; set; }

        //        public int PageNumber { get; set; } = 1; // 預設為第1頁
        //        public int PageSize { get; set; } = 10; // 預設每頁10筆
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }

    public class CustomerInitialParameter
    {
        public string? DevFactoryNo { get; set; }
    }

    public class CustomerImportParameter
    {
        public UIParameter? UIParameter { get; set; }
        public List<ExcelParameter>? ExcelParameter { get; set; }
    }

    public class UIParameter
    {
        public string? DevelopmentNo { get; set; }
        public string? DevelopmentColorNo { get; set; }
        public string? Stage { get; set; }
    }

    public class ExcelParameter
    {
        public string? Sort { get; set; }
        public string? Group { get; set; }
        public string? No { get; set; }
        public string? New { get; set; }
        public string? Parts { get; set; }
        public string? Detail { get; set; }
        public string? ProcessMk { get; set; }
        public string? Material { get; set; }
        public string? Recycle { get; set; }
        public string? Type { get; set; }
        public string? Processing { get; set; }
        public string? Effect { get; set; }
        public string? ReleasePaper { get; set; }
        public string? BaseColor { get; set; }
        public string? MtrComment { get; set; }
        public string? Standard { get; set; }
        public string? Agent { get; set; }
        public string? Supplier { get; set; }
        public string? Hcha { get; set; }
        public string? Sec { get; set; }
        public string? MaterialColor { get; set; }
        public string? ClrComment { get; set; }
    }
}

