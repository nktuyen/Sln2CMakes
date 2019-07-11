using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    class AppInfo
    {
        private static AppInfo _instance = null;
        private readonly string _name = string.Empty;
        private readonly Version _version;

        public String Name { get { return _name; } }
        public Version Version { get { return _version; } }
        public string String { get { return string.Format("{0} v{1}.{2}.{3}", Name, Version.Major, Version.Minor, Version.Build); } }
        public static AppInfo Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new AppInfo();

                return _instance;
            }
        }
        private AppInfo()
        {
            _name = "Sln2CMakes";
            _version = new Version(0, 0, 1);
        }
    }
}
