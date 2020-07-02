using SWARM.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWARM.View
{
    public partial class ConfigurationView : Form
    {
        private ConfigurationController controller;

        private ConfigurationView()
        {
            InitializeComponent();
        }

        public ConfigurationView(ConfigurationController controller)
        {
            InitializeComponent();
            this.controller = controller;
            UpdateFields();
            InitButtons();
        }

        public void UpdateView()
        {
            UpdateFields();
        }

        private void UpdateFields()
        {
            this.zNud.Value = Int32.Parse(Environment.GetEnvironmentVariable("z"));
            this.dirTB.Text = Environment.CurrentDirectory;
        }

        private void InitButtons()
        {
            dirBtn.Click += PickPrnDir;
            saveBtn.Click += SaveButton;
            useBtn.Click += UseButton;
            cancelBtn.Click += CloseDialog;
        }

        private void CopyToGlobalConfig()
        {
            Environment.SetEnvironmentVariable("z", this.zNud.Value.ToString());
            Environment.CurrentDirectory = this.dirTB.Text;
        }

        private void CloseDialog(object sender, EventArgs e)
        {
            UpdateFields();
            controller.CloseConfigurationDialog();
        }

        private void UseButton(object sender, EventArgs e)
        {
            CopyToGlobalConfig();
            controller.CloseConfigurationDialog();
        }

        private void SaveButton(object sender, EventArgs e)
        {
            CopyToGlobalConfig();
            if (GlobalConfig.SaveConfig())
            {
                controller.CloseConfigurationDialog();
            }
        }

        private void PickPrnDir(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                SelectedPath = dirTB.Text,
                ShowNewFolderButton = true
            };
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                dirTB.Text = folderDlg.SelectedPath;
            }
        }
    }
}
