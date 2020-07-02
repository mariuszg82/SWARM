using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageModule.Model
{
    public struct AxisParamStruct
    {
        public double interval, min, max;

        public AxisParamStruct(double interval, double min, double max)
        {
            this.interval = interval;
            this.min = min;
            this.max = max;
        }
    }
}
