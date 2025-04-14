using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.Basic
{
    public class ShoeShapeParameter
    {
        public string? ProductMId { get; set; }
        public string? Season { get; set; }
        public string? WorkingName { get; set; }
        public string? DevelopmentNo { get; set; }
        public string? Colorway { get; set; }
        public string? LastUpdate { get; set; }

        public PaginationParameter Pagination { get; set; } = new PaginationParameter();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var hasAnyValue = GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string))
                .Select(p => (string?)p.GetValue(this))
                .Any(v => !string.IsNullOrWhiteSpace(v));

            if (!hasAnyValue)
            {
                yield return new ValidationResult("Please enter at least one search condition.", new[] { nameof(ProductMId) });
            }
        }
    }
}
