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
            this.lvwSolutionDetails = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGuid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
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
            this.txtSolutionFileName.Size = new System.Drawing.Size(852, 20);
            this.txtSolutionFileName.TabIndex = 1;
            this.txtSolutionFileName.Text = "D:\\tinspire-opal-dsktp\\phoenix\\build\\vs\\TI-Nspire_Desktop.sln";
            // 
            // btnSolutionFileOpen
            // 
            this.btnSolutionFileOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolutionFileOpen.Location = new System.Drawing.Point(940, 12);
            this.btnSolutionFileOpen.Name = "btnSolutionFileOpen";
            this.btnSolutionFileOpen.Size = new System.Drawing.Size(27, 23);
            this.btnSolutionFileOpen.TabIndex = 2;
            this.btnSolutionFileOpen.Text = "...";
            this.btnSolutionFileOpen.UseVisualStyleBackColor = true;
            this.btnSolutionFileOpen.Click += new System.EventHandler(this.btnSolutionFileOpen_Click);
            // 
            // lvwSolutionDetails
            // 
            this.lvwSolutionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSolutionDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colName,
            this.colPath,
            this.colGuid});
            this.lvwSolutionDetails.FullRowSelect = true;
            this.lvwSolutionDetails.GridLines = true;
            this.lvwSolutionDetails.Location = new System.Drawing.Point(87, 71);
            this.lvwSolutionDetails.Name = "lvwSolutionDetails";
            this.lvwSolutionDetails.ShowItemToolTips = true;
            this.lvwSolutionDetails.Size = new System.Drawing.Size(852, 535);
            this.lvwSolutionDetails.TabIndex = 3;
            this.lvwSolutionDetails.UseCompatibleStateImageBehavior = false;
            this.lvwSolutionDetails.View = System.Windows.Forms.View.Details;
            // 
            // colNo
            // 
            this.colNo.Text = "#";
            this.colNo.Width = 40;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 120;
            // 
            // colPath
            // 
            this.colPath.Text = "FullName";
            this.colPath.Width = 240;
            // 
            // colGuid
            // 
            this.colGuid.Text = "Guid";
            this.colGuid.Width = 120;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 637);
            this.Controls.Add(this.lvwSolutionDetails);
            this.Controls.Add(this.btnSolutionFileOpen);
            this.Controls.Add(this.txtSolutionFileName);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Sln2CMakes";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSolutionFileName;
        private System.Windows.Forms.Button btnSolutionFileOpen;
        private System.Windows.Forms.ListView lvwSolutionDetails;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ColumnHeader colGuid;
    }
}

