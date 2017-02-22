namespace JimsBackgroundChanger
{
    partial class Form
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("1920x1080", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("3440x1440", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("folder1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("folder2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("folder3");
            this.folderView = new System.Windows.Forms.ListView();
            this.folderCollumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteFoldersBtn = new System.Windows.Forms.Button();
            this.addFolderBtn = new System.Windows.Forms.Button();
            this.folderTxtbx = new System.Windows.Forms.TextBox();
            this.folderLbl = new System.Windows.Forms.Label();
            this.resLbl = new System.Windows.Forms.Label();
            this.resComboBox = new System.Windows.Forms.ComboBox();
            this.addResBtn = new System.Windows.Forms.Button();
            this.deleteResBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderView
            // 
            this.folderView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderView.CheckBoxes = true;
            this.folderView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.folderCollumn});
            this.folderView.FullRowSelect = true;
            this.folderView.GridLines = true;
            listViewGroup1.Header = "1920x1080";
            listViewGroup1.Name = "res1";
            listViewGroup2.Header = "3440x1440";
            listViewGroup2.Name = "res2";
            this.folderView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            listViewItem1.Group = listViewGroup1;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.ToolTipText = "lel";
            listViewItem2.Group = listViewGroup1;
            listViewItem2.StateImageIndex = 0;
            listViewItem2.ToolTipText = "f2";
            listViewItem3.Group = listViewGroup2;
            listViewItem3.StateImageIndex = 0;
            listViewItem3.ToolTipText = "fu";
            this.folderView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.folderView.LabelEdit = true;
            this.folderView.Location = new System.Drawing.Point(12, 75);
            this.folderView.Name = "folderView";
            this.folderView.Size = new System.Drawing.Size(591, 266);
            this.folderView.TabIndex = 5;
            this.folderView.UseCompatibleStateImageBehavior = false;
            this.folderView.View = System.Windows.Forms.View.Details;
            // 
            // folderCollumn
            // 
            this.folderCollumn.Text = "Folder";
            this.folderCollumn.Width = 710;
            // 
            // deleteFoldersBtn
            // 
            this.deleteFoldersBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteFoldersBtn.Location = new System.Drawing.Point(12, 347);
            this.deleteFoldersBtn.Name = "deleteFoldersBtn";
            this.deleteFoldersBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteFoldersBtn.TabIndex = 6;
            this.deleteFoldersBtn.Text = "Delete";
            this.deleteFoldersBtn.UseVisualStyleBackColor = true;
            this.deleteFoldersBtn.Click += new System.EventHandler(this.deleteFoldersBtn_Click);
            // 
            // addFolderBtn
            // 
            this.addFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFolderBtn.Location = new System.Drawing.Point(528, 12);
            this.addFolderBtn.Name = "addFolderBtn";
            this.addFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.addFolderBtn.TabIndex = 7;
            this.addFolderBtn.Text = "Add";
            this.addFolderBtn.UseVisualStyleBackColor = true;
            this.addFolderBtn.Click += new System.EventHandler(this.addFolderBtn_Click);
            // 
            // folderTxtbx
            // 
            this.folderTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTxtbx.Location = new System.Drawing.Point(82, 14);
            this.folderTxtbx.Name = "folderTxtbx";
            this.folderTxtbx.Size = new System.Drawing.Size(359, 20);
            this.folderTxtbx.TabIndex = 8;
            // 
            // folderLbl
            // 
            this.folderLbl.AutoSize = true;
            this.folderLbl.Location = new System.Drawing.Point(12, 17);
            this.folderLbl.Name = "folderLbl";
            this.folderLbl.Size = new System.Drawing.Size(42, 13);
            this.folderLbl.TabIndex = 11;
            this.folderLbl.Text = "Folder :";
            // 
            // resLbl
            // 
            this.resLbl.AutoSize = true;
            this.resLbl.Location = new System.Drawing.Point(12, 46);
            this.resLbl.Name = "resLbl";
            this.resLbl.Size = new System.Drawing.Size(63, 13);
            this.resLbl.TabIndex = 12;
            this.resLbl.Text = "Resolution :";
            // 
            // resComboBox
            // 
            this.resComboBox.FormattingEnabled = true;
            this.resComboBox.Items.AddRange(new object[] {
            "1920x1080",
            "3440x1440"});
            this.resComboBox.Location = new System.Drawing.Point(82, 46);
            this.resComboBox.Name = "resComboBox";
            this.resComboBox.Size = new System.Drawing.Size(121, 21);
            this.resComboBox.TabIndex = 13;
            // 
            // addResBtn
            // 
            this.addResBtn.Location = new System.Drawing.Point(211, 46);
            this.addResBtn.Name = "addResBtn";
            this.addResBtn.Size = new System.Drawing.Size(75, 23);
            this.addResBtn.TabIndex = 14;
            this.addResBtn.Text = "Add";
            this.addResBtn.UseVisualStyleBackColor = true;
            this.addResBtn.Click += new System.EventHandler(this.addResBtn_Click);
            // 
            // deleteResBtn
            // 
            this.deleteResBtn.Location = new System.Drawing.Point(292, 46);
            this.deleteResBtn.Name = "deleteResBtn";
            this.deleteResBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteResBtn.TabIndex = 15;
            this.deleteResBtn.Text = "Delete";
            this.deleteResBtn.UseVisualStyleBackColor = true;
            this.deleteResBtn.Click += new System.EventHandler(this.deleteResBtn_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Seelct to folder where your wallpapers are located";
            this.folderBrowserDialog.SelectedPath = "C:\\Users\\Jim\\Pictures";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(528, 347);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 16;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(409, 347);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(113, 23);
            this.nextBtn.TabIndex = 17;
            this.nextBtn.Text = "Next Background";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(447, 12);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 18;
            this.browseBtn.Text = "Browse...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 382);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.deleteResBtn);
            this.Controls.Add(this.addResBtn);
            this.Controls.Add(this.resComboBox);
            this.Controls.Add(this.resLbl);
            this.Controls.Add(this.folderLbl);
            this.Controls.Add(this.folderTxtbx);
            this.Controls.Add(this.addFolderBtn);
            this.Controls.Add(this.deleteFoldersBtn);
            this.Controls.Add(this.folderView);
            this.Name = "Form";
            this.Text = "Jims background changer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView folderView;
        private System.Windows.Forms.ColumnHeader folderCollumn;
        private System.Windows.Forms.Button deleteFoldersBtn;
        private System.Windows.Forms.Button addFolderBtn;
        private System.Windows.Forms.TextBox folderTxtbx;
        private System.Windows.Forms.Label folderLbl;
        private System.Windows.Forms.Label resLbl;
        private System.Windows.Forms.ComboBox resComboBox;
        private System.Windows.Forms.Button addResBtn;
        private System.Windows.Forms.Button deleteResBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button browseBtn;
    }
}

