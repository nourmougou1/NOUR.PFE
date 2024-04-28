using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NOUR.PFE.Entities;
using NOUR.PFE.WEB.Models;
using System;
using System.IO;
using System.Linq;

namespace NOUR.PFE.WEB.Controllers
{
    public class RequestController : Microsoft.AspNetCore.Mvc.Controller
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

        public IActionResult Affect(int id)
        {
            Request request = Repository.Request.GetOneById(id);
            if (request != null)
            {
                request.status.Id = 1;
            }
            return RedirectToAction("Index", "Request");

        }
        public IActionResult Refuse (int id)
        {
            Request request = Repository.Request.GetOneById(id);
            if (request != null)
            {
                request.status.Id = 3;
            }
            return RedirectToAction("Index", "Request");
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
                Entities.User _User = JsonConvert.DeserializeObject<Entities.User>(HttpContext.Session.GetString("User"));

                var request = new Entities.Request
                {
                    User = _User,
                    VehiculeType = new VehiculeType() { Id = _Model.VehiculeTypeId },
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

        public IActionResult Details(int id)
        {

            var request = Repository.Request.GetOneById(id);
            return View(request);
        }

        public ActionResult Delete(int id)
        {
            var request = Repository.Request.GetOneById(id);
            return View(request);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Entities.Request request)
        {

            try
            {

                Repository.Request.Remove(request);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var request = Repository.Request.GetOneById(id);
            try
            {
                Models.RequestViewModel _Model = new Models.RequestViewModel
                {
                    Request = request,
                    VehiculeTypes = Repository.Vehicule.GetAllTypes(),
                    Requests = Repository.Request.GetAll(),
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("Request.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.RequestViewModel _Model)
        {
            {
                if (ModelState.IsValid)
                {
                    Repository.Request.Update(_Model.Request);
                    return RedirectToAction(nameof(Index));
                }
            }
            ModelState.AddModelError("", "Error");
            return View(_Model);

        }
    }

}
