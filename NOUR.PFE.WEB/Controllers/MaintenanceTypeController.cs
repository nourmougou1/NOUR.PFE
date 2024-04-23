using Microsoft.AspNetCore.Mvc;
using NOUR.PFE.Entities;
using NOUR.PFE.WEB.Models;
using System;

namespace NOUR.PFE.WEB.Controllers
{
    public class MaintenanceTypeController : Controller
    {
        public IActionResult Index()
        {
            MaintenanceTypeViewModel _Model = new MaintenanceTypeViewModel();
            _Model.MaintenanceTypes = Repository.Maintenance.GetAllMaintenanceTypes();
            return View("Index", _Model);
        }

        public IActionResult Details(int id)
        {
            NOUR.PFE.WEB.Models.MaintenanceTypeViewModel _Model = new NOUR.PFE.WEB.Models.MaintenanceTypeViewModel();
            _Model.MaintenanceType = Repository.Maintenance.GetMaintenanceTypeById(id);
            return View(_Model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Models.MaintenanceTypeViewModel _Model = new Models.MaintenanceTypeViewModel
            {
                MaintenanceTypes = Repository.Maintenance.GetAllMaintenanceTypes()
            };

            return View(_Model);
        }


        [HttpPost]
        public IActionResult Create(Models.MaintenanceTypeViewModel _Model)
        {
            if (ModelState.IsValid)
            {
                Entities.MaintenanceTypes _UserRoles = Repository.Maintenance.GetAllMaintenanceTypes();

                var maintenanceType = new Entities.MaintenanceType
                {
                    Name = _Model.maintenanceTypeName,
                    Description = _Model.description

                };

                if (Repository.Maintenance.AddMaintenanceType(maintenanceType))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            _Model.MaintenanceTypes = Repository.Maintenance.GetAllMaintenanceTypes();
            return View(_Model);

        }

        public IActionResult Edit(int id)
        {
            var maintenanceType = Repository.Maintenance.GetMaintenanceTypeById(id);
            try
            {
                Models.MaintenanceTypeViewModel _Model = new Models.MaintenanceTypeViewModel 
                {
                    maintenanceTypeName = maintenanceType.Name,
                    description = maintenanceType.Description,
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("MaintenanceType.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.MaintenanceTypeViewModel _Model)
        {
            {
                if (ModelState.IsValid)
                {
                    var MaintenanceType = new MaintenanceType
                    {

                        Name = _Model.maintenanceTypeName,
                        Description = _Model.description

                    };
                    Repository.Maintenance.UpdateMaintenanceType(MaintenanceType);
                    return RedirectToAction(nameof(Index));
                }

            }
            ModelState.AddModelError("", "Error");
            return View(_Model);
        }

        public ActionResult Delete(int id)
        {
            var maintenanceType = Repository.Maintenance.GetMaintenanceTypeById(id);
            return View(maintenanceType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Entities.MaintenanceType maintenanceType)
        {
            try
            {
                Repository.Maintenance.RemoveMaintenanceType(maintenanceType);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }
    }
}
