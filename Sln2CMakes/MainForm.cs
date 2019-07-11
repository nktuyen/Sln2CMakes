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
        }

        private void btnSolutionFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = txtSolutionFileName.Text;
            dlg.Filter = @"All Files(*.*)|*.*|Visual Studio Solution Files(*.sln)|*.sln";
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            lvwSolutionDetails.Items.Clear();
            SolutionParser slnParser = new SolutionParser();
            if (slnParser.Parse(txtSolutionFileName.Text))
            {
                int grpIndex = -1;
                foreach(Project prj in slnParser.Solution.Projects)
                {
                    ListViewGroup group = lvwSolutionDetails.Groups.Add(prj.Name, prj.Name);
                    foreach (string filePath in prj.Files)
                    {
                        group.Items.Add(lv);
                    }
                }
            }
            else
            {
                MessageBox.Show("Parsing failed!", AppInfo.Instance.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
