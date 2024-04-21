using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOUR.PFE.Entities;
using NOUR.PFE.Repository;
using NOUR.PFE.WEB.Models;

namespace NOUR.PFE.WEB.Controllers
{
    public class MaintenanceController : Controller
    {
        private IConfiguration _Config;
        public MaintenanceController(IConfiguration iConfig)
        {
            _Config = iConfig;
        }

        [HttpGet]
        public IActionResult Index()
        {
            MaintenanceViewModel _Model = new MaintenanceViewModel();
            _Model.Maintenances = Repository.Maintenance.GetAll();
            return View("Index", _Model);
        }

        public IActionResult Create()
        {
            MaintenanceViewModel Model = new MaintenanceViewModel();
            Model.MaintenanceTypes = Repository.Maintenance.GetAllMaintenanceTypes();
            Model.Vehicules = Repository.Vehicule.GetAll();
            return View(Model);
        }

        [HttpPost]
        public IActionResult Create(Models.MaintenanceViewModel _Model)
        {
            if (ModelState.IsValid)
            {
                Entities.Maintenances _maintenance = Repository.Maintenance.GetAll();

               
                var maintenance = new Entities.Maintenance
                {
                    Vehicule = _Model.Vehicule,
                    MaintenanceType = _Model.MaintenanceType,
                    DateDebut = _Model.DateDebut,
                    Address = _Model.Address,
                    description = _Model.description


                };

                if (Repository.Maintenance.Add(maintenance))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            _Model.Maintenances = Repository.Maintenance.GetAll();
            return View(_Model);
        }
    }
}
