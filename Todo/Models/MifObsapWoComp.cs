using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifObsapWoComp
    {
        public string Werks { get; set; }
        public string Aufnr { get; set; }
        public string Rsnum { get; set; }
        public string Posnr { get; set; }
        public string Timestamp { get; set; }
        public string Idnrk { get; set; }
        public decimal? Menge { get; set; }
        public string Meins { get; set; }
        public string Rgekz { get; set; }
        public string Component { get; set; }
        public string Erskz { get; set; }
        public string WerksIs { get; set; }
        public decimal? LeftQty { get; set; }
        public decimal? RightQty { get; set; }
        public string Vlsch { get; set; }
        public string Lgort { get; set; }
        public string Vornr { get; set; }
        public string Sgtrcat { get; set; }
        public string Charg { get; set; }
        public string FileName { get; set; }
        public string RecMk { get; set; }
        public string CreateTime { get; set; }
        public string CreateUser { get; set; }
        public string ProcessTime { get; set; }
        public char? ProcessMk { get; set; }
        public string ProcessErrmsg { get; set; }
        public string ProcessUser { get; set; }
    }
}
