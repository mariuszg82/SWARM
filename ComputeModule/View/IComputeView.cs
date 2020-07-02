using ComputeModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeModule.View
{
    public interface IComputeView
    {
        void UpdateGui(List<ResultTableStruct> seriesList);
        void UpdateProgres();
    }
}
