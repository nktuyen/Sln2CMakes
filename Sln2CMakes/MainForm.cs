using Microsoft.Build.Evaluation;
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
                    headerNode.Tag = hdr;
                }
                foreach (Vs.SourceFile src in vcxProj.SourceFileItems)
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
            Vs.SolutionParser slnParser = new Vs.SolutionParser();
            if (slnParser.Parse(txtSolutionFileName.Text))
            {
                TreeNode slnNode = tvwProjectTree.Nodes.Add(slnParser.Solution.Name);
                slnNode.Tag = slnParser.Solution;
                foreach (Vs.Project prj in slnParser.Solution.Projects)
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

            object obj = tvwProjectTree.SelectedNode.Tag;
            if (null == obj)
                return;

            if (obj is Vs.VcxProject)
            {
                Vs.VcxProject vcxProj = obj as Vs.VcxProject;
                foreach (Vs.Configuration config in vcxProj.ConfigurationItems)
                {
                    cbbProjectConfigs.Items.Add(config);
                }
                cbbProjectConfigs.SelectedIndex = 0;
            }
            else if (obj is Vs.CodeFile)
            {
                Vs.CodeFile codeFile = obj as Vs.CodeFile;
                ListViewItem item = lvwItemDetail.Items.Add("Type");
                if (codeFile is Vs.HeaderFile)
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

        }
    }
}
