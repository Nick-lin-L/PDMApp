using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaField
    {
        public MetaField()
        {
            MetaExtfieldMetaFields = new HashSet<MetaExtfield>();
            MetaExtfieldRefMetaFields = new HashSet<MetaExtfield>();
            TplSampleData = new HashSet<TplSampleDatum>();
        }

        public string MetaFieldId { get; set; }
        public string MetaObjId { get; set; }
        public string MetaFieldName { get; set; }
        public string MetaFieldColumn { get; set; }
        public decimal MetaFieldSeq { get; set; }
        public string MetaFieldComment { get; set; }
        public string MetaFieldDatatype { get; set; }
        public decimal MetaFieldTotwidth { get; set; }
        public decimal MetaFieldDecwidth { get; set; }
        public string MetaFieldAllownull { get; set; }
        public string MetaFieldDefault { get; set; }
        public string MetaFieldAuto { get; set; }
        public string MetaFieldContent { get; set; }
        public string MetaFieldSysdefine { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaObj MetaObj { get; set; }
        public virtual ICollection<MetaExtfield> MetaExtfieldMetaFields { get; set; }
        public virtual ICollection<MetaExtfield> MetaExtfieldRefMetaFields { get; set; }
        public virtual ICollection<TplSampleDatum> TplSampleData { get; set; }
    }
}
