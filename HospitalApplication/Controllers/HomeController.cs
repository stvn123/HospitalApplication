using HospitalApplication.API;
using HospitalApplication.Constant;
using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalContext _context;  
        public HomeController(HospitalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var illnesses = ApiHelper.GetIllnesses().Result;
            return View(illnesses.Embedded.Illnesses);
        }

        [HttpPost]
        public JsonResult GetHospitals(Diagnosis diagnosis)
        {
            _context.Diagnoses.Add(diagnosis);
            _context.SaveChanges();
            return Json(new { redirectToUrl = Url.Action("SuggestedHospitals", diagnosis)});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SuggestedHospitals(Diagnosis diagnosis)
        {
            var levelOfPain = diagnosis.LevelOfPain;
            var hospitals = ApiHelper.GetHospitals().Result;

            List<HospitalProcessTimeViewModel> suggestedHospitals = hospitals.Embedded.Hospitals.Select(x => new HospitalProcessTimeViewModel() {
                HospitalName = x.Name,
                AverageProcessTime = x.WaitingList.FirstOrDefault(w => w.LevelOfPain == levelOfPain).AverageProcessTime,
                TotalProcessTime = x.WaitingList.FirstOrDefault(w => w.LevelOfPain == levelOfPain).AverageProcessTime * x.WaitingList.FirstOrDefault(w => w.LevelOfPain == levelOfPain).PatientCount
            }).OrderBy(x => x.TotalProcessTime).ToList();

            Parallel.For(0, suggestedHospitals.Count(), (i, state) =>
            {
                double TotalProcessTime = suggestedHospitals.ElementAt(i).TotalProcessTime;
                if (TotalProcessTime >= 60)
                {
                    suggestedHospitals.ElementAt(i).TotalProcessTime = Math.Round(TotalProcessTime / 60, 1);
                    suggestedHospitals.ElementAt(i).Unit = Measurement.HOUR;
                }
            });
                
            return View(suggestedHospitals);
        }
    }
}
