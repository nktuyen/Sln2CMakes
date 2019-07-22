using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class VcProjectPropertyGroup : ProjectItem
    {
        public ProjectConfigurationType ConfigurationType { get; internal set; }
        public string OutDir { get; internal set; }
        public string IntDir { get; internal set; }
        public string TargetName { get; internal set; }
        internal VcProjectPropertyGroup(string name = "" ) : base(name)
        {

        }

        internal override void UpdateEnvironmentVariables()
        {
            base.UpdateEnvironmentVariables();

            if (OutDir != string.Empty)
            {
                StringBuilder s = new StringBuilder(OutDir);
                foreach (KeyValuePair<string, string> envVar in this.EnvironmentVariables)
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
                OutDir = res;
            }

            if (IntDir != string.Empty)
            {
                StringBuilder s = new StringBuilder(IntDir);
                foreach (KeyValuePair<string, string> envVar in this.EnvironmentVariables)
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
                IntDir = res;
            }

            if (TargetName != string.Empty)
            {
                StringBuilder s = new StringBuilder(TargetName);
                foreach (KeyValuePair<string, string> envVar in this.EnvironmentVariables)
                {
                    s.Replace(envVar.Key, envVar.Value);
                }
                string res = s.ToString();
                TargetName = res;
            }
        }
    }
}
