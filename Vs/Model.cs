using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public enum ModelTypes
    {
        Unknown=0,
        Solution,
        Project,
        ProjectItemGroup,
        ProjectItem
    }
    public class Model : NamedObject
    {
        private readonly ModelTypes _kind = ModelTypes.Unknown;
        public Model Parent { get; internal set; }
        public ModelTypes Kind { get { return _kind; } }
        public bool IsValid { get; protected set; }

        internal Model(ModelTypes kind, string name = "") : base(name)
        {
            _kind = kind;
        }

        internal virtual void Validate() { IsValid = true; }
    }
}
