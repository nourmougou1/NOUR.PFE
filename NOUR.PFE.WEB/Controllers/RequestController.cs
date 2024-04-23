using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOUR.PFE.Entities;
using NOUR.PFE.WEB.Models;
using System.Linq;

namespace NOUR.PFE.WEB.Controllers
{
    public class RequestController : Controller
    {
        private IConfiguration _Config;
        public RequestController(IConfiguration iConfig)
        {
            _Config = iConfig;
        }
        [HttpGet]
        public IActionResult Index()
        {
            RequestViewModel _Model = new RequestViewModel();
            _Model.Requests = Repository.Request.GetAll();
            return View("Index", _Model);
        }

        public ActionResult Create()
        {
            Models.RequestViewModel _Model = new Models.RequestViewModel
            {
                VehiculeTypes = Repository.Vehicule.GetAllTypes()
            };

            return View(_Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.RequestViewModel _Model)
        {

            if (ModelState.IsValid)
            {
                Entities.Requests _UserRoles = Repository.Request.GetAll();

                //if (_UserRoles.FirstOrDefault(ur => ur.Code.Trim().Equals(_Model.UserRole.Code.Trim())) != null)
                //{
                //    ModelState.AddModelError("Code", "Code invalide!");
                //    _Model.UserRoles = Repository.Config.GetUserRoles();

                //    return View(_Model);
                //}
                var request = new Entities.Request
                {
                    VehiculeType = new VehiculeType() { Id = _Model.VehiculeTypeId } ,
                    MissionAddress = _Model.MissionAddress,
                   MissionDate = _Model.MissionDate,
                   Description = _Model.Description,
                 


                };

                if (Repository.Request.Add(request))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            _Model.Requests = Repository.Request.GetAll();
            return View(_Model);
        }

    }

}
