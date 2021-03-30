using HospitalApplication.API.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HospitalApplication.API
{
    public static class ApiHelper
    {
        private const string ILLNESSES = @"http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses";
        private const string HOSPITALS = @"http://dmmw-api.australiaeast.cloudapp.azure.com:8080/hospitals";

        public static async Task<IllnessMain> GetIllnesses()
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(ILLNESSES);
            if (response.IsSuccessStatusCode)
            {
                var strResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IllnessMain>(strResult);
            }
            else
                return null;
        }

        public static async Task<HospitalMain> GetHospitals()
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(HOSPITALS);
            if (response.IsSuccessStatusCode)
            {
                var strResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<HospitalMain>(strResult);
            }
            else
                return null;
        }
    }
}
