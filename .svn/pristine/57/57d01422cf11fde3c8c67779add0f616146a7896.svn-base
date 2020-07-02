using AverageModule.Controller;
using AverageModule.Model;
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

namespace AverageModule.View
{
    public partial class AverageView : Form, IAverageView
    {
        #region origin_consts
        private readonly int CONST_L3 = 250;
        #endregion origin_consts

        private IFilesChooser filesChooser;
        private AverageController controller;
        private bool isChartVisible = true;
        private readonly Point closeBtnUpperPosition = new Point(578, 150);
        private readonly Point closeBtnLowerPosition = new Point(578, 596);
        private readonly Size windowBiggerSize = new Size(698, 666);
        private readonly Size windowSmallerSize = new Size(698, 220);
        private List<String> files;
        private ChartArea averageArea;
        private List<ChartModel> models;

        IntPtr handle;

        private AverageView()
        {
            InitializeComponent();
            if (!IsHandleCreated)
            {
                handle = Handle;
            }
        }

        public AverageView(IFilesChooser filesChooser)
        {
            InitializeComponent();
            if (!IsHandleCreated)
            {
                handle = Handle;
            }
            this.filesChooser = filesChooser;
            controller = new AverageController(this);
            InitButtons();
            PrepareChart();
        }

        private void InitButtons()
        {
            zConstTb.Text = Environment.GetEnvironmentVariable("z");
            showChartCb.Checked = isChartVisible;
            zConstTb.KeyPress += zConstTb_KeyPress;
            showChartCb.CheckedChanged += showChartCb_CheckedChanged;
            resultCB.SelectedIndexChanged += ResultCB_SelectedIndexChanged;
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
            ClearResCB();
            InProcessingState();
            averagingProgressBar.Minimum = 0;
            averagingProgressBar.Maximum = files.Count();
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

        private void ResultCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            string selectedItem = (string)comboBox.SelectedItem;
            int resultIndex = -1;

            resultIndex = comboBox.FindStringExact(selectedItem);

            Action action = () =>
            {
                if (resultIndex == 0)
                {
                    averageChart.Series.Clear();
                }
                else
                {
                    ChartModel chartModel = models.Single(n => n.SeriesName.Equals(selectedItem));
                    averageChart.Series.Clear();
                    averageArea.AxisX.Interval = chartModel.XAxisParams.interval;
                    averageArea.AxisX.Maximum = chartModel.XAxisParams.max;
                    averageArea.AxisX.Minimum = chartModel.XAxisParams.min;

                    averageArea.AxisY.Interval = chartModel.YAxisParams.interval;
                    averageArea.AxisY.Maximum = chartModel.YAxisParams.max;
                    averageArea.AxisY.Minimum = chartModel.YAxisParams.min;

                    averageChart.Series.Add(chartModel.Serie);

                    poczsrResultL.Text = chartModel.POCZSR.ToString();
                    skResultL.Text = chartModel.SK.ToString();
                }
            };

            BeginInvoke(action);

        }

        private void CloseBtnTogglePosition()
        {
            if (isChartVisible)
            {
                closeBtn.Location = closeBtnLowerPosition;
            }
            else
            {
                closeBtn.Location = closeBtnUpperPosition;
            }
        }

        private void WindowToggleSize()
        {
            if (isChartVisible)
            {
                Size = windowBiggerSize;
            }
            else
            {
                Size = windowSmallerSize;
            }
        }

        private void showChartCb_CheckedChanged(object sender, EventArgs e)
        {
            isChartVisible = !isChartVisible;
            averageChart.Visible = isChartVisible;
            CloseBtnTogglePosition();
            WindowToggleSize();
            resultL.Visible = isChartVisible;
            resultCB.Visible = isChartVisible;
        }

        private void InitState()
        {
            filesBtn.Enabled = true;
            zConstTb.Enabled = true;
            startBtn.Enabled = false;
            averagingProgressBar.Enabled = false;
            stopBtn.Enabled = false;
            showChartCb.Enabled = true;
            closeBtn.Enabled = true;
            resultL.Enabled = true;
            resultCB.Enabled = false;
        }

        private void InProcessingState()
        {
            filesBtn.Enabled = false;
            zConstTb.Enabled = false;
            startBtn.Enabled = false;
            averagingProgressBar.Enabled = true;
            stopBtn.Enabled = true;
            showChartCb.Enabled = false;
            closeBtn.Enabled = false;
            resultL.Enabled = true;
            resultCB.Enabled = false;
        }

        private void AfterProcessingState()
        {
            filesBtn.Enabled = false;
            zConstTb.Enabled = false;
            startBtn.Enabled = false;
            averagingProgressBar.Enabled = true;
            stopBtn.Enabled = false;
            showChartCb.Enabled = false;
            closeBtn.Enabled = true;
            resultL.Enabled = true;
            resultCB.Enabled = true;
        }

        private void AfterChoosingFiles()
        {
            if (files != null && files.Count > 0)
            {
                filesBtn.Enabled = true;
                zConstTb.Enabled = true;
                startBtn.Enabled = true;
                averagingProgressBar.Enabled = false;
                stopBtn.Enabled = false;
                showChartCb.Enabled = true;
                closeBtn.Enabled = true;
            }
            else
            {
                startBtn.Enabled = false;
            }
        }

        private void PrepareChart()
        {
            averageArea = new ChartArea();
            averageArea.AxisX.MajorGrid.Enabled = false;
            averageArea.AxisX.MajorTickMark.Enabled = false;
            averageArea.AxisX.Title = "Czas, µs";
            averageArea.AxisY.MajorGrid.Enabled = false;
            averageArea.AxisY.Title = "PH";
            averageArea.Name = "averageArea";
            averageChart.ChartAreas.Add(averageArea);
            averageChart.Location = new Point(12, 168);
            averageChart.Name = "averageChart";
            averageChart.Size = new Size(658, 422);
            averageChart.TabIndex = 2;
            averageChart.Text = "Uśrednianie";
        }

        public void UpdateProgres()
        {
            Action action = () =>
            {
                averagingProgressBar.Increment(1);

            };
            BeginInvoke(action);
        }

        public void UpdateGui(List<ChartModel> seriesList)
        {
            Action action = () =>
            {
                ClearResCB();
                models = seriesList;
                foreach (ChartModel model in models)
                {
                    resultCB.Items.Add(model.SeriesName);
                }
                AfterProcessingState();
            };

            BeginInvoke(action);
        }

        private void ClearResCB()
        {
            resultCB.Items.Clear();
            resultCB.Items.Add("Wybierz");
            resultCB.SelectedIndex = 0;
        }
    }
}
