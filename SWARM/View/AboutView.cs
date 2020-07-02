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
    public partial class AboutView : Form
    {
        public AboutView()
        {
            InitializeComponent();
            FillLabels();
            closeBtn.Click += CloseAction;
        }

        private void FillLabels()
        {
            this.appName.Text = Application.ProductName;
            this.version.Text = Application.ProductVersion;
            this.author.Text = Application.CompanyName;
        }

        private void CloseAction(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
