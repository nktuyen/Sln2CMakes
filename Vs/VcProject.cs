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

            foreach(VcProjectConfigurationItem configuration in ConfigurationItems)
            {
                configuration.UpdateEnvironmentVariables();
            }
        }
    }
}
