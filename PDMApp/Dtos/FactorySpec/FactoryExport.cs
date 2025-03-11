using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dtos.FactorySpec
{  
    public class ItemSheetDTO
    {
        public string? SpecMId { get; set; }    //ID
        public int? Seqno { get; set; }
        public string? PartClass { get; set; }
        public string? MailTo { get; set; }
        public string? MailCC { get; set; }
        public string? Stage { get; set; }
        public string? CreateTime { get; set; }
        public string? DevNo { get; set; }
        public string? RefDevNo { get; set; }
        public string? ItemNameEng { get; set; }
        public string? ItemNo { get; set; }
        public string? ColorNo { get; set; }
        public string? SampleSize { get; set; }
        public decimal? HeelHeight { get; set; }
        public string? ColorNameChn { get; set; }
        public string? ColorEng { get; set; }
        public string? FactoryMoldNo1 { get; set; }
        public string? FactoryMoldNo2 { get; set; }
        public string? FactoryMoldNo3 { get; set; }
        public string? LastNo1 { get; set; }
        public string? LastNo2 { get; set; }
        public string? LastNo3 { get; set; }
        public string? CreateUser { get; set; }
        public string? Type { get; set; }      //Newmaterial
        public string? Parts { get; set; }
        public string? No { get; set; }
        public string? Material { get; set; }    // 材料
        public string? SubMaterial { get; set; }    // 材料
        public string? Colors { get; set; }
        public string? Standard { get; set; }
        public string? Hcha { get; set; }
        public string? Sec { get; set; }
        public string? Supplier { get; set; }    // 供應商
        public object ActNo { get; internal set; }
        public string RemarksProhibit { get; internal set; }
    }
    public class StandardSheetDTO
    {
        public string? SpecMId { get; set; }    // 範本ID
        public string Stage { get; internal set; }
        public string CreateTime { get; internal set; }
        public string DevNo { get; internal set; }
        public string RefDevNo { get; internal set; }
        public string ItemNameEng { get; internal set; }
        public string ShoeBag { get; internal set; }
        public string SampleSize { get; internal set; }
        public string ItemNo { get; internal set; }
        public string ColorNo { get; internal set; }
        public decimal? HeelHeight { get; internal set; }
        public string ColorNameChn { get; internal set; }
        public int? Seq { get; internal set; }
        public string ColorEng { get; internal set; }
        public string FactoryMoldNo1 { get; internal set; }
        public string? FactoryMoldNo2 { get; set; }
        public string? FactoryMoldNo3 { get; set; }
        public string CreateUser { get; internal set; }
        public string LastNo1 { get; internal set; }
        public string? LastNo2 { get; set; }
        public string? LastNo3 { get; set; }
        public string ShoeLaceLength { get; internal set; }
        public string Size { get; internal set; }
        public string ShoeBox { get; internal set; }
        public string GelRear { get; internal set; }
        public string Toekeeper { get; internal set; }
        public string GelFore { get; internal set; }
        public int? Seqno { get; internal set; }
    }
}

