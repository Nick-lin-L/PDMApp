using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dtos.FactorySpec
{
    // 基本規格 DTO
    public class SpecBasicDTO
    {
        [JsonIgnore]
        public string? SpecMId { get; set; }
        public string? DevNo { get; set; }
        public string? DevColorNo { get; set; }
        public string? Stage { get; set; }
        public decimal? Ver { get; set; }
        public string? EntryMode { get; set; }
        public string? SampleSize { get; set; }
        public string? Year { get; set; }
        public string? Season { get; set; }
        public string? CategoryKbn { get; set; }
        public string? Mode { get; set; }
        public string? ItemNo { get; set; }
        public string? ItemNameEng { get; set; }
        public string? ItemNameJpn { get; set; }
        public string? ColorNameEng { get; set; }
        public string? ColorNameJpn { get; set; }
        public string? SizeRun { get; set; }
        public string? Factory { get; set; }
        public string? FactoryUpper { get; set; }
        public decimal? HeelHeight { get; set; }
        public string? Lasting { get; set; }
        public decimal? RequstWeight { get; set; }
        public string? LastNo1 { get; set; }
        public string? LastNo2 { get; set; }
        public string? LastNo3 { get; set; }
        public string? UpperSozaiCode { get; set; }
        public string? SoleSozaiCode { get; set; }
        public string? ColorNameChn { get; set; }
        public string? RefDevNo { get; set; }
        public string? FactoryMoldNo1 { get; set; }
        public string? FactoryMoldNo2 { get; set; }
        public string? FactoryMoldNo3 { get; set; }
        public string? MailTo { get; set; }
        public string? MailCC { get; set; }

        public string? ColorNo { get; set; }
        public string? SizeConversionType { get; set; }
        public string? SpecialConversion { get; set; }
        public string? Remarks { get; set; }
        public string? RemarksProhibit { get; set; }
       
    }

    // Upper 規格 DTO
    public class SpecUpperDTO
    {
        [JsonIgnore]
        public string? SpecMId { get; set; }
        public string? No { get; set; }
        public string? Type { get; set; }      //Newmaterial
        public string? Parts { get; set; }
        public string? MoldNo { get; set; }
        public string? FactoryMoldNo { get; set; }
        public string? MaterialNo { get; set; }
        public string? Material { get; set; }
        public string? SubMaterial { get; set; }
        public string? Standard { get; set; }
        public string? Supplier { get; set; }
        public string? Hcha { get; set; }
        public string? Sec { get; set; }
        public string? Colors { get; set; }
        public string? DataId { get; set; }
        public int? SeqNo { get; set; } //seq
        public string? ActNo { get; set; }
        public string? Width { get; set; }
        public string? Memo { get; set; }
        [JsonIgnore]
        public string? PartClass { get; set; }
    }

    // 標準規格 DTO
    public class SpecStandardDTO
    {
        [JsonIgnore]
        public string? SpecMId { get; set; }
        public int? Seq { get; set; }
        public string? Size { get; set; }
        public string? ShoeLaceLength { get; set; }
        public string? ShoeBox { get; set; }
        public string? GelFore { get; set; }
        public string? GelRear { get; set; }
        public string? Toekeeper { get; set; }
        public string? ShoeBag { get; set; }
        public string? Itemval7 { get; set; }
        public string? Itemval8 { get; set; }
        public string? Itemval9 { get; set; }
        public string? Memo { get; set; }

    }

    // 多頁結果 DTO
    public class MultiPageResultDTO
    {
        public IEnumerable<SpecBasicDTO>? BasicData { get; set; }
        public IEnumerable<SpecUpperDTO>? UpperData { get; set; }
        public IEnumerable<SpecUpperDTO>? SoleData { get; set; }
        public IEnumerable<SpecUpperDTO>? OtherData { get; set; }
        public IEnumerable<SpecStandardDTO>? StandardData { get; set; }
    }

    // Header DTO
    public class FactorySpecHeaderDto
    {
        [JsonIgnore] // 標記此欄位不要返回前端
        public string? Year { get; set; }
        [JsonIgnore]
        public string? Season { get; set; }
        [JsonIgnore]
        public string? EntryMode { get; set; }
        [JsonIgnore]
        public string? Factory { get; set; }
        public string? SpecMId { get; set; }
        public string? ItemNo { get; set; }
        public string? DevNo { get; set; }
        public string? DevColorDispName { get; set; }
        public string? ColorNo { get; set; }
        public string? Stage { get; set; }
        public string? Fty1 { get; set; }
        public string? Fty2 { get; set; }
        public string? Fty3 { get; set; }
        public decimal? Ver { get; set; }
        public decimal? VssVer { get; set; }
        public DateTime? SpecUpdateDate { get; set; }
        public string? SpecUpdateUser { get; set; }
    }
}

