using ComputeModule.Controller;
using ComputeModule.Model;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace ComputeModule.View
{
    public partial class ComputeView : Form, IComputeView
    {
        private IFilesChooser filesChooser;
        private ComputeController controller;
        private List<string> files;

        IntPtr handle;

        private ComputeView()
        {
            InitializeComponent();
            if (!IsHandleCreated)
            {
                handle = Handle;
            }
        }

        public ComputeView(IFilesChooser filesChooser)
        {
            InitializeComponent();
            if (!IsHandleCreated)
            {
                handle = Handle;
            }
            this.filesChooser = filesChooser;
            this.filesChooser.SetExcludedFile("STALE.DAT");
            controller = new ComputeController(this);
            InitButtons();
        }

        private void InitState()
        {
            filesBtn.Enabled = true;
            zConstTb.Enabled = true;
            startBtn.Enabled = false;
            computingProgressBar.Enabled = false;
            stopBtn.Enabled = false;
            closeBtn.Enabled = true;
            resultTabs.Enabled = false;
        }

        private void InProcessingState()
        {
            filesBtn.Enabled = false;
            zConstTb.Enabled = false;
            startBtn.Enabled = false;
            computingProgressBar.Enabled = true;
            stopBtn.Enabled = true;
            closeBtn.Enabled = false;
            resultTabs.Enabled = false;
        }

        private void AfterProcessingState()
        {
            filesBtn.Enabled = false;
            zConstTb.Enabled = false;
            startBtn.Enabled = false;
            computingProgressBar.Enabled = true;
            stopBtn.Enabled = false;
            closeBtn.Enabled = true;
            resultTabs.Enabled = true;
        }

        private void AfterChoosingFiles()
        {
            if (files != null && files.Count > 0)
            {
                filesBtn.Enabled = true;
                zConstTb.Enabled = true;
                startBtn.Enabled = true;
                computingProgressBar.Enabled = false;
                stopBtn.Enabled = false;
                closeBtn.Enabled = true;
            }
            else
            {
                startBtn.Enabled = false;
            }
        }

        private void InitButtons()
        {
            zConstTb.Text = Environment.GetEnvironmentVariable("z");
            zConstTb.KeyPress += zConstTb_KeyPress;
            closeBtn.Click += CloseWindow;
            filesBtn.Click += filesBtn_Click;
            startBtn.Click += StartBtn_Click;
            stopBtn.Click += StopBtn_Click;
            InitState();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!zConstTb.Text.Equals(Environment.GetEnvironmentVariable("z")))
            {
                Environment.SetEnvironmentVariable("z", zConstTb.Text);
            }
            InProcessingState();
            computingProgressBar.Minimum = 0;
            computingProgressBar.Maximum = files.Count();
            controller.SetFiles(files);
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            controller.CancelBtn_Click();
            AfterProcessingState();
        }

        private void zConstTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }

        private void filesBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = filesChooser.ShowChooserDialog();
            if (result.Equals(DialogResult.OK))
            {
                files = filesChooser.GetFilesList();
                filesL.Text = "Liczba plików: " + files.Count().ToString();
                AfterChoosingFiles();
            }
        }

        public void UpdateProgres()
        {
            Action action = () =>
            {
                computingProgressBar.Increment(1);
            };
            BeginInvoke(action);
        }

        public void UpdateGui(List<ResultTableStruct> seriesList)
        {
            Action action = () =>
            {
                DataGridViewRow row = (DataGridViewRow)viewGrid.Rows[0].Clone();
                foreach (ResultTableStruct model in seriesList)
                {
                    row = (DataGridViewRow)viewGrid.Rows[0].Clone();
                    row.Cells[0].Value = model.EP;
                    row.Cells[1].Value = model.A;
                    row.Cells[2].Value = model.W;
                    row.Cells[3].Value = model.K;
                    row.Cells[4].Value = model.KP;
                    row.Cells[5].Value = model.PD;
                    row.Cells[6].Value = model.PC;
                    row.Cells[7].Value = model.T;
                    row.Cells[8].Value = model.SQR;
                    row.Cells[9].Value = model.SK;
                    row.Cells[10].Value = model.lnK;
                    row.Cells[11].Value = model.odwT;
                    row.Cells[12].Value = model.PDcz;
                    row.Cells[13].Value = model.PCcz;
                    row.Cells[14].Value = model.w;
                    row.Cells[15].Value = model.T0;

                    viewGrid.Rows.Add(row);
                }
                AfterProcessingState();
                computeChart.Series.Add(PrepareChart(seriesList));
            };

            BeginInvoke(action);
        }

        private Series PrepareChart(List<ResultTableStruct> model)
        {
            ChartArea computeArea = new ChartArea();
            computeArea.AxisX.MajorGrid.Enabled = false;
            computeArea.AxisX.MajorTickMark.Enabled = false;
            computeArea.AxisX.Title = "E/P";
            computeArea.AxisY.MajorGrid.Enabled = false;
            computeArea.AxisY.Title = "K";
            computeArea.Name = "computeArea";
            computeArea.AxisX.Minimum = 0;
            computeArea.AxisX.Maximum = model.Count();
            computeChart.ChartAreas.Add(computeArea);

            Series serie = new Series();
            serie.ChartArea = "computeArea";
            serie.ChartType = SeriesChartType.Point;
            serie.IsVisibleInLegend = false;
            serie.MarkerSize = 1;
            serie.Name = "Stale";
            serie.XValueType = ChartValueType.Int32;
            serie.YValueType = ChartValueType.Double;
            serie.MarkerSize = 2;
            serie.MarkerColor = Color.Black;

            int counter = 1;

            foreach (ResultTableStruct item in model)
            {
                serie.Points.AddXY(counter, item.K);
                counter++;
            }

            return serie;
        }
    }
}
