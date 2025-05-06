using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class tblfadet
    {
        public string facode { get; set; }
        public string storerecorder { get; set; }
        public string storedeptcode { get; set; }
        public string locationid { get; set; }
        public int? qty { get; set; }
        public int? exsellqty { get; set; }
        public int? exaccqty { get; set; }
        public int? exscrapqty { get; set; }
        public string detnote { get; set; }
        public DateTime? fixdate { get; set; }
        public string fixby { get; set; }
        public string deptcode { get; set; }
        public string deptsname { get; set; }
        public string deptname { get; set; }
        public string note { get; set; }
        public int? isnotvalid { get; set; }
        public string FACode_StoreRecorder_StoreDeptCode_LocationID_Qty_ExSellQty_ExA { get; set; }
    }
}
