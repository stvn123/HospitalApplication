using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplication.Models
{
    public class Diagnosis
    {
        public int DiagnosisId { get; set; }

        [MaxLength(50)]
        public string PatientName { get; set; }

        [MaxLength(80)]
        public string IllnessName { get; set; }

        public int IllnessId { get; set; }

        public byte LevelOfPain { get; set; }

    }
}
