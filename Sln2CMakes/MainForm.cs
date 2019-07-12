using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void InsertProjectItemNode(Project prj, TreeNode parentNode)
        {
            lvwItemDetail.Items.Clear();
            if(prj is VcxProject)
            {
                VcxProject vcxProj = prj as VcxProject;
                foreach (HeaderFile hdr in vcxProj.HeaderFileItems)
                {
                    TreeNode headerNode = parentNode.Nodes.Add(hdr.Name);
                    headerNode.Tag = hdr;
                }
                foreach (SourceFile src in vcxProj.SourceFileItems)
                {
                    TreeNode sourceNode = parentNode.Nodes.Add(src.Name);
                    sourceNode.Tag = src;
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
            SolutionParser slnParser = new SolutionParser();
            if (slnParser.Parse(txtSolutionFileName.Text))
            {
                TreeNode slnNode = tvwProjectTree.Nodes.Add(slnParser.Solution.Name);
                slnNode.Tag = slnParser.Solution;
                foreach (Project prj in slnParser.Solution.Projects)
                {
                    TreeNode prjNode = slnNode.Nodes.Add(prj.Name);
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

            NamedObject obj = tvwProjectTree.SelectedNode.Tag as NamedObject;
            if (null == obj)
                return;

            if (obj is VcxProject)
            {
                VcxProject vcxProj = obj as VcxProject;
                foreach (Configuration config in vcxProj.ConfigurationItems)
                {
                    cbbProjectConfigs.Items.Add(config);
                }
                cbbProjectConfigs.SelectedIndex = 0;
            }
            else if (obj is CodeFile)
            {
                CodeFile codeFile = obj as CodeFile;
                ListViewItem item = lvwItemDetail.Items.Add("Type");
                if (codeFile is HeaderFile)
                    item.SubItems.Add("Header");
                else
                    item.SubItems.Add("Source");
                item = lvwItemDetail.Items.Add("Path");
                item.SubItems.Add(codeFile.AbsolutePath);
                item = lvwItemDetail.Items.Add("Relative Path");
                item.SubItems.Add(codeFile.RelativePath);

            }
        }

        private void cbbProjectConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwItemDetail.Items.Clear();
            if (null == tvwProjectTree.SelectedNode)
                return;

            Project prj = tvwProjectTree.SelectedNode.Tag as Project;
            if (prj is VcxProject)
            {
                VcxProject vcxProj = prj as VcxProject;
                foreach(Configuration config in vcxProj.ConfigurationItems)
                {
                    config.IsActivate = false;
                }
            }

            Configuration activConfig = cbbProjectConfigs.SelectedItem as Configuration;
            if (null == activConfig)
                return;

            activConfig.IsActivate = true;
        }
    }
}
