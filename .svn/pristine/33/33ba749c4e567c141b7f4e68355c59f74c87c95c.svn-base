using SWARM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWARM.Controller
{
    public class FilesChooserController
    {
        FilesChooserModel model = new FilesChooserModel();
        public String FileExtension { get; set; }
        private string excludeFileName;

        public FilesChooserController()
        {
        }

        public FilesChooserController(string excludeFileName)
        {
            this.excludeFileName = excludeFileName;
        }

        public List<String> GetAllFiles(String ext)
        {
            if (excludeFileName == "" || excludeFileName == null)
            {
               model.AllFiles = Directory.GetFiles(Environment.CurrentDirectory, String.Concat("*.", ext)).OfType<String>().ToList();
            }
            else
            {
               model.AllFiles = Directory.GetFiles(Environment.CurrentDirectory, String.Concat("*.", ext)).Where(name => !name.Contains(excludeFileName)).OfType<String>().ToList();
            }
            return model.AllFiles;
        }

        public void SetSelectedFiles(List<String> list)
        {
            List<String> tmp = new List<String>();
            foreach(String item in list)
            {
                foreach (String path in model.AllFiles)
                {
                    if (Path.GetFileName(path).Equals(item))
                    {
                        tmp.Add(path);
                    }
                }
            }
            model.SelectedFiles = tmp;
        }

        public List<String> GetSelectedFiles()
        {
            return model.SelectedFiles;
        }

        public void ExcludeFile(string fileName)
        {
            excludeFileName = fileName;
        }
    }
}
