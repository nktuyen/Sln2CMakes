using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class Solution : File
    {
        public Version Version { get; internal set; }
        public string Path { get; internal set; }
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
        }

        internal void UpdateEnvironmentVariables()
        {
            EnvironmentVariables["$(SolutionDir)"] = Utilities.Instance.GetFileDirectory(Path);
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
