using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class VcProjectCompilationDefintion : ProjectItem
    {
        public List<string> IncludeDirectories { get; internal set; }
        public List<string> Preprocessors { get; internal set; }
        internal VcProjectCompilationDefintion(string name = "") : base(name)
        {
            IncludeDirectories = new List<string>();
            Preprocessors = new List<string>();
        }

        internal virtual void SetIncludeDirectories(string dirs)
        {
            IncludeDirectories.Clear();
            string[] ss = dirs.Split(';');
            foreach(string s in ss)
            {
                IncludeDirectories.Add(s);
            }
        }

        internal virtual void SetPreprocessors(string preprocessors)
        {
            Preprocessors.Clear();
            string[] ss = preprocessors.Split(';');
            foreach(string s in ss)
            {
                Preprocessors.Add(s);
            }
        }
    }
}
