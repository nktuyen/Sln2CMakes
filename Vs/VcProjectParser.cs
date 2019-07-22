using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    class VcProjectParser : ProjectParser
    {
        protected readonly string _prjName = string.Empty;
        protected readonly string _prjGuid = string.Empty;
        internal VcProjectConfigurationItem CurrentConfiguration { get; set; }
        internal VcProjectParser(string prjName = "", string prjGuid = "")
        {
            _prjName = prjName;
            _prjGuid = prjGuid;
        }
}
}
