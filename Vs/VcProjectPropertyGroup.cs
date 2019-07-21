using System;
using System.Collections.Generic;
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
        }
    }
}
