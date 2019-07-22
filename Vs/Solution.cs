using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class Solution : NamedObject
    {
        public Version Version { get; internal set; }
        public string Path { get; internal set; }
        public string AbsolutePath { get; internal set; }
        public string RelativePath { get; internal set; }
        public string Extension { get; set; }
        public string Directory { get; internal set; }
        public readonly List<Project> Projects = new List<Project>();
        internal Dictionary<string,string> EnvironmentVariables { get; }
        internal Solution(string name = "") : base(name)
        {
            Projects.Clear();
            EnvironmentVariables = new Dictionary<string, string>();
            EnvironmentVariables.Add("$(SolutionDir)", string.Empty);
            EnvironmentVariables.Add("$(SolutionFileName)", string.Empty);
            EnvironmentVariables.Add("$(SolutionName)", string.Empty);
            EnvironmentVariables.Add("$(SolutionPath)", string.Empty);
            EnvironmentVariables.Add("$(SolutionExt)", string.Empty);
            EnvironmentVariables.Add("$(UserRootDir)", Environment.GetEnvironmentVariable(""));
            EnvironmentVariables.Add("$(ALLUSERSPROFILE)", Environment.GetEnvironmentVariable("ALLUSERSPROFILE"));
            EnvironmentVariables.Add("$(APPDATA)", Environment.GetEnvironmentVariable("APPDATA"));
            EnvironmentVariables.Add("$(COMPUTERNAME)", Environment.GetEnvironmentVariable("COMPUTERNAME"));
            EnvironmentVariables.Add("$(HOMEDRIVE)", Environment.GetEnvironmentVariable("HOMEDRIVE"));
            EnvironmentVariables.Add("$(HOMEPATH)", Environment.GetEnvironmentVariable("HOMEPATH"));
            EnvironmentVariables.Add("$(USERNAME)", Environment.GetEnvironmentVariable("USERNAME"));
            EnvironmentVariables.Add("$(WINDIR)", Environment.GetEnvironmentVariable("WINDIR"));
            EnvironmentVariables.Add("$(USERPROFILE)", Environment.GetEnvironmentVariable("USERPROFILE"));
        }

        internal void UpdateEnvironmentVariables()
        {
            EnvironmentVariables["$(SolutionDir)"] = Utilities.Instance.GetFileDirectory(Path, true);
            EnvironmentVariables["$(SolutionFileName)"] = Utilities.Instance.GetFileName(Path);
            EnvironmentVariables["$(SolutionName)"] = Name;
            EnvironmentVariables["$(SolutionPath)"] = Path;
            EnvironmentVariables["$(SolutionExt)"] = Utilities.Instance.GetFileExtension(Path);

            foreach (Project project in Projects)
            {
                project.UpdateEnvironmentVariables();
            }
        }
    }
}
