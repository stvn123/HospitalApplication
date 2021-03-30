using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplication.API.APIModels
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WaitingList[] WaitingList { get; set; }
    }
}
 