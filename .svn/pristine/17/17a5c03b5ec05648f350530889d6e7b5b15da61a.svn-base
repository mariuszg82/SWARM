using ComputeModule.Model;
using ComputeModule.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeModule.Controller
{
    class ComputeController
    {
        private IComputeView view;
        private BackgroundWorker worker;
        private List<string> files;
        private List<ResultTableStruct> results;

        private readonly string fileHeader = "EP     A    W       K        KP     PD       PC    T    SQR  wys SK lnK  odwT PDcz  PCcz w T0 ";

        private readonly int N = 2;
        private readonly double TW = 400;
        private readonly double M9 = 0.000001;
        private double QI;
        private double[] C;

        private double KII = 0, BAI = 0, Sx = 0, Sy = 0, Sxy = 0, Sx2 = 0, Apr = 0, Bpr = 0;
        private double L1, L3, R1, B1, T0, SS, K, K1, M0, M1, X, Y, RW, RB, RR, XS, SQ, Y1;
        private long WW;
        private int z1 = 0;
        private int AI = 0;
        private int POCZ = 0;
        private int AII, Kpr, Lpr, W, B, TT, V;

        private double[] A1;
        private double[] Apro;
        private double[] D;
        private double[] M;
        private double[] R;
        private double[,] S;
        private double[] T;
        private double[] NAZ;
        private decimal[] A;
        private double[] E;
        private double[] EP1;
        private double[] F;
        private double[] KK;
        private double[] Pro;


        public ComputeController(IComputeView view)
        {
            this.view = view;
        }

        public void SetFiles(List<string> list)
        {
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
            ComputeProcess(files, z, e);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void PrepareXValues(int z)
        {

        }

        private void ComputeProcess(List<string> files, int z, DoWorkEventArgs e)
        {
            int G = 0;
            QI = (Math.Sqrt(N + 2) - 1) / (N + 1) / Math.Sqrt(2);
            results = new List<ResultTableStruct>();
            string currentPath = "";

            #region declared
            //double[] C;

            //double KII = 0, BAI = 0;
            //double L1, L3, R1, B1, T0;
            //long WW;
            //int z1 = 0;
            //int AI = 0;
            //int POCZ = 0;
            //int AII, Kpr, Lpr;
            //double Sx = 0, Sy = 0, Sxy = 0, Sx2 = 0, Apr = 0, Bpr = 0;

            //double[] A1 = new double[z + 1];
            //double[] Apro = new double[z + 1];
            //double[] D = new double[11];
            //double[] M = new double[11];
            //double[] R = new double[11];
            //double[,] S = new double[11, 11];
            //double[] T = new double[11];
            //double[] NAZ = new double[122];
            //decimal[] A = new decimal[z + 1];
            //double[] E = new double[z + 1];
            //double[] EP1 = new double[151];
            //double[] F = new double[z + 1];
            //double[] KK = new double[151];
            //double[] Pro = new double[z + 1];
            #endregion declared

            A1 = new double[z + 1];
            Apro = new double[z + 1];
            D = new double[11];
            M = new double[11];
            R = new double[11];
            S = new double[11, 11];
            T = new double[11];
            NAZ = new double[122];
            A = new decimal[z + 1];
            E = new double[z + 1];
            EP1 = new double[151];
            F = new double[z + 1];
            KK = new double[151];
            Pro = new double[z + 1];

            foreach (string filePath in files)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                if (currentPath == "")
                {
                    currentPath = Path.GetDirectoryName(filePath);
                }

                G++;
                V = 0;

                HeaderModel headerModel;

                IEnumerable<string> lines = File.ReadLines(filePath);
                string[] fileLines = lines.ToArray<string>();

                headerModel = GetHeader(fileLines[0]);
                C = GetValues(fileLines[1], z);

                double EP = headerModel.EPS;
                double DN = 1.5 / EP;
                EP1[G] = EP;
                double PC = headerModel.PCS;
                double PD = headerModel.PDS;
                decimal INCR = Convert.ToDecimal(headerModel.INCRS) * 1000000.0m;
                double SK = headerModel.SK;
                double TEMPS = headerModel.TEMPS;

                for (int i = 1; i <= z; i++)
                {
                    A[i] = i * INCR;
                }

                BAI = 0;
                z1 = fileLines.Length;
                for (int i = z - 30; i >= 31; i--)
                {
                    if (i > 20 & i < z - 30 & C[i] > BAI)
                    {
                        BAI = C[i];
                        AI = i;
                    }
                }
                for (int i = AI; i >= 31; i--)
                {
                    if (C[i] < 1)
                    {
                        POCZ = i - 1;
                        break;
                    }
                }
                if (POCZ < 1)
                {
                    POCZ = 1;
                }
                for (int i = AI; i >= 1; i--)
                {
                    if (C[i] < 0.99 * BAI)
                    {
                        AI = i;
                        BAI = C[i];
                        KII = 0.94;
                        break;
                    }
                }
                for (int i = AI; i >= 1; i--)
                {
                    if (C[i] < KII * BAI)
                    {
                        AII = i;
                        break;
                    }
                }
                L1 = (double)A[z];
                L3 = 1.1 * BAI;
                if (BAI == 0)
                {
                    continue;
                }
                R1 = 500 / L1;

                for (int i = 31; i <= z - 30; i++)
                {
                    A1[i] = Convert.ToInt32(50 + R1 * (double)A[i]);
                    B1 = 360 - 320 / (double)L3 * C[i];
                }

                Kpr = POCZ + 15;
                Lpr = 15;
                for (int i = POCZ - 10; i <= Kpr + 10; i++)
                    Apro[i] = i + 1 - POCZ;
                Sx = 0;
                Sy = 0;
                Sxy = 0;
                Sx2 = 0;
                for (int i = POCZ + 1; i <= Kpr; i++)
                {
                    Sx = Sx + Apro[i];
                    Sy = Sy + C[i];
                    Sxy = Sxy + Apro[i] * C[i];
                    Sx2 = Sx2 + Math.Pow(Apro[i], 2);
                }
                Bpr = (Sx * Sy - Lpr * Sxy) / (Math.Pow(Sx, 2) - Lpr * Sx2);
                Apr = 1 / (double)Lpr * (Sy - Bpr * Sx);
                for (int i = POCZ - 5; i <= Kpr + 5; i++)
                {
                    Pro[i] = Apr + Bpr * Apro[i];
                }
                for (int i = POCZ - 5; i <= Kpr; i++)
                {
                    if (Pro[i] >= -0.1)
                    {
                        POCZ = i;
                        break;
                    }
                }

                T0 = (double)(A[AI] - A[POCZ]);
                WW = (long)Math.Round(DN / T0 * 1000000.0d);

                K1 = (double)(3 * (decimal)BAI);
                K = 0.2;
                if (PD == 1)
                {
                    K = 0.02;
                }
                S[1, 2] = K1;
                S[1, 3] = K;
                T[2] = S[1, 2] / 120;
                T[3] = S[1, 3] / 120;
                for (int i = 2; i <= N + 1; i++)
                {
                    for (int j = 2; j <= N + 1; j++)
                    {
                        S[i, j] = S[1, j] + QI * T[j];
                    }
                    S[i, i] = S[i, i] + 0.707 * T[i];
                }
                for (int i = 1; i <= N + 1; i++)
                {
                    for (int j = 2; j <= N + 1; j++)
                    {
                        D[j] = S[i, j];
                    }

                    T15();
                    S[i, 1] = SS;
                }

                // BW

                B = 1;
                W = 1;
                RB = S[B, B];
                RW = RB;
                for (int i = 2; i <= N + 1; i++)
                {
                    if (RB > S[i, 1])
                    {
                        RB = S[i, 1];
                        B = i;
                    }
                    if (RW < S[i, 1])
                    {
                        RW = S[i, 1];
                        W = i;
                    }
                }
                RR = (RW - RB) / RB;
                if (RR < M9 || V == 200)
                {
                    //XS = 0;
                    //for (int i = POCZ; i <= AII; i++)
                    //{
                    //    Y = (F[i] - C[i]) / BAI;
                    //    XS = XS + Math.Pow(Y, 2);
                    //}
                    //SQ = Math.Sqrt(XS) / (AII - POCZ);
                    //KK[G] = K;
                    //for (int j = POCZ; j <= z; j++)
                    //{
                    //    X = (double)(A[j] - A[POCZ]);
                    //    M1 = K1 * TW / T0 / (1 - K * TW);
                    //    F[j] = M1 * (Math.Exp(-K * X) - Math.Exp(-X / TW));
                    //}
                    //for (int i = POCZ; i <= AI; i += 3)
                    //{
                    //    Y1 = 360 - 320 / L3 * F[i];

                    //}
                    //for (int j = z1; j >= AI; j += -1)
                    //{
                    //    X = (double)(A[j] - A[z1]);
                    //    F[j] = C[z1] * Math.Exp(-X / TW);
                    //}
                    //for (int i = AI; i <= z1; i += 4)
                    //{
                    //    Y1 = 360 - 320 / L3 * F[i];

                    //}
                    //for (int i = POCZ - 5; i <= Kpr; i++)
                    //{
                    //    B1 = 360 - 320 / L3 * Pro[i];

                    //}
                    continue;
                }
                for (int i = 2; i <= N + 1; i++)
                {
                    M0 = 0;
                    for (int j = 1; j <= N + 1; j++)
                    {
                        if (j != W)
                            M0 = M0 + S[j, i];
                    }
                    M[i] = M0 / N;
                }
                for (int i = 2; i <= N + 1; i++)
                {
                    D[i] = 2 * M[i] - S[W, i];
                    R[i] = D[i];
                };
                T15();
                R[1] = D[1];
                TT = 3;
                if (SS <= RW)
                {
                    TT = 2;
                }
                if (SS <= RB)
                {
                    TT = 1;
                }
                switch (TT)
                {
                    case 1:
                        {
                            T20();
                            break;
                        }
                    case 2:
                        {
                            T21();
                            break;
                        }
                    case 3:
                        {
                            T22();
                            break;
                        }
                }

                V = V + 1;

                results.Add(PrepareResult(EP, K1, WW, K, PD, PC, TEMPS, SQ, SK, PC, T0));
                view.UpdateProgres();
            }
            if (results.Count > 0)
            {
                SaveFile(results, fileHeader, currentPath);
                view.UpdateGui(results);
            }
        }

        private void T15()
        {
            SS = 0;
            K1 = D[2];
            K = D[3];
            for (int j = POCZ; j <= AII; j++)
            {
                X = (double)(A[j] - A[POCZ]);
                M1 = K1 * TW / T0 / (1 - K * TW);
                F[j] = M1 * (Math.Exp(-K * X) - Math.Exp(-X / TW));
                Y = F[j] - C[j];
                SS = SS + Math.Pow(Y, 2);
            }
            D[1] = SS;
        }

        private void T20()
        {
            for (int i = 1; i <= N + 1; i++)
            {
                D[i] = 2 * R[i] - M[i];
            }
            T15();
            if (SS > RB)
            {
                T21();
            }
            else
            {
                T23();
            }
        }

        private void T21()
        {
            for (int i = 1; i <= N + 1; i++)
            {
                S[W, i] = R[i];
            }
        }

        private void T22()
        {
            for (int i = 2; i <= N + 1; i++)
            {
                D[i] = (S[W, i] + M[i]) / 2d;
            }
            T15();
            if (SS > RW)
            {
                T24();
            }
            else
            {
                T23();
            }
        }

        private void T23()
        {
            for (int i = 1; i <= N + 1; i++)
            {
                S[W, i] = D[i];
            }
        }

        private void T24()
        {
            for (int i = 1; i <= N + 1; i++)
            {
                if (i == B)
                    i = i + 1;
                for (int j = 2; j <= N + 1; j++)
                {
                    D[j] = (S[i, j] + S[B, j]) / 2d;
                    S[i, j] = D[j];
                };
                T15();
                S[i, 1] = SS;
            }
        }

        private HeaderModel GetHeader(string line)
        {
            HeaderModel model = new HeaderModel();
            char[] delimiters = new char[] { ' ', '\t' };

            string[] columnValues = (line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));
            model.Name = columnValues[0];
            model.PCS = double.Parse(columnValues[1], NumberStyles.Float, CultureInfo.InvariantCulture);
            model.PDS = double.Parse(columnValues[2], NumberStyles.Float, CultureInfo.InvariantCulture);
            model.EPS = double.Parse(columnValues[3], NumberStyles.Float, CultureInfo.InvariantCulture);
            model.INCRS = double.Parse(columnValues[4], NumberStyles.Float, CultureInfo.InvariantCulture);
            model.OPOZNS = double.Parse(columnValues[5], NumberStyles.Float, CultureInfo.InvariantCulture);
            model.TEMPS = double.Parse(columnValues[6], NumberStyles.Float, CultureInfo.InvariantCulture);
            model.wys = double.Parse(columnValues[7], NumberStyles.Float, CultureInfo.InvariantCulture);
            model.SK = double.Parse(columnValues[8], NumberStyles.Float, CultureInfo.InvariantCulture);

            return model;
        }

        private double[] GetValues(string line, int z)
        {
            double[] tmp = new double[z + 1];
            char[] delimiters = new char[] { ' ', '\t' };

            string[] columnValues = (line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));

            for (int i = 1; i <= columnValues.Length; i++)
            {
                tmp[i] = Double.Parse(columnValues[i - 1], NumberStyles.Float, CultureInfo.InvariantCulture);
            }

            return tmp;
        }

        private ResultTableStruct PrepareResult(double EP, double K1, double WW, double K, double PD, double PCS, double TEMPS, double SQ, double SKS, double PC, double T0)
        {
            ResultTableStruct result = new ResultTableStruct();

            result.EP = EP;
            result.A = K1;
            result.W = WW;
            result.K = K;
            result.KP = (K / (PD * 32400000000));
            result.PD = PD;
            result.PC = PCS;
            result.T = TEMPS;
            result.SQR = SQ;
            result.SK = SKS;
            result.lnK = Math.Log(Math.Abs(K / (PD * 32400000000.0)));
            result.odwT = 1 / ((TEMPS + 273.15) * 0.025 / 298);
            result.PDcz = (PD * 3.24E+16);
            result.PCcz = (PC * 3.24E+16);
            result.w = (EP * WW);
            result.T0 = T0;

            return result;
        }

        private void SaveFile(List<ResultTableStruct> list, string header, string fullPath)
        {
            //string directory = Path.GetDirectoryName(fullPath);
            string directory = fullPath;
            string name = "STALE";
            string newFile = name + ".DAT";
            string newPath = directory + "\\" + newFile;

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
                file.WriteLine(header);
                StringBuilder sb = new StringBuilder();

                foreach (ResultTableStruct res in list)
                {
                    sb.Append(res.EP.ToString("N2", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.A.ToString("N0", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.W.ToString("E2", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.K.ToString("N5", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.KP.ToString("E2", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.PD.ToString("N8", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.PC.ToString("N0", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.T.ToString("N0", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.SQR.ToString("E2", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.SK.ToString("N0", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.lnK.ToString("N8", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.odwT.ToString("N6", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.PDcz.ToString("E2", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.PCcz.ToString("E2", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.w.ToString("E2", CultureInfo.CurrentCulture));
                    sb.Append("  ");
                    sb.Append(res.T0.ToString("E2", CultureInfo.CurrentCulture));
                    sb.Append("  ");

                    file.WriteLine(sb.ToString());
                    sb.Clear();
                }

            }
        }
    }
}
