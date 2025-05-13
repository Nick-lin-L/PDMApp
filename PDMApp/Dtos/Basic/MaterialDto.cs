using System;
using System.Text.Json.Serialization;

namespace PDMApp.Dtos.Basic
{
    public class MaterialDto
    {
        [JsonIgnore]
        public string? FactNo { get; set; }
        public string? MatId { get; set; }
        public string? Attyp { get; set; }
        public string? SerpMatNo { get; set; }
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
        public string? Status { get; set; }
        public string? StopDate { get; set; }  
        public string? Memo { get; set; }
        [JsonConverter(typeof(PDMApp.Utils.Converters.DateTimeConverterHms))]
        public DateTime? ModifyTime { get; set; }
        public string? ModifyUser { get; set; }
        public char? Locked { get; set; }
        public string? OrderStatus { get; set; }
        public string? TransMsg { get; set; }
    }

    public class ComboDto
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class MClassDto
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class ExportFileResponseDto
    {
        public string FileName { get; set; }
        public string FileContent { get; set; } // Base64 字串
    }


}
