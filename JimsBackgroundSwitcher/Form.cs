using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using JimsBackgroundChanger.Properties;
using Microsoft.Win32;

namespace JimsBackgroundChanger
{
    public partial class Form : System.Windows.Forms.Form
    {
        private static string AppName = "Jim's Background Changer";
        private Settings settings;

        public Form()
        {
            InitializeComponent();
            settings = Settings.Load();
            UpdateUi();
        }

        private void UpdateUi()
        {
            startupChkBx.Checked = settings.Startup;
            folderView.Items.Clear();
            folderView.Groups.Clear();
            resComboBox.Items.Clear();
            foreach (Settings.Resolution resolution in settings.Resolutions)
            {
                ListViewGroup group = new ListViewGroup("res" + settings.Resolutions.IndexOf(resolution),
                    resolution.ToString());
                folderView.Groups.Add(group);
                resComboBox.Items.Add(resolution.ToString());
                foreach (string folder in resolution.Folders)
                {
                    var folderItem = folderView.Items.Add(folder);
                    folderItem.Group = group;
                }
            }
        }

        private void deleteFoldersBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem folder in folderView.CheckedItems)
            {
                folderView.Items.Remove(folder);
            }
        }

        private void addResBtn_Click(object sender, EventArgs e)
        {
            if (ConvertRes() == null)
            {
                MessageBox.Show(Resources.Invalid_Resolution_Message,
                    Resources.Invalid_Resolution_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                settings.Resolutions.Add(ConvertRes());
                UpdateUi();
            }
        }

        private void deleteResBtn_Click(object sender, EventArgs e)
        {
            if (settings.Resolutions.Contains(ConvertRes()))
            {
                settings.Resolutions.Remove(ConvertRes());
                UpdateUi();
                resComboBox.ResetText();
            }
            else
            {
                MessageBox.Show(Resources.Delete_Input_Message,
                    Resources.Delete_Input_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addFolderBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(folderTxtbx.Text))
            {
                if (settings.Resolutions.Contains(ConvertRes()))
                {
                    Settings.Resolution resolution = ConvertRes();
                    settings.Resolutions.Single(res => res.Width == resolution.Width && res.Height == resolution.Height)
                        .Folders.Add(folderTxtbx.Text);
                    UpdateUi();
                }
                else
                {
                    MessageBox.Show(Resources.Invalid_Resolution_Message, Resources.Invalid_Resolution_Caption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Resources.Folder_Input_Message, Resources.Folder_Input_Caption, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private Settings.Resolution ConvertRes()
        {
            string[] splitRes = resComboBox.Text.Split('x');
            int width, height;
            if (splitRes.Length == 0 || splitRes.Length != 2 || !int.TryParse(splitRes[0], out width) ||
                !int.TryParse(splitRes[1], out height))
            {
                return null;
            }
            return new Settings.Resolution(width, height, new List<string>());
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            settings.Save();
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (settings.Startup)
            {
                rk?.SetValue(AppName, Application.ExecutablePath);
            }
            else
                rk?.DeleteValue(AppName, false);
            Wallpaper.SetSlideShow(settings, Wallpaper.GetResolution());
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            Wallpaper.NextWallpaper();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderTxtbx.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void startupChkBx_CheckedChanged(object sender, EventArgs e)
        {
            settings.Startup = startupChkBx.Checked;
        }

        private void Form_Resize(object sender, EventArgs e)
        { 
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void nextWallPaper_Click(object sender, EventArgs e)
        {
            Wallpaper.NextWallpaper();
        }

        private void refreshScreens_Click(object sender, EventArgs e)
        {
            Wallpaper.SystemEvents_DisplaySettingsChanged(this, new EventArgs());
        }
    }
}