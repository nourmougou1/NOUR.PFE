using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NOUR.PFE.WEB.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NOUR.PFE.Entities;
using NOUR.PFE.Repository;

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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.VehiculeViewModel _Model)
        {

            if (ModelState.IsValid)
                try
                {
                    Entities.User _User = JsonConvert.DeserializeObject<Entities.User>(HttpContext.Session.GetString("User"));

                    var vehicule = new Entities.Vehicule
                    {
                        Imm = _Model.RegNumber,
                        VehiculeType = new VehiculeType() { Id = _Model.Id },
                        VehiculeBrand = new VehiculeBrand() { Id = _Model.Id },
                        Status = new VehiculeStatus() { Status_id = _Model.Id },
                        Kilometrage = _Model.Kilometrage,
                        document = _Model.document,
                        parc = _Model.parc,
                        PurshaseDate = _Model.PurshaseDate,
                    };
                    Repository.Vehicule.Add(vehicule);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }

            ModelState.AddModelError("", "Error");
            return View();
        }

        public IActionResult Details(int id)
        {
            NOUR.PFE.WEB.Models.VehiculeViewModel _Model = new NOUR.PFE.WEB.Models.VehiculeViewModel();
            _Model.Vehicule = Repository.Vehicule.GetOne(id);
            return View(_Model);
        }
        public IActionResult Delete(int vehiculeId)
        {
            var vehicule = Repository.Vehicule.GetOne(vehiculeId);
            return View(vehicule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Entities.Vehicule vehicule)
        {

            try
            {

                Repository.Vehicule.Remove(vehicule);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var vehicule = Repository.Vehicule.GetOne(id);
            try
            {
                Models.VehiculeViewModel _Model = new Models.VehiculeViewModel
                {
                    RegNumber = vehicule.Imm,
                    vehiculeType = vehicule.VehiculeType,
                    VehiculeBrand = vehicule.VehiculeBrand,
                    Status = vehicule.Status,
                    PurshaseDate =vehicule.PurshaseDate,
                    parc = vehicule.parc,
                    Kilometrage = vehicule.Kilometrage                
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("Vehicule.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.VehiculeViewModel _Model)
        {
            {
                if (ModelState.IsValid)
                {
                    var vehicule = new Entities.Vehicule
                    {

                        Imm = _Model.RegNumber,
                        VehiculeType = _Model.vehiculeType,
                        VehiculeBrand = _Model.VehiculeBrand,
                        Status = _Model.Status,
                        PurshaseDate = _Model.PurshaseDate,
                        parc = _Model.parc,
                        Kilometrage = _Model.Kilometrage
                    };
                    Repository.Vehicule.Update(vehicule);
                    return RedirectToAction(nameof(Index));
                }

            }
            ModelState.AddModelError("", "Error");
            return View(_Model);
        }

    } 
}
