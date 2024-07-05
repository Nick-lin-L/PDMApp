using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifShippingKindDatum
    {
        public string Key { get; set; }
        public string KindNo { get; set; }
        public string KindDesc { get; set; }
        public string Folder { get; set; }
        public string Mixpacket { get; set; }
    }
}
