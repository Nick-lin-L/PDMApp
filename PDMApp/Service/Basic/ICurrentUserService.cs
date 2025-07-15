using PDMApp.Utils.BasicProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public interface ICurrentUserService
    {
        long? UserId { get; }
        string PccUid { get; }
        string Email { get; }
        string Name { get; }
        string NameEn { get; }
    }

}
