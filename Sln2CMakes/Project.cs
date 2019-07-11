using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    public class Project : Model
    {
        public string Path { get; internal set; }
        public string Guid { get; internal set; }
        public readonly List<string> IncludeDirectories = new List<string>();
        public readonly List<string> HeaderFiles = new List<string>();
        public readonly List<string> SourceFiles = new List<string>();
        public readonly List<string> Files = new List<string>();
        internal Project(string name = "")
        {
            Name = name;
        }
    }
}
