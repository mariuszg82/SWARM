using SWARM.Controller;
using SWARM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestModule
{
    public class Test : ISwarmModule
    {
        private IFilesChooser filesChooser;
        private Form parentForm;

        public string GetExtension {
            get
            {
                return "prn";
            }
        }

        public string GetDescription
        {
            get
            {
                return "Moduł testowy";
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
            TestView view = new TestView(filesChooser);
            view.MdiParent = parentForm;
            view.Show();
        }
    }
}
