using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Models
{
    public partial class work_order_item
    {
        [Column("xmin")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public uint RowVersion { get; set; }
    }
}