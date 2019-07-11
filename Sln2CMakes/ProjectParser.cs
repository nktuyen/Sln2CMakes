using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Sln2CMakes
{
    internal class ProjectParser : FileParser
    {
        private StringBuilder XMLData = new StringBuilder();
        private Project _project = null;

        public Project Project { get { return _model as Project; } }
        internal ProjectParser(string projectName = "")
        {
            _project = new Project(projectName);
        }

        protected override bool ParseLine(string lineContent, ref int lineNum)
        {
            if (lineContent != string.Empty)
                XMLData.Append(lineContent);

            return true;
        }

        protected override bool PreParsing()
        {
            XMLData.Clear();
            _project.IncludeDirectories.Clear();
            _project.HeaderFiles.Clear();
            _project.SourceFiles.Clear();
            _project.Files.Clear();
            return base.PreParsing();
        }

        protected override void PostParsing()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(XMLData.ToString());
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                return;
            }

            XmlElement docElm = xmlDoc.DocumentElement;
            foreach(XmlNode elm in docElm.ChildNodes)
            {
                if(string.Compare("ItemGroup", elm.Name, true) == 0)
                {
                    XmlNode firstChild = elm.FirstChild;


                    if (firstChild == null)
                    {
                        continue;
                    }

                    if( (String.Compare("ClCompile", firstChild.Name, true) == 0) || (String.Compare("ClInclude", firstChild.Name, true) == 0))
                    {
                        foreach (XmlNode fileNode in elm.ChildNodes)
                        {
                            XmlAttribute pathAttr = null;
                            try
                            {
                                pathAttr = fileNode.Attributes["Include"];
                            }
                            catch(Exception ex)
                            {
                                pathAttr = null;
                                continue;
                            }
                            string filePath = pathAttr.Value;
                            string fullPath = Path.GetFullPath(Utilities.Instance.GetFileDirectory(_filePath) + "\\" + filePath);

                            _project.Files.Add(fullPath);
                            if (String.Compare("ClCompile", firstChild.Name, true) == 0)
                            {
                                _project.SourceFiles.Add(fullPath);
                            }
                            else if (String.Compare("ClInclude", firstChild.Name, true) == 0)
                            {
                                _project.HeaderFiles.Add(fullPath);
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    continue;
                }
            }

            _project.Validate();
            if (_project.IsValid)
            {
                _model = _project;
            }
        }
    }
}
