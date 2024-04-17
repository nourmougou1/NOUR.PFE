using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NOUR.PFE.WEB.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NOUR.PFE.WEB.Controllers
{
    public class VehiculeController : Controller
    {
        private IConfiguration _Config;
        private readonly IWebHostEnvironment hostEnvironment;
        public VehiculeController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            VehiculeViewModel _Model = new VehiculeViewModel();
            _Model.Vehicules = Repository.Vehicule.GetAll();
            return View("Index", _Model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            VehiculeViewModel Model = new VehiculeViewModel();
            Model.VehiculeBrands = Repository.Vehicule.GetAllBrands();
            Model.VehiculeTypes = Repository.Vehicule.GetAllTypes();
            Model.Statuss = Repository.Vehicule.GetAllStatus();
            return View(Model);
        }
        [HttpPost]
        public IActionResult Create(Models.VehiculeViewModel _Model)
        {

            if (ModelState.IsValid)
                try
                {
                    Entities.User _User = JsonConvert.DeserializeObject<Entities.User>(HttpContext.Session.GetString("User"));

                    //var vehicule = new Vehicule
                    //{
                    //    Matricule = _Model.Imm

                    //};
                    //Repository.Vehicule.Add(vehicule);
                    //return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }

            ModelState.AddModelError("", "Error");
            return View();
        }



    } 
}
