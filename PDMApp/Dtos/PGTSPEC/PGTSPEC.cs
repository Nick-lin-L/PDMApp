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
        public DateTime? UpdateDate { get; internal set; }
        public string UpdateUser { get; internal set; }
    }

    public class BrandDto
    {
        public string? Brand { get; set; }
    }

    public class DevelopmentNoDto
    {
        public string? ProductMId { get; set; }
        public string? DevelopmentNo { get; set; }
        public string? Brand { get; set; }
    }

    public class DevelopmentColorNoDto
    { 
        public string? ProductMId { get; set; }
        public string? DevelopmentColorNo { get; set; }
    }

    public class SpecSourceDto
    {
        public string? SpecSource { get; set; }
    }

    public class StageDto
    {
        public string Stage { get; set; }  
    }

    public class ComboDataDto
    {
        public IEnumerable<BrandDto> BrandCombo { get; set; } = new List<BrandDto>();
        public IEnumerable<SpecSourceDto> SpecSourceCombo { get; set; } = new List<SpecSourceDto>();
        public IEnumerable<StageDto> StageCombo { get; set; } = new List<StageDto>();
        public IEnumerable<DevelopmentNoDto> DevelopmentNoCombo { get; set; } = new List<DevelopmentNoDto>();
        public IEnumerable<DevelopmentColorNoDto> DevelopmentColorNoCombo { get; set; } = new List<DevelopmentColorNoDto>();
    }


}

