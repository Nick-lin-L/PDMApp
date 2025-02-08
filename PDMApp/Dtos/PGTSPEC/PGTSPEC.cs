using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dtos.PGTSPEC
{
    
    // Header DTO
    public class PGTSPECHeaderDto
    {
        public string? SpecMId { get; set; }
        public string? Brand { get; set; }
        public string? DevelopmentNo { get; set; }
        public string? DevelopmentColorNo { get; set; }
        public string? ColorCode { get; set; }
        public string? Colorway { get; set; }
        public string? Stage { get; set; }
        public string? ModelName { get; set; }
        public int? Ver { get; set; }
        public string CheckoutMk { get; internal set; }
        public string CheckoutUser { get; internal set; }
        public string SpecLockMk { get; internal set; }
        [JsonConverter(typeof(PDMApp.Utils.Converters.DateTimeConverterHms))]
        public DateTime? UpdateDate { get; internal set; }
        public string UpdateUser { get; internal set; }
    }


    public class DevelopmentNoDto
    {
        public string? ProductMId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string? Brand { get; set; }
    }

    public class DevelopmentColorNoDto
    { 
        public string? ProductMId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class ComboDto
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class ComboDataDto
    {
        public IEnumerable<ComboDto> BrandCombo { get; set; } = new List<ComboDto>();
        public IEnumerable<ComboDto> SpecSourceCombo { get; set; } = new List<ComboDto>();
        public IEnumerable<ComboDto> StageCombo { get; set; } = new List<ComboDto>();
        public IEnumerable<DevelopmentNoDto> DevelopmentNoCombo { get; set; } = new List<DevelopmentNoDto>();
        public IEnumerable<DevelopmentColorNoDto> DevelopmentColorNoCombo { get; set; } = new List<DevelopmentColorNoDto>();
    }


}

