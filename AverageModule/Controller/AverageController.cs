using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using AverageModule.View;
using AverageModule.Model;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace AverageModule.Controller
{
    class AverageController
    {
        public AverageController(IAverageView view)
        {
            this.view = view;
        }

        private IAverageView view;
        private List<ChartModel> seriesList;
        private BackgroundWorker worker;
        private List<string> files;
        private int POCZSR = 0;
        private int SK = 0;
        private double L3 = 250d;
        private int[] A;

        public void SetFiles(List<string> list)
        {
            seriesList = new List<ChartModel>();
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += BackgroundWorker_DoWork;
            worker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            files = list;

            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        public void CancelBtn_Click()
        {
            worker.CancelAsync();
        }

        private bool IsFileLocked(string fullPath)
        {
            FileInfo file = new FileInfo(fullPath);
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int z = int.Parse(Environment.GetEnvironmentVariable("z"));
            PrepareXValues(z);
            foreach (string fullPath in files)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                AverageProcess(fullPath, z);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (seriesList.Count > 0)
            {
                view.UpdateGui(seriesList);
            }
        }

        private void PrepareXValues(int z)
        {
            double r = 400d / (z - 1);
            A = new int[z + 1];
            for (int i = 1; i <= z - 1; i++)
            {
                A[i] = Convert.ToInt32(Math.Truncate(50 + r * i));
            }
        }

        private void AverageProcess(string fullPath, int z)
        {
            SK = 0;
            int Z = z;
            int Z1 = Z - 1;
            int FK = 100;
            double TLO = 0, TLO1 = 0, BA = 0, Sx = 0, Sy = 0, Sxy = 0, Sx2 = 0, Apr = 0, Bpr = 0;
            int POCZ = 0, AI = 0, Kpr = 0, Lpr = 0, DP = 0;

            int iter = 0;

            string fileName = Path.GetFileNameWithoutExtension(fullPath);
            IEnumerable<string> lines = File.ReadLines(fullPath);
            string header = lines.ElementAt<string>(0);
            char[] delimiters = new char[] { ' ', '\t' };
            lines = lines.Where(u => !u.Equals(header)).ToList();
            string[] numbersLine = lines.ToArray<string>();
            double[] B = new double[Z + 1];
            double[] C = new double[Z + 1];
            double[] D = new double[Z + 1];
            double[] S = new double[Z + 1];
            double[] Apro = new double[Z + 1];
            double[] Pro = new double[Z + 1];

            for (int j = 0; j <= FK; j++)
            {
                TLO1 = 0;
                BA = 0;
                if (numbersLine.Length < iter + 1)
                {
                    continue;
                }

                string line = numbersLine[iter];
                string[] columnValues = (line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));

                for (int i = 1; i <= Z1; i++)
                {
                    B[i] = float.Parse(columnValues[i - 1]);
                }

                iter++;

                for (int i = 11; i <= Z1 - 1; i++)
                {
                    D[i] = (B[i + 1] + B[i] + B[i - 1]) / 3;
                }

                for (int i = 11; i <= Z - 1; i++)
                {
                    B[i] = D[i];
                }

                for (int i = 11; i <= Z1; i++)
                {
                    TLO1 = TLO1 + B[i];
                    TLO = TLO1 / (i - 10);
                    if (B[i] > TLO + 5)
                    {
                        POCZ = i;
                        break;
                    }
                }

                TLO1 = 0d;

                for (int i = 11; i <= POCZ - 5; i++)
                {
                    TLO1 = TLO1 + B[i];
                    TLO = TLO1 / (i - 10);
                }

                for (int i = 11; i <= Z1; i++)
                {
                    C[i] = B[i] - TLO;
                }

                for (int i = POCZ + 1; i <= Z1 - 50; i++)
                {
                    if (BA < C[i])
                    {
                        BA = C[i];
                        AI = i;
                    }
                }

                if (BA > 195 || BA < 20 || AI > 450 || POCZ < 40)
                {
                    continue;
                }

                for (int i = AI; i >= 1; i--)
                {
                    if (B[i] < TLO + 2)
                    {
                        POCZ = i - 2;
                        break;
                    }
                }

                if (POCZ < 50)
                {
                    // KROTKI_POCZ
                    if (j == 0)
                    {
                        POCZSR = POCZ;
                        L3 = 1.2d * BA;
                        continue;
                    }
                }

                Kpr = POCZ + 15;
                Lpr = 15;

                for (int i = POCZ - 30; i <= Kpr + 30; i++)
                {
                    Apro[i] = i + 1 - POCZ;
                }

                Sx = 0;
                Sy = 0;
                Sxy = 0;
                Sx2 = 0;

                for (int i = POCZ + 1; i <= Kpr; i++)
                {
                    Sx = Sx + Apro[i];
                    Sy = Sy + C[i];
                    Sxy = Sxy + Apro[i] * C[i];
                    Sx2 = Sx2 + (Apro[i] * Apro[i]);
                }

                Bpr = (Sx * Sy - Lpr * Sxy) / ((Sx * Sx) - Lpr * Sx2);
                Apr = (Sy - (Bpr * Sx)) / Lpr;

                for (int i = POCZ - 30; i <= Kpr + 40; i++)
                {
                    Pro[i] = Apr + Bpr * Apro[i];
                }

                for (int i = POCZ - 10; i <= Kpr; i++)
                {
                    if (Pro[i] >= -0.1d)
                    {
                        POCZ = i;
                        break;
                    }
                }

                // KROTKI_POCZ
                if (j == 0)
                {
                    POCZSR = POCZ;
                    L3 = 1.2d * BA;
                    continue;
                }

                DP = POCZ - POCZSR;

                if (Math.Abs(DP) > 30)
                {
                    continue;
                }

                for (int i = 31; i <= Z1 - 30; i++)
                {
                    C[i] = B[i + DP] - TLO;
                }

                SK++;

                for (int i = 31; i <= Z1 - 30; i++)
                {
                    S[i] = S[i] + C[i];
                }
            }

            string directory = Path.GetDirectoryName(fullPath);
            string name = Path.GetFileNameWithoutExtension(fullPath);
            string newFile = name + ".DAT";
            string newPath = directory + "\\" + newFile;
            string newHeader = header + " " + SK.ToString();

            if (File.Exists(newPath))
            {
                if (IsFileLocked(newPath))
                {
                    newPath = directory + "\\" + name + "1.DAT";
                }
                else
                {
                    File.Delete(newPath);
                }
            }

            using (StreamWriter file = new StreamWriter(newPath))
            {
                file.WriteLine(newHeader);
                StringBuilder sb = new StringBuilder();

                for (int i = 31; i <= Z1 - 30; i++)
                {
                    sb.Append(" ");
                    S[i] = S[i] / SK;
                    sb.Append((Convert.ToSingle(S[i])).ToString(CultureInfo.InvariantCulture));
                }

                file.WriteLine(sb.ToString());
            }

            view.UpdateProgres();

            if (SK > 0)
            {
                seriesList.Add(new ChartModel(name, GetSerie(name, A, S), GetXScale(Z), GetYScale(L3), POCZSR, SK));
            }

        }

        private Series GetSerie(string name, int[] xVal, double[] yVal)
        {
            Series serie = new Series();
            serie.ChartArea = "averageArea";
            serie.ChartType = SeriesChartType.Point;
            serie.IsVisibleInLegend = false;
            serie.MarkerSize = 1;
            serie.Name = name;
            serie.XValueType = ChartValueType.Int32;
            serie.YValueType = ChartValueType.Double;
            serie.MarkerSize = 2;
            serie.MarkerColor = Color.Black;

            for (int i = 0; i < xVal.Length; i++)
            {
                if (yVal[i] != 0)
                {
                    serie.Points.AddXY(xVal[i], yVal[i]);
                }
            }

            return serie;
        }

        private AxisParamStruct GetXScale(double z)
        {
            double nn = z - 1;
            double aa = Math.Log10(nn) / Math.Log10(10);
            double bb = Math.Truncate(aa);
            double cc = Math.Pow(10.0D, (aa - bb));
            double LK = 0.2d;
            int LI = 0;
            if (nn >= 0.1d && nn <= 1000d)
            {
                LI = Convert.ToInt32(Math.Pow(10D, bb));
            }
            else if (nn > 1000d)
            {
                LI = 1;
            }

            if (cc < 2d)
                LK = 0.2d;
            else if (cc >= 2d && cc <= 5d)
                LK = 0.5d;
            else if (cc > 5d)
                LK = 1;

            return new AxisParamStruct(LK * LI, 0, Math.Truncate(cc + LK) * 100d);
        }

        private AxisParamStruct GetYScale(double l3)
        {
            double nn = l3;
            double aa = Math.Log10(nn) / Math.Log10(10);
            double bb = Math.Truncate(aa);
            double cc = Math.Pow(10.0D, (aa - bb));
            double LK = 0.2d;
            int LI = 0;
            if (nn >= 0.1d && nn <= 1000d)
            {
                LI = Convert.ToInt32(Math.Pow(10D, bb));
            }
            else if (nn > 1000d)
            {
                LI = 1;
            }

            if (cc < 2d)
                LK = 0.2d;
            else if (cc >= 2d && cc <= 5d)
                LK = 0.5d;
            else if (cc > 5d)
                LK = 1d;

            return new AxisParamStruct(LK * LI, 0, Math.Truncate(cc + LK) * (LK * LI));
        }
    }
}
