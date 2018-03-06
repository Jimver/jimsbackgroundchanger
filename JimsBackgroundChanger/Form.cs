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
        private Settings _settings;

        public Form()
        {
            InitializeComponent();
            _settings = Settings.Load();
            UpdateUi(_settings.Copy());
        }

        private void UpdateUi(Settings settings)
        {
            RegistryKey jpegHack = Registry.CurrentUser.OpenSubKey
                ("Control Panel\\Desktop", true);
            var val = jpegHack?.GetValue("JPEGImportQuality");
            if (jpegHack != null && val != null)
            {
                jpegHackChkBx.Checked = (int) val == 100;
            }
            else jpegHackChkBx.Checked = false;

            startupChkBx.Checked = settings.Startup;
            folderView.Items.Clear();
            folderView.Groups.Clear();
            resComboBox.Items.Clear();
            cliTextBox.Text = settings.CliCommand;
            argsTextBox.Text = settings.CliArgs;
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
                _settings.Resolutions.Find(res => res.Equals(ConvertRes(folder.Group.Header))).Folders
                    .Remove(folder.Text);
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
                _settings.Resolutions.Add(ConvertRes());
                UpdateUi(_settings);
            }
        }

        private void deleteResBtn_Click(object sender, EventArgs e)
        {
            if (_settings.Resolutions.Contains(ConvertRes()))
            {
                _settings.Resolutions.Remove(ConvertRes());
                UpdateUi(_settings);
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
                if (_settings.Resolutions.Contains(ConvertRes()))
                {
                    Settings.Resolution resolution = ConvertRes();
                    _settings.Resolutions
                        .Single(res => res.Width == resolution.Width && res.Height == resolution.Height)
                        .Folders.Add(folderTxtbx.Text);
                    UpdateUi(_settings);
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

        private Settings.Resolution ConvertRes(string res)
        {
            string[] splitRes = res.Split('x');
            if (splitRes.Length == 0 || splitRes.Length != 2 || !int.TryParse(splitRes[0], out var width) ||
                !int.TryParse(splitRes[1], out var height))
            {
                return null;
            }

            return new Settings.Resolution(width, height, new List<string>());
        }

        private Settings.Resolution ConvertRes()
        {
            return ConvertRes(resComboBox.Text);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            _settings.Save();
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (_settings.Startup)
            {
                rk?.SetValue(AppName, Application.ExecutablePath);
            }
            else
            {
                rk?.DeleteValue(AppName, false);
            }

            Wallpaper.SetSlideShow(_settings, Wallpaper.GetResolution());
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
            _settings = new Settings(_settings.Resolutions, startupChkBx.Checked, cliTextBox.Text, argsTextBox.Text);
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

        private void jpegHackChkBx_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey jpegHack = Registry.CurrentUser.OpenSubKey
                ("Control Panel\\Desktop", true);
            if (jpegHackChkBx.Checked)
            {
                jpegHack?.SetValue("JPEGImportQuality", 100, RegistryValueKind.DWord);
            }
            else
            {
                jpegHack?.DeleteValue("JPEGImportQuality");
            }
        }

        private void cliTest_Click(object sender, EventArgs e)
        {
            try
            {
                Command.Result result = Command.Run(cliTextBox.Text, argsTextBox.Text);
                if (result.ExitCode != 0)
                {
                    MessageBox.Show(
                        // ReSharper disable once LocalizableElement
                        $"Exit code: {result.ExitCode}\nShell output: {result.Output}\nError output: {result.Error}",
                        @"Test failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // ReSharper disable once LocalizableElement
                    MessageBox.Show($"Exit code: {result.ExitCode}\nShell output: {result.Output}",
                        @"Test succeeded", MessageBoxButtons.OK);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cliTextBox_TextChanged(object sender, EventArgs e)
        {
            _settings = new Settings(_settings.Resolutions, _settings.Startup, cliTextBox.Text, argsTextBox.Text);
        }

        private void argsTextBox_TextChanged(object sender, EventArgs e)
        {
            _settings = new Settings(_settings.Resolutions, _settings.Startup, cliTextBox.Text, argsTextBox.Text);
        }
    }
}