using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaMdlobj
    {
        public MetaMdlobj()
        {
            MetaObjbls = new HashSet<MetaObjbl>();
        }

        public string MetaMdlobjId { get; set; }
        public string MetaMdlId { get; set; }
        public string MetaMdlobjObj { get; set; }
        public string MetaMdlobjSave { get; set; }
        public string MetaMdlobjVosql { get; set; }
        public string MetaMdlobjUpobj { get; set; }
        public string MetaMdlobjUplink { get; set; }
        public string MetaMdlobjOwner { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaMdl MetaMdl { get; set; }
        public virtual ICollection<MetaObjbl> MetaObjbls { get; set; }
    }
}
