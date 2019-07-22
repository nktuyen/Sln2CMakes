using System;
using System.Collections.Generic;
using System.IO;
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

        internal override void UpdateEnvironmentVariables()
        {
            base.UpdateEnvironmentVariables();

            List<string> oldInc = IncludeDirectories;
            IncludeDirectories = new List<string>();
            foreach(string dir in oldInc)
            {
                StringBuilder s = new StringBuilder(dir);
                foreach(KeyValuePair<string,string> envVar in EnvironmentVariables)
                {
                    s.Replace(envVar.Key, envVar.Value);
                }
                string res = s.ToString();
                if (res.IndexOf(":") > 0)
                {

                }
                else
                {
                    if (EnvironmentVariables.ContainsKey("$(ProjectDir)"))
                    {
                        res = Path.GetFullPath(EnvironmentVariables["$(ProjectDir)"] + res);
                    }
                }
                IncludeDirectories.Add(res);
            }

            List<string> oldPreprocessors = Preprocessors;
            Preprocessors = new List<string>();
            foreach(string processor in oldPreprocessors)
            {
                StringBuilder s = new StringBuilder(processor);
                foreach (KeyValuePair<string, string> envVar in EnvironmentVariables)
                {
                    s.Replace(envVar.Key, envVar.Value);
                }
                string res = s.ToString();
                Preprocessors.Add(res);
            }
        }

        internal virtual void AddIncludeDirectories(string dirs)
        {
            //IncludeDirectories.Clear();
            string[] ss = dirs.Split(';');
            foreach(string s in ss)
            {
                IncludeDirectories.Add(s);
            }
        }

        internal virtual void AddPreprocessors(string preprocessors)
        {
            //Preprocessors.Clear();
            string[] ss = preprocessors.Split(';');
            foreach(string s in ss)
            {
                Preprocessors.Add(s);
            }
        }
    }
}
