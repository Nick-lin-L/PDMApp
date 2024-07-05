using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifObmpsSche
    {
        public string Timestamp { get; set; }
        public string Del12 { get; set; }
        public string ProdBatch { get; set; }
        public string Werks { get; set; }
        public string Arbpl { get; set; }
        public string Plnbez { get; set; }
        public string Vbeln { get; set; }
        public string Posnr { get; set; }
        public decimal? Gamng { get; set; }
        public string Gmein { get; set; }
        public string Gstrs { get; set; }
        public string Gltrs { get; set; }
        public string C1Start { get; set; }
        public string C2Start { get; set; }
        public string C3Start { get; set; }
        public string Verid { get; set; }
        public string OrType { get; set; }
        public decimal? ZlQty { get; set; }
        public decimal? ZrQty { get; set; }
        public string FileName { get; set; }
        public string RecMk { get; set; }
    }
}
