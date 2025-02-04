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
        public ICollection<plm_cbd_item> _plm_cbd_item { get; set; } = new List<plm_cbd_item>();
        [NotMapped]
        public IList<plm_cbd_item> Upper
        {
            get
            {
                return _plm_cbd_item == null ? null : _plm_cbd_item.Where(x => x.partclass == "A").ToList();
            }
        }
        [NotMapped]
        public IList<plm_cbd_item> Sole
        {
            get
            {
                return _plm_cbd_item == null ? null : _plm_cbd_item.Where(x => x.partclass == "B").ToList();
            }
        }
        [NotMapped]
        public IList<plm_cbd_item> Other
        {
            get
            {
                return _plm_cbd_item == null ? null : _plm_cbd_item.Where(x => x.partclass == "C").ToList();
            }
        }
        [NotMapped]
        public ICollection<plm_cbd_moldcharge> _plm_cbd_moldcharge { get; set; }
    }
}