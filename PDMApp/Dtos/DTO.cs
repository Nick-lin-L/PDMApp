using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos
{
    #nullable enable
    public class SpecBasicDTO
    {
        public string? DevNo { get; set; }
        public string? DevColorNo { get; set; }
        public string? Stage { get; set; }
        public decimal? Ver { get; set; }
        public string? EntryMode { get; set; }
        public string? SampleSize { get; set; }
        public string? Year { get; set; }
        public string? Season { get; set; }
        public string? CategoryKbn { get; set; }
        public string? MoldNo { get; set; }
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
        public string? ColorNo { get; set; }
        public string? SizeConversionType { get; set; }
        public string? SpecialConversion { get; set; }
        public string? Remarks { get; set; }
        public string? OutMoldNo { get; set; }
        public string? Shfactory { get; set; }
        public string? DevColorDispName { get; set; }
        public string? SpecMId { get; set; }
        public string? Cbdlockmk { get; set; }
        public string? ProductMId { get; set; }
        public string? ProductDId { get; set; }
        public string? pdm_Spec_ItemDtos { get; set; }
    }

    public class MultiPageResultDTO
    {
        public IEnumerable<SpecBasicDTO> BasicData { get; set; }
        public IEnumerable<SpecUpperDTO> UpperData { get; set; }
        public IEnumerable<SpecUpperDTO> SoleData { get; set; }
        public IEnumerable<SpecUpperDTO> OtherData { get; set; }
        public IEnumerable<SpecStandardDTO> StandardData { get; set; }
    }
     
    public class SpecUpperDTO
    {
        public string SpecDId { get; set; }
        public string SpecMId { get; set; }
        public string No { get; set; }
        public string Type { get; set; }      //Newmaterial
        public string Parts { get; set; }
        public string MoldNo { get; set; }
        public string FactoryMoldNo { get; set; }
        public string MaterialNo { get; set; }
        public string Material { get; set; }
        public string SubMaterial { get; set; }
        public string Standard { get; set; }
        public string Supplier { get; set; }
        public string Hcha { get; set; }
        public string Sec { get; set; }
        public string Colors { get; set; }
        public string DataId { get; set; }
        public int? SeqNo { get; set; } //seq
        public string ActNo { get; set; }
        public string Width { get; set; }
        public string Memo { get; set; }
        public string PartClass { get; set; }
    }


    public class SpecStandardDTO
    {
        public string DataId { get; set; }
        public string SpecMId { get; set; }
        public int? Seq { get; set; }
        public string Size { get; set; }
        public string ShoeLaceLength { get; set; }
        public string ShoeBox { get; set; }
        public string GelFore { get; set; }
        public string GelRear { get; set; }
        public string Toekeeper { get; set; }
        public string ShoeBag { get; set; }
        public string Itemval7 { get; set; }
        public string Itemval8 { get; set; }
        public string Itemval9 { get; set; }
        public string Memo { get; set; }

    }
}
