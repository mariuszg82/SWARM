using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using SWARM.Controller;

namespace SWARM
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Start();
        }

        static void Start()
        {
            MainFormController controller = new MainFormController();
            if (GlobalConfig.LoadConfig())
            {
                controller.ShowWindow();
            }
            else
            {
                Application.ExitThread();
            }
        }
    }
}
