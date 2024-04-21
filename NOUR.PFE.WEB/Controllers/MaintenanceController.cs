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

        //public IActionResult Create()
        //{
        //MaintenanceViewModel Model = new MaintenanceViewModel();
        //Model.MaintenanceTypes = Repository.Maintenance.GetAll();
        //Model.Vehicule = Repository.Vehicule.GetAll();
        //return View(Model);
        //}
    }
}
