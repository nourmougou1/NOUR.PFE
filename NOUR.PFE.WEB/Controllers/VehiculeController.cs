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

namespace NOUR.PFE.WEB.Controller
{
    public class VehiculeController : Microsoft.AspNetCore.Mvc.Controller
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
                    Repository.Vehicule.Add(_Model.Vehicule);
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
                    Vehicule = vehicule,
                    VehiculeBrands = Repository.Vehicule.GetAllBrands(),
                    VehiculeTypes = Repository.Vehicule.GetAllTypes(),
                    Statuss = Repository.Vehicule.GetAllStatus(),

                    Vehicules = Repository.Vehicule.GetAll(),

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
                    Repository.Vehicule.Update(_Model.Vehicule);
                    return RedirectToAction(nameof(Index));
                }
            }
            ModelState.AddModelError("", "Error");
            return View(_Model);
        }

    } 
}
