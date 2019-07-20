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
        
        protected  readonly string _prjName = string.Empty;
        protected readonly string _prjGuid = string.Empty;
        protected Project TempProject { get; set; }

        public Project Project { get; internal set; }

        internal ProjectParser(string prjName = "", string prjGuid = "")
        {
            _prjName = prjName;
            _prjGuid = prjGuid;
        }

        protected override bool PreParsing()
        {
            Project = null;
            return base.PreParsing();
        }
    }
}
