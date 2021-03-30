using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplication.API.APIModels
{
    public class WaitingList
    {
        public int PatientCount { get; set; }
        public int LevelOfPain { get; set; }
        public double AverageProcessTime { get; set; }

    }
}
