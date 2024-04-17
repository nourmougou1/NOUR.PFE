using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
            return View();
        }
    }
}
