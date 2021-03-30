using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplication.API.APIModels
{
    public class IllnessMain
    {
        [JsonProperty("_embedded")]
        public IllnessWrapperCollection Embedded { get; set; }
    } 
}
