using SWARM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWARM.Controller
{
    public class ConfigurationController
    {
        private ConfigurationView view;

        public ConfigurationController()
        {
        }

        public void ShowConfigurationDialog()
        {
            if (view == null)
            {
                view = new ConfigurationView(this);
            }
            view.UpdateView();
            view.ShowDialog();
        }

        public void CloseConfigurationDialog()
        {
            if (view != null)
            {
                view.Close();
            }
        }
    }
}
