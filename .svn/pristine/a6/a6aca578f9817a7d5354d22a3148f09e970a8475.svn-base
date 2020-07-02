using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWARM.Controller
{
    public interface IFilesChooser
    {
        List<String> GetFilesList();
        String GetDirectory();
        DialogResult ShowChooserDialog();
        void SetExtension(String extension);
        void CloseDialog();
        void SetExcludedFile(string fileName);
    }
}
