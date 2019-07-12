namespace Sln2CMakes
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSolutionFileName = new System.Windows.Forms.TextBox();
            this.btnSolutionFileOpen = new System.Windows.Forms.Button();
            this.tvwProjectTree = new System.Windows.Forms.TreeView();
            this.lvwItemDetail = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbProjectConfigs = new System.Windows.Forms.ComboBox();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solution File:";
            // 
            // txtSolutionFileName
            // 
            this.txtSolutionFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSolutionFileName.Location = new System.Drawing.Point(87, 13);
            this.txtSolutionFileName.Name = "txtSolutionFileName";
            this.txtSolutionFileName.ReadOnly = true;
            this.txtSolutionFileName.Size = new System.Drawing.Size(724, 20);
            this.txtSolutionFileName.TabIndex = 1;
            this.txtSolutionFileName.Text = "D:\\tinspire-opal-dsktp\\phoenix\\build\\vs";
            // 
            // btnSolutionFileOpen
            // 
            this.btnSolutionFileOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolutionFileOpen.Location = new System.Drawing.Point(812, 12);
            this.btnSolutionFileOpen.Name = "btnSolutionFileOpen";
            this.btnSolutionFileOpen.Size = new System.Drawing.Size(27, 23);
            this.btnSolutionFileOpen.TabIndex = 2;
            this.btnSolutionFileOpen.Text = "...";
            this.btnSolutionFileOpen.UseVisualStyleBackColor = true;
            this.btnSolutionFileOpen.Click += new System.EventHandler(this.btnSolutionFileOpen_Click);
            // 
            // tvwProjectTree
            // 
            this.tvwProjectTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvwProjectTree.CheckBoxes = true;
            this.tvwProjectTree.FullRowSelect = true;
            this.tvwProjectTree.Location = new System.Drawing.Point(87, 39);
            this.tvwProjectTree.Name = "tvwProjectTree";
            this.tvwProjectTree.ShowNodeToolTips = true;
            this.tvwProjectTree.Size = new System.Drawing.Size(300, 424);
            this.tvwProjectTree.TabIndex = 3;
            this.tvwProjectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwProjectTree_AfterSelect);
            // 
            // lvwItemDetail
            // 
            this.lvwItemDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItemDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colValue});
            this.lvwItemDetail.FullRowSelect = true;
            this.lvwItemDetail.GridLines = true;
            this.lvwItemDetail.Location = new System.Drawing.Point(394, 67);
            this.lvwItemDetail.Name = "lvwItemDetail";
            this.lvwItemDetail.ShowItemToolTips = true;
            this.lvwItemDetail.Size = new System.Drawing.Size(445, 396);
            this.lvwItemDetail.TabIndex = 4;
            this.lvwItemDetail.UseCompatibleStateImageBehavior = false;
            this.lvwItemDetail.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Solution Items:";
            // 
            // cbbProjectConfigs
            // 
            this.cbbProjectConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProjectConfigs.FormattingEnabled = true;
            this.cbbProjectConfigs.Location = new System.Drawing.Point(394, 40);
            this.cbbProjectConfigs.Name = "cbbProjectConfigs";
            this.cbbProjectConfigs.Size = new System.Drawing.Size(438, 21);
            this.cbbProjectConfigs.TabIndex = 6;
            this.cbbProjectConfigs.SelectedIndexChanged += new System.EventHandler(this.cbbProjectConfigs_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 240;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 240;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 470);
            this.Controls.Add(this.cbbProjectConfigs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwItemDetail);
            this.Controls.Add(this.tvwProjectTree);
            this.Controls.Add(this.btnSolutionFileOpen);
            this.Controls.Add(this.txtSolutionFileName);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sln2CMakes";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSolutionFileName;
        private System.Windows.Forms.Button btnSolutionFileOpen;
        private System.Windows.Forms.TreeView tvwProjectTree;
        private System.Windows.Forms.ListView lvwItemDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbProjectConfigs;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colValue;
    }
}

