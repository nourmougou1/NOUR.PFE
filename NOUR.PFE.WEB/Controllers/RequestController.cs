using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.Entities;
using NOUR.PFE.Repository;
using NOUR.PFE.WEB.Models;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;

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
            Entities.User _User = JsonConvert.DeserializeObject<Entities.User>(HttpContext.Session.GetString("User"));


            RequestViewModel _Model = new RequestViewModel();
            _Model.Requests = Repository.Request.GetAll((_User.UserRole.Id != (int)Entities.Enumeration.Enumeration.UserRole.ADMIN) ? _User.Id : -1);
            if (_User.Id == 1)
            {
                return View("Index", _Model);
            }
            else
            {
                return View("MyReservations", _Model);
            }
        }

        [HttpGet]
        public IActionResult MyReservations()
        {
            Entities.User _User = JsonConvert.DeserializeObject<Entities.User>(HttpContext.Session.GetString("User"));

            RequestViewModel _Model = new RequestViewModel();
            _Model.Requests = Repository.Request.GetAll(_User.Id);
            return View("MyReservations", _Model);
        }

        [HttpGet]
        public IActionResult Affect(int id)
        {
            RequestViewModel _Model = new RequestViewModel();
            _Model.Request = Repository.Request.GetOneById(id);
            Entities.User user = _Model.Request.User;

            if (_Model.Request != null)
            {
                Entities.Vehicules _SortedVehicules = new Entities.Vehicules();
                Entities.Vehicules _AllVehicules = Repository.Vehicule.GetAll();
                if ((_AllVehicules != null) && (_AllVehicules.Count > 0))
                {
                    foreach (Entities.Vehicule veh in _AllVehicules)
                    {
                        if ((veh.VehiculeType.Id == _Model.Request.VehiculeType.Id) &&
                            (veh.Status.Status_id == (int)Entities.Enumeration.Enumeration.VehiculeStat.Available))
                        {
                            _SortedVehicules.Add(veh);
                        }
                    }
                }
                _Model.vehicules = _SortedVehicules;

                return View("Affect", _Model);
            }
            return RedirectToAction("Index", "Request");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Affect(int id, Models.RequestViewModel _Model)
        {
            {
                if (ModelState.IsValid)

                {

                    Entities.Request Req = Repository.Request.GetOneById(id);
                    Req.status = new NOUR.PFE.Entities.Class.RequestStatus() { Id = (int)Entities.Enumeration.Enumeration.enumReqStat.Confirmed };
                    Req.Vehicule = Repository.Vehicule.GetOne(_Model.VehiculeId);
                    Repository.Request.Update(Req);
                    Req.Vehicule.Status = new NOUR.PFE.Entities.VehiculeStatus() { Status_id = (int)Entities.Enumeration.Enumeration.VehiculeStat.Reserved };
                    Repository.Vehicule.UpdateVehiculeStatus(Req.Vehicule);

                    _Model.User = Repository.User.GetOne(Req.User.Id);

                    Utils.Mailing.sendMailHtml("Hotix", _Model.User.Email, "HOTIX",
                    "RESERVATION", $"Hello {Req.User.FirstName}, we are pleased to inform you that your reservation request has been successfully confirmed. We have assigned the vehicle : {Req.Vehicule.Imm}", "developpement@hotixsoft.com",
                    "hD@123456", "mail.bmail.tn", 465, true, false);

                    return RedirectToAction(nameof(Index));
                }
            }
            ModelState.AddModelError("", "Error");
            return View(_Model);

        }

        public IActionResult Refuse(int id, Models.RequestViewModel _Model)
        {
            Entities.Request Req = Repository.Request.GetOneById(id);
            if (Req != null)
            {
                Req.status = new NOUR.PFE.Entities.Class.RequestStatus() { Id = (int)Entities.Enumeration.Enumeration.enumReqStat.Refused };
                Req.Vehicule = new Entities.Vehicule() { Id = -1 };
                Repository.Request.Update(Req);

                _Model.User = Repository.User.GetOne(Req.User.Id);

                Utils.Mailing.sendMailHtml("Hotix", _Model.User.Email, "HOTIX",
                   "RESERVATION", $"Hello, We regret to inform you that your reservation request has been refused. ", "developpement@hotixsoft.com",
                   "hD@123456", "mail.bmail.tn", 465, true, false);
            }

            return RedirectToAction(nameof(Index));
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
                    return RedirectToAction(nameof(MyReservations));
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
            Entities.User _User = JsonConvert.DeserializeObject<Entities.User>(HttpContext.Session.GetString("User"));

            try
            {

                Repository.Request.Remove(request);
                if (_User.Id == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(MyReservations));
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
