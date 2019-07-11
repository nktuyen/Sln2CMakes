using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    public class Solution : Model
    {
        public Version Version { get; internal set; }
        public readonly List<Project> Projects = new List<Project>();
        internal Solution(string name = "")
        {
            Name = name;
            Projects.Clear();
        }
    }
}
