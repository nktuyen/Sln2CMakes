using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public enum ConfigurationType
    {
        Unknow = 0,
        Application,
        StaticLibrary,
        DynamicLibrary,
        Makefile,
    };

    public class VcProject : Project
    {
        #region Per configuration properties
        internal Dictionary<string, ConfigurationType> ConfigurationTypes { get; set; }
        internal Dictionary<string, List<string>> ConfigurationDefinitions { get; set; }
        #endregion
        public List<Configuration> ConfigurationItems { get; internal set; }
        public List<SourceFile> SourceFileItems { get; internal set; }
        public List<HeaderFile> HeaderFileItems { get; internal set; }
        public ConfigurationType ConfigurationType
        {
            get
            {
                foreach(Configuration config in ConfigurationItems)
                {
                    if (config.IsActivate)
                    {
                        if (ConfigurationTypes.ContainsKey(config.Name))
                        {
                            ConfigurationType configType = ConfigurationTypes[config.Name];
                            return configType;
                        }
                    }
                }

                return ConfigurationType.Unknow;
            }
        }
        internal VcProject(string name = "", string guid = ""): base(name, guid)
        {
            ConfigurationItems = new List<Configuration>();
            HeaderFileItems = new List<HeaderFile>();
            SourceFileItems = new List<SourceFile>();
            ConfigurationTypes = new Dictionary<string, ConfigurationType>();
            ConfigurationDefinitions = new Dictionary<string, List<string>>();
        }
    }
}
