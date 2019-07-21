using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class VcProjectLinkingDefintion : ProjectItem
    {
        public readonly List<string> Libraries ;
        public string OutputFile { get; internal set; }
        internal VcProjectLinkingDefintion():base("Link")
        {
            Libraries = new List<string>();
        }

        internal virtual void SetLibraries(string libraries)
        {
            string[] libs = libraries.Split(';');
            Libraries.Clear();
            foreach(string s in libs)
            {
                Libraries.Add(s);
            }
        }
    }
}
