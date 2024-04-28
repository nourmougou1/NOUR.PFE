using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOUR.PFE.WEB.Models;
using System.Linq;
using System;
using NOUR.PFE.Entities;

namespace NOUR.PFE.WEB.Controller
{
    public class VehiculeTypeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IConfiguration _Config;
        public VehiculeTypeController(IConfiguration iConfig)
        {
            _Config = iConfig;
        }

        [HttpGet]
        public IActionResult Index()
        {
            VehiculeTypeViewModel _Model = new VehiculeTypeViewModel();
            _Model.VehiculeTypes = Repository.Vehicule.GetAllTypes();
            return View("Index", _Model);
        }
        public IActionResult Create()
        {
            Models.VehiculeTypeViewModel _Model = new Models.VehiculeTypeViewModel
            {
                VehiculeTypes = Repository.Vehicule.GetAllTypes()
            };

            return View(_Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.VehiculeTypeViewModel _Model)
        {
            if (ModelState.IsValid)
            {
                Entities.VehiculeTypes _vehiculeType = Repository.Vehicule.GetAllTypes();

                if (_vehiculeType.FirstOrDefault(vt => vt.TypeName.Trim().Equals(_Model.TypeName.Trim())) != null)
                {
                    ModelState.AddModelError("Name", "Name invalide!");
                    _Model.VehiculeTypes = Repository.Vehicule.GetAllTypes();

                    return View(_Model);
                }

                var VehiculeType = new Entities.VehiculeType
                {
                    TypeName = _Model.TypeName,
                };


                if (Repository.Vehicule.AddType(VehiculeType))
                {
                   
                    TempData["SuccessMessage"] = "User created successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            _Model.VehiculeTypes = Repository.Vehicule.GetAllTypes();
            return View(_Model);
        }

        public IActionResult Details(int id)
        {
            NOUR.PFE.WEB.Models.VehiculeTypeViewModel _Model = new NOUR.PFE.WEB.Models.VehiculeTypeViewModel();
            _Model.VehiculeType = Repository.Vehicule.GetTypeById(id);
            return View(_Model);
        }

        public IActionResult Delete(int typeId)
        {
            var vehiculeType = Repository.Vehicule.GetTypeById(typeId);
            return View(vehiculeType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Entities.VehiculeType vehiculeType)
        {

            try
            {

                Repository.Vehicule.DeleteType(vehiculeType);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var vehiculeType = Repository.Vehicule.GetTypeById(id);
            try
            {
                Models.VehiculeTypeViewModel _Model = new Models.VehiculeTypeViewModel
                {
                    TypeName = vehiculeType.TypeName
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("VehiculeType.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.VehiculeTypeViewModel _Model)
        {
            {
                if (ModelState.IsValid)
                {
                    var Type = new VehiculeType
                    {

                        TypeName = _Model.TypeName

                    };
                    Repository.Vehicule.UpdateType(Type);
                    return RedirectToAction(nameof(Index));
                }

            }
            ModelState.AddModelError("", "Error");
            return View(_Model);
        }

    }
}
