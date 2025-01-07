using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.FactorySpec
{
    public class FactorySearchParameter
    {
        //接收user查詢的參數
#nullable enable
        //public string? SpecMId { get; set; }
        public string? Factory { get; set; }
        public string? EntryMode { get; set; }
        public string? Season { get; set; }
        //[Required]
        public string? Year { get; set; }
        public string? ItemNo { get; set; }
        public string? ColorNo { get; set; }
        public string? DevNo { get; set; }
        public string? Devcolorno { get; set; }
        [Required]
        public string? Stage { get; set; } 
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }
    // 新增 FactorySpec5SheetsSearchParameter 類別
    public class FactorySpec5SheetsSearchParameter
    {
        public string? SpecMId { get; set; }
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }
}
