using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Sln2CMakes
{
    public class ProjectParser : FileParser
    {
        
        protected  readonly string _prjName = string.Empty;

        public Project Project { get; internal set; }

        internal ProjectParser(string prjName = "")
        {
            _prjName = prjName;
        }

        protected override bool PreParsing()
        {
            Project = null;
            return base.PreParsing();
        }
    }
}
