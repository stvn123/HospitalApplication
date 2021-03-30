using HospitalApplication.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplication.ViewModel
{
    public class HospitalProcessTimeViewModel
    {
        public string HospitalName { get; set; }
        public double AverageProcessTime { get; set; }
        public double TotalProcessTime { get; set; }
        public string Unit { get; set; } = Measurement.MINUTE;
    }
}
