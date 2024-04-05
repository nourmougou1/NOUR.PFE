using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOUR.PFE.WEB.Models;

namespace NOUR.PFE.WEB.Controllers
{
    public class VehiculeController : Controller
    {
        private IConfiguration _Config;
        public VehiculeController(IConfiguration iConfig)
        {
            _Config = iConfig;
        }

        [HttpGet]
        public IActionResult Index()
        {
            VehiculeViewModel _Model = new VehiculeViewModel();
            _Model.Vehicules = Repository.Vehicule.GetAll();
            return View("Index", _Model);
        }
    }
}
