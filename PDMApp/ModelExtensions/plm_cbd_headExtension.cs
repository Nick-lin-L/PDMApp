using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Models
{
    public partial class plm_cbd_head
    {
        [NotMapped]
        public plm_cbd_item Upper { get; set; }
        [NotMapped]
        public plm_cbd_item Sole { get; set; }
        [NotMapped]
        public plm_cbd_item Other { get; set; }
        [NotMapped]
        public plm_cbd_moldcharge plm_cbd_moldcharge { get; set; }
    }
}