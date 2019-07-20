using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class Project : File
    {
        public string Guid { get; internal set; }
        public Solution Solution { get; internal set; }
        public Dictionary<string, string> EnvironmentVariables { get; }
        internal Project(string name = "", string guid = ""): base(name)
        {
            Guid = guid;
            EnvironmentVariables = new Dictionary<string, string>();
            EnvironmentVariables.Add("$(ProjectDir)", string.Empty);
            EnvironmentVariables.Add("$(ProjectName)", string.Empty);
            EnvironmentVariables.Add("$(ProjectExt)", string.Empty);
            EnvironmentVariables.Add("$(ProjectFileName)", string.Empty);
            EnvironmentVariables.Add("$(ProjectGuid)", string.Empty);
            EnvironmentVariables.Add("$(ProjectPath)", string.Empty);
        }

        internal void UpdateEnvironmentVariables()
        {
            EnvironmentVariables["$(ProjectDir)"] = Utilities.Instance.GetFileDirectory(AbsolutePath);
            EnvironmentVariables["$(ProjectName)"] = Name;
            EnvironmentVariables["$(ProjectExt)"] = Utilities.Instance.GetFileExtension(AbsolutePath);
            EnvironmentVariables["$(ProjectFileName)"] = Utilities.Instance.GetFileName(AbsolutePath);
            EnvironmentVariables["$(ProjectGuid)"] = Guid;
            EnvironmentVariables["$(ProjectPath)"] = AbsolutePath;
        }
    }
}
