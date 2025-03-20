using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dtos.SPEC
{
    // Header DTO
    public class SPECHeaderDto
    {
        public string SpecMId { get; set; }
        public string Stage { get; set; }
        public string SampleFactory { get; set; }
        public string DevelopmentNo { get; set; }
        public string ItemNo { get; set; }
        public string Season { get; set; }
        public string DevelopmentColorNo { get; set; }
        public string ColorCode { get; set; }
        public string Colorway { get; set; }
        public string Last { get; set; }
    }

    public class SPECDetailDto
    {
        public decimal? Sort { get; set; }
        public string? PartsNo { get; set; }
        public string? Parts { get; set; }
        public string? Detail { get; set; }
        public string? MaterialNew { get; set; }
        public string? ProcessMk { get; set; }
        public string? Material { get; set; }
        public string? MatComment { get; set; }
        public string? Agent { get; set; }
        public string? Standard { get; set; }
        public string? Supplier { get; set; }
        public string? MatColor { get; set; }
        public string? ColorComment { get; set; }
        public string? Memo { get; set; }
    }

    public class SPECExportDto
    {
        public string Season { get; set; }
        public string Stage { get; set; }
        public string SampleFactory { get; set; }
        public string ItemNo { get; set; }
        public string DevelopmentNo { get; set; }
        public string ColorCode { get; set; }
        public string Colorway { get; set; }
        public string Last { get; set; }
        public string ArticleDescription { get; set; }
        public string PartsNo { get; set; }
        public string Parts { get; set; }
        public string Detail { get; set; }
        public string ProcessMk { get; set; }
        public string Material { get; set; }
        public string MatComment { get; set; }
        public string Agent { get; set; }
        public string Standard { get; set; }
        public string Supplier { get; set; }
        public string MaterialColor { get; set; }
        public string ColorComment { get; set; }
        public string Memo { get; set; }
        public string HCHA { get; set; }
        public string Sec { get; set; }
    }

    public class DevelopmentNoDto
    {
        public string? ProductMId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class DevelopmentColorNoDto
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class ComboDto
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}

