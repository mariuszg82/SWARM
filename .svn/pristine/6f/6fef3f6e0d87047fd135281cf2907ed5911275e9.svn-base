using SWARM.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWARM.View
{
    public interface ISwarmModule
    {
        void ShowWindow();
        void SetMdiParent(Form form); 
        void SetFileChooser(IFilesChooser filesChooser);
        String GetExtension { get; }
        String GetDescription { get; }
        bool IsExcluding { get; }
        String GetExcludedFileName { get; }
    }
}
