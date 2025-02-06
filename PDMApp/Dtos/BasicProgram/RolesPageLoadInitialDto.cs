using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class RolesPageLoadInitialDto
    {
        public IEnumerable<pdm_factoryDto>? DevFactoryNo { get; set; }
    }
}
