
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.Entities;
using NOUR.PFE.WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NOUR.PFE.WEB.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
      
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            DashboardViewModel dashboard = new DashboardViewModel();
            {
                var Users = Repository.User.GetAll();
                var Vehicules = Repository.Vehicule.GetAll();
                var Requests = Repository.Request.GetAll();
                var Maintenances = Repository.Maintenance.GetAll();


                dashboard.Vehicule_count = Vehicules.Count();
                dashboard.Users_count = Users.Count();
                dashboard.Reservations_count = Requests.Count();

                dashboard.Maintenance_count = Maintenances.Count();


                dashboard.VehiculeAvailable = Vehicules.Count(Vehicule => Vehicule.Status.Status_id == 2 );
                dashboard.VehiculeReserved = Vehicules.Count(Vehicule=>Vehicule.Status.Status_id ==1 );
                dashboard.VehiculeUnderMaintenance = Vehicules.Count(Vehicule => Vehicule.Status.Status_id == 3 );
               

                dashboard.RequestAccepted = Requests.Count(Request => Request.status.Id == 1);
                dashboard.RequestRejected = Requests.Count(Request => Request.status.Id == 3);
                dashboard.RequestPending = Requests.Count(Request => Request.status.Id == 2);

                
            }

            return View(dashboard);
          
        }

        //public IActionResult Dashbord()
        //{

        //    if (HttpContext.Session.GetString("User") == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    DashboardViewModel dashboard = new DashboardViewModel();
        //    {
        //        var Users = Repository.User.GetAll();
        //        var Vehicules = Repository.Vehicule.GetAll();
        //        int PrckID;
        //        //var Reservations = Repository.Request.GetAll(PrckID = -1);
        //        //var Parcs = Repository.Parc.GetAll();
        //        dashboard.voitures_count = Vehicules.Count();
        //        //dashboard.parcs_count = Parcs.Count();
        //        dashboard.users_count = Users.Count();
        //        //dashboard.reservations_count = Reservations.Count();
        //    }

        //    return View(dashboard);

        //}

        public IActionResult Privacy()
        {
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
