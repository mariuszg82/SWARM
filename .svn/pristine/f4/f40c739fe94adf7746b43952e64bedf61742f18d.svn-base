using SWARM.Controller;
using SWARM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWARM
{
    public partial class MainForm : Form
    {
        private MainFormController controller;
        private ConfigurationController configurationController;
        private IFilesChooser filesChooser;
        private readonly string MODULE_PATH = Application.StartupPath + "\\modules";

        private MainForm()
        {
            InitializeComponent();
        }

        public MainForm(MainFormController controller)
        {
            InitializeComponent();
            this.controller = controller;
            configurationController = new ConfigurationController();
            InitMenuItems();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(MODULE_PATH);
            foreach (FileInfo file in directory.GetFiles())
            {
                Assembly assembly = Assembly.LoadFrom(file.FullName);
                Type[] types = assembly.GetTypes().Where(type => type.IsClass && type.GetInterface("ISwarmModule") != null).ToArray();

                foreach (Type type in types)
                {
                    ISwarmModule module = (ISwarmModule)Activator.CreateInstance(type);
                    ToolStripMenuItem moduleItem = new ToolStripMenuItem(module.GetDescription);
                    moduleToolStripMenuItem.DropDownItems.Add(moduleItem);
                    //filesChooser = new FilesChooserView(module.GetExtension);
                    moduleItem.Click += (s, ea) =>
                    {
                        module.SetMdiParent(this);
                        if (module.IsExcluding)
                        {
                            module.SetFileChooser(new FilesChooserView(module.GetExtension, module.GetExcludedFileName));
                        } else
                        {
                        module.SetFileChooser(new FilesChooserView(module.GetExtension));
                        }
                        module.ShowWindow();
                    };
                }
            }
        }

        private void InitMenuItems()
        {
            aboutProgramieToolStripMenuItem.Click += ShowAboutDialog;
            configurationToolStripMenuItem.Click += ShowConfigurationDialog;
            closeToolStripMenuItem.Click += CloseApplication;
            sideBySideToolStripMenuItem.Click += SideBySideToolStripMenuItem_Click;
            cascadeToolStripMenuItem.Click += CascadeToolStripMenuItem_Click;
        }

        private void ShowAboutDialog (object sender, EventArgs e)
        {
            controller.ShowAboutDialog();
        }

        private void CloseApplication (object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void ShowConfigurationDialog (object sender, EventArgs e)
        {
            configurationController.ShowConfigurationDialog();
        }

        private void SideBySideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
    }
}
