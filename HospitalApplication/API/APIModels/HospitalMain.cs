using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplication.API.APIModels
{
    public class HospitalMain
    {
        [JsonProperty("_embedded")]
        public HospitalCollection Embedded { get; set; }
    }
}
