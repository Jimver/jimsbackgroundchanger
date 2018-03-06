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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("1920x1080", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("3440x1440", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("folder1");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("folder2");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("folder3");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
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
            this.startupChkBx = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nextWallPaper = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshScreens = new System.Windows.Forms.ToolStripMenuItem();
            this.jpegHackChkBx = new System.Windows.Forms.CheckBox();
            this.cliTextBox = new System.Windows.Forms.TextBox();
            this.cliLabel = new System.Windows.Forms.Label();
            this.cliTest = new System.Windows.Forms.Button();
            this.argsTextBox = new System.Windows.Forms.TextBox();
            this.argLabel = new System.Windows.Forms.Label();
            this.notifyContextMenuStrip.SuspendLayout();
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
            listViewGroup3.Header = "1920x1080";
            listViewGroup3.Name = "res1";
            listViewGroup4.Header = "3440x1440";
            listViewGroup4.Name = "res2";
            this.folderView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            listViewItem4.Group = listViewGroup3;
            listViewItem4.StateImageIndex = 0;
            listViewItem4.ToolTipText = "lel";
            listViewItem5.Group = listViewGroup3;
            listViewItem5.StateImageIndex = 0;
            listViewItem5.ToolTipText = "f2";
            listViewItem6.Group = listViewGroup4;
            listViewItem6.StateImageIndex = 0;
            listViewItem6.ToolTipText = "fu";
            this.folderView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.folderView.LabelEdit = true;
            this.folderView.Location = new System.Drawing.Point(12, 172);
            this.folderView.Name = "folderView";
            this.folderView.Size = new System.Drawing.Size(591, 194);
            this.folderView.TabIndex = 15;
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
            this.deleteFoldersBtn.Location = new System.Drawing.Point(12, 372);
            this.deleteFoldersBtn.Name = "deleteFoldersBtn";
            this.deleteFoldersBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteFoldersBtn.TabIndex = 16;
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
            this.addFolderBtn.TabIndex = 3;
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
            this.folderTxtbx.TabIndex = 1;
            // 
            // folderLbl
            // 
            this.folderLbl.AutoSize = true;
            this.folderLbl.Location = new System.Drawing.Point(12, 17);
            this.folderLbl.Name = "folderLbl";
            this.folderLbl.Size = new System.Drawing.Size(42, 13);
            this.folderLbl.TabIndex = 0;
            this.folderLbl.Text = "Folder :";
            // 
            // resLbl
            // 
            this.resLbl.AutoSize = true;
            this.resLbl.Location = new System.Drawing.Point(12, 46);
            this.resLbl.Name = "resLbl";
            this.resLbl.Size = new System.Drawing.Size(63, 13);
            this.resLbl.TabIndex = 4;
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
            this.resComboBox.TabIndex = 5;
            // 
            // addResBtn
            // 
            this.addResBtn.Location = new System.Drawing.Point(211, 46);
            this.addResBtn.Name = "addResBtn";
            this.addResBtn.Size = new System.Drawing.Size(75, 23);
            this.addResBtn.TabIndex = 6;
            this.addResBtn.Text = "Add";
            this.addResBtn.UseVisualStyleBackColor = true;
            this.addResBtn.Click += new System.EventHandler(this.addResBtn_Click);
            // 
            // deleteResBtn
            // 
            this.deleteResBtn.Location = new System.Drawing.Point(292, 46);
            this.deleteResBtn.Name = "deleteResBtn";
            this.deleteResBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteResBtn.TabIndex = 7;
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
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(528, 372);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(409, 372);
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
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // startupChkBx
            // 
            this.startupChkBx.AutoSize = true;
            this.startupChkBx.Location = new System.Drawing.Point(12, 78);
            this.startupChkBx.Name = "startupChkBx";
            this.startupChkBx.Size = new System.Drawing.Size(93, 17);
            this.startupChkBx.TabIndex = 8;
            this.startupChkBx.Text = "Run at startup";
            this.startupChkBx.UseVisualStyleBackColor = true;
            this.startupChkBx.CheckedChanged += new System.EventHandler(this.startupChkBx_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Jim\'s Background Changer";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyContextMenuStrip
            // 
            this.notifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextWallPaper,
            this.refreshScreens});
            this.notifyContextMenuStrip.Name = "notifyContextMenuStrip";
            this.notifyContextMenuStrip.Size = new System.Drawing.Size(157, 48);
            // 
            // nextWallPaper
            // 
            this.nextWallPaper.Name = "nextWallPaper";
            this.nextWallPaper.Size = new System.Drawing.Size(156, 22);
            this.nextWallPaper.Text = "Next Wallpaper";
            this.nextWallPaper.Click += new System.EventHandler(this.nextWallPaper_Click);
            // 
            // refreshScreens
            // 
            this.refreshScreens.Name = "refreshScreens";
            this.refreshScreens.Size = new System.Drawing.Size(156, 22);
            this.refreshScreens.Text = "Refresh Screens";
            this.refreshScreens.Click += new System.EventHandler(this.refreshScreens_Click);
            // 
            // jpegHackChkBx
            // 
            this.jpegHackChkBx.AutoSize = true;
            this.jpegHackChkBx.Location = new System.Drawing.Point(13, 101);
            this.jpegHackChkBx.Name = "jpegHackChkBx";
            this.jpegHackChkBx.Size = new System.Drawing.Size(113, 17);
            this.jpegHackChkBx.TabIndex = 9;
            this.jpegHackChkBx.Text = "JPEG quality hack";
            this.jpegHackChkBx.UseVisualStyleBackColor = true;
            this.jpegHackChkBx.CheckedChanged += new System.EventHandler(this.jpegHackChkBx_CheckedChanged);
            // 
            // cliTextBox
            // 
            this.cliTextBox.Location = new System.Drawing.Point(82, 124);
            this.cliTextBox.Name = "cliTextBox";
            this.cliTextBox.Size = new System.Drawing.Size(191, 20);
            this.cliTextBox.TabIndex = 11;
            this.cliTextBox.TextChanged += new System.EventHandler(this.cliTextBox_TextChanged);
            // 
            // cliLabel
            // 
            this.cliLabel.AutoSize = true;
            this.cliLabel.Location = new System.Drawing.Point(12, 127);
            this.cliLabel.Name = "cliLabel";
            this.cliLabel.Size = new System.Drawing.Size(66, 13);
            this.cliLabel.TabIndex = 10;
            this.cliLabel.Text = "On change: ";
            // 
            // cliTest
            // 
            this.cliTest.Location = new System.Drawing.Point(528, 122);
            this.cliTest.Name = "cliTest";
            this.cliTest.Size = new System.Drawing.Size(75, 23);
            this.cliTest.TabIndex = 14;
            this.cliTest.Text = "Test";
            this.cliTest.UseVisualStyleBackColor = true;
            this.cliTest.Click += new System.EventHandler(this.cliTest_Click);
            // 
            // argsTextBox
            // 
            this.argsTextBox.Location = new System.Drawing.Point(358, 125);
            this.argsTextBox.Name = "argsTextBox";
            this.argsTextBox.Size = new System.Drawing.Size(164, 20);
            this.argsTextBox.TabIndex = 13;
            this.argsTextBox.TextChanged += new System.EventHandler(this.argsTextBox_TextChanged);
            // 
            // argLabel
            // 
            this.argLabel.AutoSize = true;
            this.argLabel.Location = new System.Drawing.Point(289, 128);
            this.argLabel.Name = "argLabel";
            this.argLabel.Size = new System.Drawing.Size(63, 13);
            this.argLabel.TabIndex = 12;
            this.argLabel.Text = "Arguments: ";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 407);
            this.Controls.Add(this.argLabel);
            this.Controls.Add(this.argsTextBox);
            this.Controls.Add(this.cliTest);
            this.Controls.Add(this.cliLabel);
            this.Controls.Add(this.cliTextBox);
            this.Controls.Add(this.jpegHackChkBx);
            this.Controls.Add(this.startupChkBx);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Text = "Jims Background Changer";
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.notifyContextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox startupChkBx;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem nextWallPaper;
        private System.Windows.Forms.ToolStripMenuItem refreshScreens;
        private System.Windows.Forms.CheckBox jpegHackChkBx;
        private System.Windows.Forms.TextBox cliTextBox;
        private System.Windows.Forms.Label cliLabel;
        private System.Windows.Forms.Button cliTest;
        private System.Windows.Forms.TextBox argsTextBox;
        private System.Windows.Forms.Label argLabel;
    }
}

