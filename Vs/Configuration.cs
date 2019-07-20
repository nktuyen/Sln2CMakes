using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class Configuration : ProjectItem
    {
        public bool IsActivate { get; internal set; }
        internal Configuration(string name = "") : base(name)
        {
            IsActivate = false;
        }
    }
}
