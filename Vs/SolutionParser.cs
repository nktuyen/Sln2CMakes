using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Vs
{
    public class SolutionParser : FileParser
    {
        private Dictionary<string, ProjectInfo> _lstProjects = new Dictionary<string, ProjectInfo>();
        private ProjectInfo _currentPrjInfo = null;
        private Solution _solution = null;

        public Solution Solution { get; internal set; }
        public SolutionParser()
        {

        }

        protected override bool ParseLine(string lineContent, ref int lineNum)
        {
            //Debug.Print(lineContent);

            string remaining = string.Empty;
            int position = -1;
            if (null != Solution)
            {
                return false;   //Stop parsing
            }

            if (IsFileFormatLine(lineContent))
            {
                if(_solution != null)
                {
                    return false;   //Stop parsing
                }

                Solution slnModel = new Solution(Utilities.Instance.GetFileTitle(FileName));
                string versionString = lineContent.Substring(@"Microsoft Visual Studio Solution File, Format Version".Length + 1).Trim();
                string[] versions = versionString.Split('.');
                int major = 0;
                int minor = 0;

                if (versions.Length > 0)
                {
                    if(!int.TryParse(versions[0], out major))
                    {
                        major = 9;
                    }
                }
                if (versions.Length > 1)
                {
                    if(!int.TryParse(versions[1], out minor))
                    {
                        minor = 0;
                    }
                }

                slnModel.Version = new Version(major, minor);
                slnModel.Path = FileName;
                _solution = slnModel;
            }
            else if(IsStartProjectLine(lineContent))
            {
                position = lineContent.IndexOf(" = ");
                if(position > 0)
                {
                    remaining = lineContent.Substring(position + " = ".Length+1);
                    remaining = remaining.Trim();
                    string[] prjInfos = remaining.Split(',');
                    if(prjInfos.Length > 0)
                    {
                        string prjName = prjInfos[0];
                        prjName = prjName.Trim();
                        prjName = Utilities.Instance.UnescapeString(prjName);
                        _currentPrjInfo = new ProjectInfo();
                        _currentPrjInfo.Name = prjName;
                    }

                    if (prjInfos.Length > 1)
                    {
                        string prjRelPath = prjInfos[1];
                        prjRelPath = prjRelPath.Trim();
                        prjRelPath = Utilities.Instance.UnescapeString(prjRelPath);
                        _currentPrjInfo.RelPath = prjRelPath;
                        _currentPrjInfo.AbsPath = Utilities.Instance.GetFileDirectory(FileName) + "\\" + prjRelPath;
                        _currentPrjInfo.FileExt = Utilities.Instance.GetFileExtension(prjRelPath);
                    }

                    if (prjInfos.Length > 2)
                    {
                        string prjGuide = prjInfos[2];
                        prjGuide = prjGuide.Trim();
                        prjGuide = Utilities.Instance.UnescapeString(prjGuide);
                        _currentPrjInfo.Guide = prjGuide;
                    }

                    string head = lineContent.Substring(0, position - 1).Trim();
                    int guidStart = head.IndexOf("{");
                    int guidEnd = head.IndexOf("}", guidStart);
                    if((guidStart!=-1) && (guidEnd!=-1) && (guidStart != guidEnd)) { }
                    {
                        string prjKind = head.Substring(guidStart, guidEnd - guidStart + 1);
                        _currentPrjInfo.Kind = prjKind;
                    }
                }
            }
            else if (IsEndProjectLine(lineContent))
            {
                _lstProjects.Add(_currentPrjInfo.Guide, _currentPrjInfo);
            }

            lineNum++;
            return true;
        }

        protected override bool PreParsing()
        {
            _lstProjects.Clear();
            _currentPrjInfo = null;

            return base.PreParsing();
        }

        protected override void PostParsing()
        {
            if(_solution != null)
            {
                //TODO: _solution.Validate();
                {
                    Solution = _solution;
                    if (_lstProjects.Count > 0)
                    {
                        foreach(ProjectInfo prj in _lstProjects.Values)
                        {
                            ProjectParser prjParser = null;
                            if(string.Compare("csproj", prj.FileExt, true) == 0)
                            {

                            }
                            else if (string.Compare("vbproj", prj.FileExt, true) == 0)
                            {

                            }
                            else if (string.Compare("vcproj", prj.FileExt, true) == 0)
                            {

                            }
                            else if (string.Compare("vcxproj", prj.FileExt, true) == 0)
                            {
                                prjParser = new VcxProjectParser(prj.Name, prj.Guide);
                            }

                            if (null != prjParser)
                            {
                                if ((prjParser.Parse(prj.AbsPath)) && (prjParser.Project != null))
                                {
                                    prjParser.Project.Solution = Solution;
                                    Solution.Projects.Add(prjParser.Project);
                                }
                            }
                        }
                    }
                    Solution.UpdateEnvironmentVariables();

                    foreach(Project project in Solution.Projects)
                    {
                        if (project is VcxProject)
                        {
                            VcxProject vcxProject = project as VcxProject;
                            foreach (VcxProjectConfigurationItem configurationItem in vcxProject.ConfigurationItems)
                            {
                                VcxProjectImportGroup importGroup = configurationItem.ProjectImportGroup as VcxProjectImportGroup;
                                if (importGroup != null)
                                {
                                    foreach (string importFile in importGroup.Items)
                                    {
                                        VcxProjectParser parser = new VcxProjectParser(vcxProject.Name);
                                        parser.CurrentConfiguration = configurationItem;
                                        if (parser.Parse(importFile))
                                        {
                                            
                                        }
                                    }
                                }
                            }
                        }
                        else if (project is VcProject)
                        {
                            VcProject vcProject = project as VcProject;
                            foreach(VcProjectConfigurationItem configurationItem in vcProject.ConfigurationItems)
                            {
                                VcProjectImportGroup importGroup = configurationItem.ProjectImportGroup;
                                if (importGroup != null)
                                {
                                    foreach(string importFile in importGroup.Items)
                                    {
                                        VcProjectParser parser = new VcProjectParser(vcProject.Name);
                                        parser.CurrentConfiguration = configurationItem;
                                        if (parser.Parse(importFile))
                                        {

                                        }
                                    }
                                }
                            }
                        }
                        project.UpdateEnvironmentVariables();
                    }
                }
            }
        }

        private bool IsFileFormatLine(string lineContent)
        {
            Regex rex = new Regex(@"Microsoft Visual Studio Solution File, Format Version \d+(?:\.\d+)+");
            return rex.IsMatch(lineContent);
        }

        private bool IsStartProjectLine(string lineContent)
        {
            Regex rex = new Regex(@"^Project");
            return rex.IsMatch(lineContent);
        }


        private bool IsEndProjectLine(string lineContent)
        {
            string tmp = lineContent.Trim();
            return (string.Compare(lineContent, "EndProject", true)==0);
        }
    }
}
