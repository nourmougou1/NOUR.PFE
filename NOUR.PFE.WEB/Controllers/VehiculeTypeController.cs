using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOUR.PFE.WEB.Models;

namespace NOUR.PFE.WEB.Controllers
{
    public class VehiculeTypeController : Controller
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
            return View();
        }
    }
}
