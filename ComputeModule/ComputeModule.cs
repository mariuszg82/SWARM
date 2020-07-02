using ComputeModule.View;
using SWARM.Controller;
using SWARM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputeModule
{
    public class ComputeModule : ISwarmModule
    {
        private IFilesChooser filesChooser;
        private Form parentForm;

        public string GetExtension
        {
            get
            {
                return "dat";
            }
        }

        public string GetDescription
        {
            get
            {
                return "Obliczanie";
            }
        }

        public bool IsExcluding
        {
            get
            {
                return true;
            }
        }

        public string GetExcludedFileName
        {
            get
            {
                return "STALE.DAT";
            }
        }

        public void SetFileChooser(IFilesChooser filesChooser)
        {
            this.filesChooser = filesChooser;
        }

        public void SetMdiParent(Form form)
        {
            parentForm = form;
        }

        public void ShowWindow()
        {
            ComputeView view = new ComputeView(filesChooser);
            view.MdiParent = parentForm;
            view.Show();
        }
    }
}
