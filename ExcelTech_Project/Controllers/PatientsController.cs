using ExcelTech_Project.Models;
using ExcelTech_Project.Repostoris;
using ExcelTech_Project.ViewModels.Input;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ExcelTech_Project.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientsRepo repo;
        public PatientsController(IPatientsRepo repo)
        {
            this.repo= repo;
        }
        public async Task<IActionResult> Index([FromQuery] string msg="")
        {
            ViewBag.Allergies = await this.repo.GetAllegiesAsync();
            ViewBag.DiseaseInformations = await this.repo.GetDiseaseInformationsAsync();
            ViewBag.NCDs = await this.repo.GetNCDsAsync();
            ViewBag.Msg = msg;
            return View();
        }
        public async Task<ActionResult> Save(PatientInputModel model)
        {
            if(ModelState.IsValid)
            {
                var patient = new Patient { PatientName=model.PatientName, Epilepsy=model.Epilepsy };
                var saved =await this.repo.InsertPatientAsync(patient);
                List<Allergy_Detail> allergies= new List<Allergy_Detail>();
                foreach(var i in model.AllergyIds)
                {
                   allergies.Add( new Allergy_Detail { AllergyId = i, PatientId = saved.PatientId });
                }
                List<NCD_Detail> ncds = new List<NCD_Detail>();
                foreach (var i in model.AllergyIds)
                {
                    ncds.Add(new NCD_Detail { NCDId = i, PatientId=saved.PatientId});
                }
                await repo.InsertAllergyDetailsAsync(allergies);
                await repo.InsertNCDDetailsAsync(ncds);
                return RedirectToAction("Index", routeValues: new {msg="done"});
            }
            return View(model);
        }
    }
}
