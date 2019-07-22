using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Vs
{
    class ProjectParser : FileParser
    {
        

        protected Project TempProject { get; set; }

        public Project Project { get; internal set; }

        internal ProjectParser()
        {

        }

        protected override bool PreParsing()
        {
            Project = null;
            return base.PreParsing();
        }
    }
}
