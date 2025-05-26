using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Models
{
    public partial class work_order_head
    {
        [Column("xmin")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // xmin 欄位
        public uint RowVersion { get; set; }
    }
}