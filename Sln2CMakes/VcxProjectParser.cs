using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sln2CMakes
{
    public class VcxProjectParser : VcProjectParser
    {
        private StringBuilder _xml = new StringBuilder();
        private VcxProject _project = null;
        protected XmlDocument Document { get; private set; }

        internal VcxProjectParser(string prjName) : base(prjName)
        {
            
        }

        protected override bool ParseLine(string lineContent, ref int lineNum)
        {
            _xml.Append(lineContent);
            return base.ParseLine(lineContent, ref lineNum);
        }

        protected override bool PreParsing()
        {
            _xml.Clear();
            Document = null;
            _project = null;
            return base.PreParsing();
        }

        protected override void PostParsing()
        {
            Document = new XmlDocument();
            try
            {
                Document.LoadXml(_xml.ToString());
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                return;
            }

            XmlElement projectElm = Document.DocumentElement;
            if((null!= projectElm) && (string.Compare("Project", projectElm.Name, true) == 0))
            {
                _project = new VcxProject(_prjName);
            }
            else
            {
                return;
            }

            foreach(XmlNode node in projectElm.ChildNodes)
            {
                if (string.Compare("ItemGroup", node.Name, true) == 0)
                {
                    ProjectItemGroup prjItemGroup = new ProjectItemGroup();

                    foreach(XmlNode child in node.ChildNodes)
                    {
                        if(string.Compare(child.Name, "ProjectConfiguration", true) == 0)
                        {

                        }
                        else if (string.Compare(child.Name, "ClInclude", true) == 0)
                        {

                        }
                        else if (string.Compare(child.Name, "ClCompile", true) == 0)
                        {

                        }
                        else if (string.Compare(child.Name, "ResourceCompile", true) == 0)
                        {

                        }
                        else if (string.Compare(child.Name, "Image", true) == 0)
                        {

                        }
                        else if (string.Compare(child.Name, "None", true) == 0)
                        {

                        }
                        else
                        {

                        }
                    }
                }
                else if (string.Compare("PropertyGroup", node.Name, true) == 0)
                {

                }
                else if (string.Compare("ImportGroup", node.Name, true) == 0)
                {

                }
                else if (string.Compare("ItemDefinitionGroup", node.Name, true) == 0)
                {

                }
                else if (string.Compare("ProjectExtensions", node.Name, true) == 0)
                {

                }
                else if (string.Compare("Import", node.Name, true) == 0)
                {

                }
                else
                {
                    
                }
            }

            //Completed
            //TODO: if (_project.IsValid)
            {
                Project = _project;
            }
        }
    }
}
