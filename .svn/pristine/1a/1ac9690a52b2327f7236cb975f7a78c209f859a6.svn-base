using SWARM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWARM.Controller
{
    public class MainFormController
    {
        private MainForm mainForm;
        private AboutView aboutView;

        public MainFormController()
        {
            mainForm = new MainForm(this);
        }

        public void ShowWindow()
        {
            mainForm.ShowDialog();
        }

        public void ShowAboutDialog()
        {
            if (aboutView == null)
            {
                aboutView = new AboutView();
            }
            aboutView.ShowDialog();
        }

        
    }
}
