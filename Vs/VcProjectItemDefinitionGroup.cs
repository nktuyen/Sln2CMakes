using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class VcProjectItemDefinitionGroup : ProjectItem
    {
        public VcProjectCompilationDefintion Compilation { get; internal set; }
        public VcProjectLinkingDefintion Linking { get; internal set; }
        internal VcProjectItemDefinitionGroup(string name = ""): base(name)
        {

        }

        internal override void UpdateEnvironmentVariables()
        {
            base.UpdateEnvironmentVariables();

            if (null != Compilation)
            {
                Compilation.UpdateEnvironmentVariables();
            }
            if (null != Linking)
            {
                Linking.UpdateEnvironmentVariables();
            }
        }
    }
}
