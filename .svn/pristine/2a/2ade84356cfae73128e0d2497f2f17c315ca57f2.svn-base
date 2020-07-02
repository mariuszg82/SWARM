using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SWARM
{
    public static class GlobalConfig
    {
        private static readonly String CONFIG_FILE_NAME = Application.StartupPath + "\\config.xml";
        private static XmlDocument configuration = new XmlDocument();
        private static readonly XmlNodeList xmlnodelist = configuration.SelectNodes("/configuration");

        public static bool LoadConfig()
        {
            bool result = true;
            configuration.Load(CONFIG_FILE_NAME);
            try
            {
                foreach (XmlNode node in xmlnodelist)
                {
                    Environment.SetEnvironmentVariable("z", node["z"].InnerText.ToString());
                    Environment.CurrentDirectory = node["work-dir"].InnerText.ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException || ex is NullReferenceException)
                {
                    MessageBox.Show("Nastąpił wyjątek:\n" + ex.ToString(), "Błąd");
                    result = false;
                }
            }
            if (result)
                return true;
            else
                return false;
        }

        public static bool SaveConfig()
        {
            bool result = true;
            try
            {
                foreach (XmlNode node in xmlnodelist)
                {
                    node["z"].InnerText = Environment.GetEnvironmentVariable("z");
                    node["work-dir"].InnerText = Environment.CurrentDirectory;
                }
                configuration.Save(CONFIG_FILE_NAME);
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException || ex is NullReferenceException)
                {
                    MessageBox.Show("Nastąpił wyjątek:\n" + ex.ToString(), "Błąd");
                    result = false;
                }
            }
            if (result)
                return true;
            else
                return false;
        }
    }
}

