using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Models
{
    public partial class global_users
    {
        [Column("xmin")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        public uint RowVersion { get; set; }
    }
}