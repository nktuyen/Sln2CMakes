using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class VcProjectConfigurationItem : ProjectItem
    {
        public bool IsActivate { get; internal set; }
        public string Platform { get; internal set; }
        public string Configuration { get; internal set; }
        public VcProjectPropertyGroup ProjectPropertyGroup { get; internal set; }
        public VcProjectItemDefinitionGroup ProjectItemDefinitionGroup { get; internal set; }
        public VcProjectImportGroup ProjectImportGroup { get; set; }
        internal VcProjectConfigurationItem(string name = "") : base(name)
        {
            IsActivate = false;
            ProjectPropertyGroup = new VcProjectPropertyGroup(name);

            EnvironmentVariables.Add("$(Configuration)", string.Empty);
            EnvironmentVariables.Add("$(Platform)", string.Empty);
        }

        internal override void UpdateEnvironmentVariables()
        {
            base.UpdateEnvironmentVariables();

            EnvironmentVariables["$(Configuration)"] = Configuration;
            EnvironmentVariables["$(Platform)"] = Platform;

            if (null != ProjectPropertyGroup)
            {
                ProjectPropertyGroup.UpdateEnvironmentVariables();
            }
            if (null != ProjectItemDefinitionGroup)
            {
                ProjectItemDefinitionGroup.UpdateEnvironmentVariables();
            }
            if (null != ProjectImportGroup)
            {
                ProjectImportGroup.UpdateEnvironmentVariables();
            }
        }
    }
}
