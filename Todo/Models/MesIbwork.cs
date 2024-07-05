using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MesIbwork
    {
        public string Werks { get; set; }
        public string Aufnr { get; set; }
        public string Timestamp { get; set; }
        public string Auart { get; set; }
        public string Plnbez { get; set; }
        public decimal Gamng { get; set; }
        public string Meins { get; set; }
        public string Astnr { get; set; }
        public string AstnrTxt { get; set; }
        public string Vbeln { get; set; }
        public string Posnr { get; set; }
        public string ProdBatch { get; set; }
        public string SoSize { get; set; }
        public string WoSize { get; set; }
        public decimal LeftQty { get; set; }
        public decimal RightQty { get; set; }
        public string Gltrp { get; set; }
        public string Gstrp { get; set; }
        public decimal Uebto { get; set; }
        public char Uebtk { get; set; }
        public string SgtScat { get; set; }
        public char Rcode { get; set; }
        public string Verid { get; set; }
        public string Aufld { get; set; }
        public char Stlan { get; set; }
        public string Stlal { get; set; }
        public string Plnnr { get; set; }
        public string Plnal { get; set; }
        public string ZzpartNo { get; set; }
        public string TransId { get; set; }
        public string DataBatchKey { get; set; }
        public string FileName { get; set; }
        public string Client { get; set; }
        public string SapOutboundTime { get; set; }
        public string MesSyncId { get; set; }
        public int Dataid { get; set; }
        public string CreateTime { get; set; }
        public string CreateUser { get; set; }
        public string ProcessTime { get; set; }
        public char? ProcessMk { get; set; }
        public string ProcessErrmsg { get; set; }
        public string ProcessUser { get; set; }
    }
}
