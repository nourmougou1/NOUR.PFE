using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOUR.PFE.WEB.Models;

namespace NOUR.PFE.WEB.Controllers
{
    public class VehiculeBrandController : Controller
    {
        private IConfiguration _Config;
        public VehiculeBrandController(IConfiguration iConfig)
        {
            _Config = iConfig;
        }

        [HttpGet]
        public IActionResult Index()
        {
            BrandViewModel _Model = new BrandViewModel();
            _Model.VehiculeBrands = Repository.Vehicule.GetAllBrands();
            return View("Index", _Model);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
