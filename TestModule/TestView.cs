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

namespace TestModule
{
    public partial class TestView : Form
    {
        private IFilesChooser filesChooser;

        public TestView()
        {
            InitializeComponent();
        }

        public TestView(IFilesChooser filesChooser)
        {
            this.filesChooser = filesChooser;
            InitializeComponent();
        }

        private void TestView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = filesChooser.ShowChooserDialog();
            this.label1.Text = "Status: " + result.ToString();
            this.label2.Text = "Liczba zaznaczonych elementów: " + filesChooser.GetFilesList().Count.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for (double x = 0; x < Math.PI; x += Math.PI / 180.0)
            {
                chart1.Series["sinus"].Points.AddXY(x, Math.Sin(x));
            }
        }
    }
}
