using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifShoePlanqty
    {
        public string FactNo { get; set; }
        public string Yymm { get; set; }
        public string SecNo { get; set; }
        public string WorkDate { get; set; }
        public decimal? PlanQty { get; set; }
        public decimal? Worker { get; set; }
        public decimal? IndirectWorker1 { get; set; }
        public decimal? StdTime { get; set; }
        public decimal? IeQty { get; set; }
        public string DataTime { get; set; }
        public string ChgCode { get; set; }
        public string TargetId { get; set; }
        public string ModifyUser { get; set; }
        public string Arbpl { get; set; }
        public string Prodtype { get; set; }
        public decimal? OnDutyStd { get; set; }
        public decimal? RealQty { get; set; }
        public string ModifyTime { get; set; }
        public string CreateUser { get; set; }
        public string CreateTime { get; set; }
    }
}
