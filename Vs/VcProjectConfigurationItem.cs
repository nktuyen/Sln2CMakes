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
        internal VcProjectConfigurationItem(string name = "") : base(name)
        {
            IsActivate = false;
            ProjectPropertyGroup = new VcProjectPropertyGroup(name);
        }
    }
}
