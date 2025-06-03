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
        public string? Development { get; set; }
        public string? Development_Color_No { get; set; }
        public string? Stage { get; set; }

        public string? Sort { get; set; }
        public string? Group { get; set; }
        public string? No { get; set; }
        public string? New { get; set; }
        public string? Parts { get; set; }
        public string? Detail { get; set; }
        public string? Puls { get; set; }
        public string? Recycle { get; set; }
        public string? Type { get; set; }
        public string? Material { get; set; }
        public string? Processing { get; set; }
        public string? Effect { get; set; }
        public string? Release_Paper { get; set; }
        public string? Base_Color { get; set; }
        public string? MTR_Comment { get; set; }
        public string? Standard { get; set; }
        public string? Agent { get; set; }
        public string? Supplier { get; set; }
        public string? HCHA { get; set; }
        public string? SEC { get; set; }
        public string? Material_Color { get; set; }
        public string? CLR_Comment { get; set; }


    }

}
