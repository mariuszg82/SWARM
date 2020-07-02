using AverageModule.View;
using SWARM.Controller;
using SWARM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AverageModule
{
    public class AverageModule : ISwarmModule
    {
        private IFilesChooser filesChooser;
        private Form parentForm;

        public string GetExtension
        {
            get
            {
                return "prn";
            }
        }

        public string GetDescription
        {
            get
            {
                return "Uśrednianie";
            }
        }

        public bool IsExcluding
        {
            get
            {
                return false;
            }
        }

        public string GetExcludedFileName
        {
            get
            {
                return "";
            }
        }

        public void SetFileChooser(IFilesChooser filesChooser)
        {
            this.filesChooser = filesChooser;
        }

        public void SetMdiParent(Form form)
        {
            this.parentForm = form;
        }

        public void ShowWindow()
        {
            AverageView view = new AverageView(filesChooser);
            view.MdiParent = parentForm;
            view.Show();
        }
    }
}
