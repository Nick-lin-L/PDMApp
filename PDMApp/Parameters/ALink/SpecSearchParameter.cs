using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDMApp.Parameters.ALink
{
    public class SpecSearchParameter : IValidatableObject
    {
        //接收user查詢的參數
#nullable enable
        public string? SpecMId { get; set; }
        [Required]
        public string? Factory { get; set; }
        public string? EntryMode { get; set; }
        [Required]
        public string? Season { get; set; }
        public string? Year { get; set; }
        public string? ItemNo { get; set; }
        public string? ColorNo { get; set; }
        public string? DevNo { get; set; }
        public string? Devcolorno { get; set; }
        public string? Stage { get; set; }
        public string? CustomerKbn { get; set; }
        public string? ModeName { get; set; }
        public string? OutMoldNo { get; set; }
        public string? LastNo { get; set; }
        public string? ItemNameENG { get; set; }
        public string? ItemNameJPN { get; set; }
        public string? PartName { get; set; } // PDM_SPEC_ITEM.PARS
        public string? PartNo { get; set; } // PDM_SPEC_ITEM.ACT_NO
        public string? MatColor { get; set; } // PDM_SPEC_ITEM.colors
        public string? Material { get; set; }
        public string? SubMaterial { get; set; }
        public string? Supplier { get; set; }
        public string? Width { get; set; }
        public string? HeelHeight { get; set; }

        //public int PageNumber { get; set; } = 1; // 預設為第1頁
        //public int PageSize { get; set; } = 10; // 預設每頁10筆

        //public ICollection<PaginationParameter> paginationParameter { get; set; } 
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var hasAnyValue = GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string))
                .Select(p => (string?)p.GetValue(this))
                .Any(v => !string.IsNullOrWhiteSpace(v));

            if (!hasAnyValue)
            {
                yield return new ValidationResult("Please enter at least one search condition.", new[] { nameof(SpecMId) });
            }
        }
    }
}
