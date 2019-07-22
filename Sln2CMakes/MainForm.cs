using System;
using System.Windows.Forms;

namespace Sln2CMakes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = AppInfo.Instance.String;
            cbbProjectConfigs.DisplayMember = "Name";
        }

        private void InsertProjectItemNode(Vs.Project prj, TreeNode parentNode)
        {
            lvwItemDetail.Items.Clear();
            if(prj is Vs.VcxProject)
            {
                Vs.VcxProject vcxProj = prj as Vs.VcxProject;
                foreach (Vs.HeaderFile hdr in vcxProj.HeaderFileItems)
                {
                    TreeNode headerNode = parentNode.Nodes.Add(hdr.Name);
                    headerNode.Checked = true;
                    headerNode.Tag = hdr;
                }
                foreach (Vs.SourceFile src in vcxProj.SourceFileItems)
                {
                    TreeNode sourceNode = parentNode.Nodes.Add(src.Name);
                    sourceNode.Tag = src;
                    sourceNode.Checked = true;
                }
            }
        }
        private void btnSolutionFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = txtSolutionFileName.Text;
            dlg.Filter = @"All Files(*.*)|*.*|Visual Studio Solution Files(*.sln)|*.sln";
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            txtSolutionFileName.Text = dlg.FileName;
            tvwProjectTree.Nodes.Clear();
            lvwItemDetail.Items.Clear();
            cbbProjectConfigs.Items.Clear();
            Vs.SolutionParser slnParser = new Vs.SolutionParser();
            if (slnParser.Parse(txtSolutionFileName.Text))
            {
                TreeNode slnNode = tvwProjectTree.Nodes.Add(slnParser.Solution.Name);
                slnNode.Tag = slnParser.Solution;
                foreach (Vs.Project prj in slnParser.Solution.Projects)
                {
                    TreeNode prjNode = slnNode.Nodes.Add(prj.Name);
                    prjNode.Checked = true;
                    prjNode.Tag = prj;
                    InsertProjectItemNode(prj, prjNode);
                }
            }
            else
            {
                MessageBox.Show("Parsing failed!", AppInfo.Instance.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tvwProjectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvwItemDetail.Items.Clear();
            cbbProjectConfigs.Items.Clear();

            if (null == tvwProjectTree.SelectedNode)
                return;

            object obj = tvwProjectTree.SelectedNode.Tag;
            if (null == obj)
                return;

            if(obj is Vs.Solution)
            {
                Vs.Solution solution = tvwProjectTree.SelectedNode.Tag as Vs.Solution;
                ListViewItem item = lvwItemDetail.Items.Add("Version");
                item.SubItems.Add(solution.Version.ToString());

                item = lvwItemDetail.Items.Add("Path");
                item.SubItems.Add(solution.Path);
                
            }
            else if (obj is Vs.VcxProject)
            {
                Vs.VcxProject vcxProj = obj as Vs.VcxProject;
                int index = -1;
                foreach (Vs.VcProjectConfigurationItem config in vcxProj.ConfigurationItems)
                {
                    index = cbbProjectConfigs.Items.Add(config);
                }
                cbbProjectConfigs.SelectedIndex = 0;
                cbbProjectConfigs.SelectedItem = cbbProjectConfigs.Items[0];
                cbbProjectConfigs_SelectedIndexChanged(this, new EventArgs());
            }
            else if (obj is Vs.CodeFile)
            {
                Vs.CodeFile codeFile = obj as Vs.CodeFile;
                ListViewItem item = lvwItemDetail.Items.Add("Type");
                if (codeFile is Vs.HeaderFile)
                {
                    item.SubItems.Add("Header");
                }
                else
                {
                    item.SubItems.Add("Source");
                }
                item = lvwItemDetail.Items.Add("Path");
                item.SubItems.Add(codeFile.AbsolutePath);
                item = lvwItemDetail.Items.Add("Relative Path");
                item.SubItems.Add(codeFile.RelativePath);

            }
        }

        private void cbbProjectConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwItemDetail.Items.Clear();
            if (tvwProjectTree.SelectedNode == null || tvwProjectTree.SelectedNode.Tag == null)            {
                return;
            }

            object obj = tvwProjectTree.SelectedNode.Tag;
            if (obj is Vs.VcxProject)
            {
                Vs.VcxProject project = obj as Vs.VcxProject;
                object sel = cbbProjectConfigs.SelectedItem;
                Vs.VcxProjectConfigurationItem configurationItem = sel as Vs.VcxProjectConfigurationItem;
                if (null == configurationItem)
                {
                    return;
                }

                ListViewItem item = null;
                if (null != configurationItem.ProjectPropertyGroup)
                {
                    item = lvwItemDetail.Items.Add("ConfigurationType");
                    item.SubItems.Add(configurationItem.ProjectPropertyGroup.ConfigurationType.ToString());

                    item = lvwItemDetail.Items.Add("OutDir");
                    item.SubItems.Add(configurationItem.ProjectPropertyGroup.OutDir);

                    item = lvwItemDetail.Items.Add("IntDir");
                    item.SubItems.Add(configurationItem.ProjectPropertyGroup.IntDir);

                    item = lvwItemDetail.Items.Add("TargetName");
                    item.SubItems.Add(configurationItem.ProjectPropertyGroup.TargetName);
                }

                if (null != configurationItem.ProjectItemDefinitionGroup)
                {
                    if (null != configurationItem.ProjectItemDefinitionGroup.Compilation)
                    {
                        item = lvwItemDetail.Items.Add("Include Directories");
                        string dirs = string.Empty;
                        foreach (string dir in configurationItem.ProjectItemDefinitionGroup.Compilation.IncludeDirectories)
                        {
                            if (dirs != string.Empty)
                            {
                                dirs += ";";
                            }
                            dirs += dir;
                        }
                        item.SubItems.Add(dirs);

                        item = lvwItemDetail.Items.Add("Preprocessors");
                        string defs = string.Empty;
                        foreach(string def in configurationItem.ProjectItemDefinitionGroup.Compilation.Preprocessors)
                        {
                            if (defs != string.Empty)
                            {
                                defs += ";";
                            }
                            defs += def;
                        }
                        item.SubItems.Add(defs);
                    }
                    if (null != configurationItem.ProjectItemDefinitionGroup.Linking)
                    {
                        item = lvwItemDetail.Items.Add("OutputFile");
                        item.SubItems.Add(configurationItem.ProjectItemDefinitionGroup.Linking.OutputFile);
                    }
                }

                if (null != configurationItem.ProjectImportGroup)
                {
                    if(null!= configurationItem.ProjectImportGroup.Items)
                    {
                        foreach(string file in configurationItem.ProjectImportGroup.Items)
                        {
                            item = lvwItemDetail.Items.Add("Import");
                            item.SubItems.Add(file);
                        }
                    }
                }
            }
        }
    }
}
