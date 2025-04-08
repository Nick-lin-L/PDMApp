using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class ModuleCrudPermissionDto
    {
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Export { get; set; }
        public bool Import { get; set; }
        public bool Permission1 { get; set; }
        public bool Permission2 { get; set; }
        public bool Permission3 { get; set; }
        public bool Permission4 { get; set; }

    }
}
