using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class ProjectItem : NamedObject
    {
        public ProjectItem Parent { get; internal set; }
        internal Dictionary<string,string> EnvironmentVariables { get; set; }
        internal ProjectItem(string name = "") : base(name)
        {
            EnvironmentVariables = new Dictionary<string, string>();
        }

        internal virtual void UpdateEnvironmentVariables()
        {
            if (null != this.Parent) {
                foreach (KeyValuePair<string, string> envVar in this.Parent.EnvironmentVariables)
                {
                    if (!this.EnvironmentVariables.ContainsKey(envVar.Key))
                    {
                        this.EnvironmentVariables.Add(envVar.Key, envVar.Value);
                    }
                    else
                    {
                        this.EnvironmentVariables[envVar.Key] = envVar.Value;
                    }
                }
            }
        }
    }
}
