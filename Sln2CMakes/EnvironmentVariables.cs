using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    class EnvironmentVariables
    {
        private Dictionary<string, string> vars = new Dictionary<string, string>();
        private static EnvironmentVariables _instance = null;
        public static EnvironmentVariables Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new EnvironmentVariables();
                return _instance;
            }
        }
        private EnvironmentVariables()
        {
            
        }

        internal bool SetVariable(string varName, string varVal)
        {
            return true;
        }

        internal string GetVariable(string varName)
        {
            return string.Empty;
        }
    }
}
