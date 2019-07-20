using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    class VcProjectParser : ProjectParser
    {
        internal VcProjectParser(string prjName = "", string prjGuid = "") : base(prjName, prjGuid)
        {

        }
    }
}
