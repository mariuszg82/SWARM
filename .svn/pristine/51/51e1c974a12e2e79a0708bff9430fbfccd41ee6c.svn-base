using SWARM.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace SWARM.View
{
    public partial class FilesChooserView : Form, IFilesChooser
    {
        private DialogResult result;
        private FilesChooserController controller;
        private String ext = "*";
        IntPtr handle;

        public FilesChooserView(String extension)
        {
            InitializeComponent();
            if (!this.IsHandleCreated)
            {
                handle = Handle;
            }
            controller = new FilesChooserController();
            ext = extension;
            Init();
            InitButtons();
        }

        public FilesChooserView(string extension, string excludedFileName)
        {
            InitializeComponent();
            if (!this.IsHandleCreated)
            {
                handle = Handle;
            }
            controller = new FilesChooserController(excludedFileName);
            ext = extension;
            Init();
            InitButtons();
        }

        private void InitButtons()
        {
            dirBtn.Click += SelectDirectory;
            selectAllBtn.Click += SelectAll;
            unselectAllBtn.Click += UnSelectAll;
            invertSelectionBtn.Click += InvertSelection;
            acceptBtn.DialogResult = DialogResult.OK;
            cancelBtn.DialogResult = DialogResult.Cancel;
            acceptBtn.Click += AcceptButtonClick;
            cancelBtn.Click += CancelButtonClick;
            AcceptButton = acceptBtn;
            CancelButton = cancelBtn;
        }

        private void Init()
        {
            directoryTB.Text = Environment.CurrentDirectory;
            FillFilesListBox(controller.GetAllFiles(ext));
        }

        private void ClearGui()
        {
            directoryTB.Clear();
            filesBox.Items.Clear();
        }

        private void SelectDirectory(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                SelectedPath = directoryTB.Text,
                ShowNewFolderButton = false
            };
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                directoryTB.Text = folderDlg.SelectedPath;
                Environment.CurrentDirectory = folderDlg.SelectedPath;
            }
            filesBox.Items.Clear();
            FillFilesListBox(controller.GetAllFiles(ext));
        }

        private void FillFilesListBox(List<String> files)
        {   
            if (files.Count != 0)
            {
                Action action = () =>
                {
                    foreach (String fileName in files)
                    {
                        filesBox.Items.Add(Path.GetFileName(fileName));
                    }
                };
                BeginInvoke(action);
            }
        }

        private void SelectAll(object sender, EventArgs e)
        {
            if (filesBox.Items.Count != 0)
            {
                Action action = () =>
                {
                    for (int i = 0; i < filesBox.Items.Count; i++)
                    {
                        filesBox.SetItemChecked(i, true);
                    }
                };
                BeginInvoke(action);
            }
        }

        private void UnSelectAll(object sender, EventArgs e)
        {
            if (filesBox.Items.Count != 0)
            {
                Action action = () =>
                {
                    for (int i = 0; i < filesBox.Items.Count; i++)
                    {
                        filesBox.SetItemChecked(i, false);
                    }
                };
                BeginInvoke(action);
            }
        }

        private void InvertSelection(object sender, EventArgs e)
        {
            if (filesBox.Items.Count != 0)
            {
                Action action = () =>
                {
                    for (int i = 0; i < filesBox.Items.Count; i++)
                    {
                        bool state = filesBox.GetItemChecked(i);
                        filesBox.SetItemChecked(i, !state);
                    }
                };
                BeginInvoke(action);
            }
        }

        private void AcceptButtonClick(object sender, EventArgs e)
        {
            List<String> tmp = new List<String>();

            foreach (object item in filesBox.CheckedItems)
            {
                tmp.Add(item.ToString());
            }
            controller.SetSelectedFiles(tmp);
            result = DialogResult.OK;
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            controller.SetSelectedFiles(new List<String>());
            Action action = () =>
            {
                for (int i = 0; i < filesBox.Items.Count; i++)
                {
                    filesBox.SetItemChecked(i, false);
                }
            };
            BeginInvoke(action);
            result = DialogResult.Cancel;
        }

        public void CloseDialog()
        {
            this.Close();
        }

        public string GetDirectory()
        {
            return Environment.CurrentDirectory;
        }

        public List<string> GetFilesList()
        {
            return controller.GetSelectedFiles();
        }

        public void SetExtension(string extension)
        {
            ext = extension;
        }

        public void SetController(FilesChooserController controller)
        {
            this.controller = controller;
        }

        public void SetExcludedFile(string fileName)
        {
            this.controller.ExcludeFile(fileName);
        }

        public DialogResult ShowChooserDialog()
        {
            directoryTB.Text = Environment.CurrentDirectory;
            ShowDialog();
            return result;
        }
    }
}
