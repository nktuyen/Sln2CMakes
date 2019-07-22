using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class VcProject : Project
    {
        public List<VcProjectConfigurationItem> ConfigurationItems { get; internal set; }
        public List<SourceFile> SourceFileItems { get; internal set; }
        public List<HeaderFile> HeaderFileItems { get; internal set; }
        internal VcProject(string name = "", string guid = ""): base(name, guid)
        {
            ConfigurationItems = new List<VcProjectConfigurationItem>();
            HeaderFileItems = new List<HeaderFile>();
            SourceFileItems = new List<SourceFile>();

            EnvironmentVariables.Add("$(ProjectDir)", string.Empty);
            EnvironmentVariables.Add("$(ProjectName)", string.Empty);
            EnvironmentVariables.Add("$(ProjectExt)", string.Empty);
            EnvironmentVariables.Add("$(ProjectFileName)", string.Empty);
            EnvironmentVariables.Add("$(ProjectGuid)", string.Empty);
            EnvironmentVariables.Add("$(ProjectPath)", string.Empty);
        }

        internal VcProjectConfigurationItem FindConfiguration(string name)
        {
            if(ConfigurationItems.Count < 0)
            {
                return null;
            }

            foreach(VcProjectConfigurationItem config in ConfigurationItems)
            {
                if(string.Compare(config.Name, name, true) == 0)
                {
                    return config;
                }
            }

            return null;
        }

        internal override void UpdateEnvironmentVariables()
        {
            base.UpdateEnvironmentVariables();

            EnvironmentVariables["$(ProjectDir)"] = Utilities.Instance.GetFileDirectory(AbsolutePath, true);
            EnvironmentVariables["$(ProjectName)"] = Name;
            EnvironmentVariables["$(ProjectExt)"] = Utilities.Instance.GetFileExtension(AbsolutePath);
            EnvironmentVariables["$(ProjectFileName)"] = Utilities.Instance.GetFileName(AbsolutePath);
            EnvironmentVariables["$(ProjectGuid)"] = Guid;
            EnvironmentVariables["$(ProjectPath)"] = AbsolutePath;

            foreach(KeyValuePair<string,string> envVar in this.Solution.EnvironmentVariables)
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

            foreach (VcProjectConfigurationItem configuration in ConfigurationItems)
            {
                configuration.UpdateEnvironmentVariables();
            }
        }
    }
}
