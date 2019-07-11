using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Sln2CMakes
{
    internal class SolutionParser : FileParser
    {
        private Dictionary<string, ProjectInfo> _lstProjects = new Dictionary<string, ProjectInfo>();
        private ProjectInfo _currentPrjInfo = null;

        public Solution Solution { get { return _model as Solution; } }
        internal SolutionParser()
        {

        }

        protected override bool ParseLine(string lineContent, ref int lineNum)
        {
            //Debug.Print(lineContent);

            string remaining = string.Empty;
            int position = -1;
            if (null != Model)
            {
                return false;   //Stop parsing
            }

            if (IsFileFormatLine(lineContent))
            {
                if(_parsingModel != null)
                {
                    return false;   //Stop parsing
                }

                Solution slnModel = new Solution(Utilities.Instance.GetFileTitle(FileName));
                //slnModel.Version = new Version(12, 0);
                _parsingModel = slnModel;
            }
            else if(IsStartProjectLine(lineContent))
            {
                position = lineContent.IndexOf("=");
                if(position > 0)
                {
                    remaining = lineContent.Substring(position + 1);
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
                    }

                    if (prjInfos.Length > 2)
                    {
                        string prjGuide = prjInfos[2];
                        prjGuide = prjGuide.Trim();
                        prjGuide = Utilities.Instance.UnescapeString(prjGuide);
                        _currentPrjInfo.Guide = prjGuide;
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
            if(_parsingModel != null)
            {
                _parsingModel.Validate();
                if (_parsingModel.IsValid)
                {
                    _model = _parsingModel;
                    Solution slnModel = _model as Solution;
                    if (_lstProjects.Count > 0)
                    {
                        foreach(ProjectInfo prj in _lstProjects.Values)
                        {
                            ProjectParser prjParser = new ProjectParser(prj.Name);
                            if ((prjParser.Parse(prj.AbsPath)) && (prjParser.Model!=null))
                            {
                                slnModel.Projects.Add(prjParser.Model as Project);
                            }
                        }
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
