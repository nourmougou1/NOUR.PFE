
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NOUR.PFE.WEB.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

      

        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("User") == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //DashboardViewModel dashboard = new DashboardViewModel();
            //{
            //    var Users = Repository.User.GetAll();
            //    var Vehicules = Repository.Vehicule.GetAll();
            //    int PrckID;
            //    //var Request = Repository.Request.GetAll(PrckID = -1);
            //    dashboard.voitures_count = Vehicules.Count();
            //    //dashboard.parcs_count = Parcs.Count();
            //    dashboard.users_count = Users.Count();
            //    //dashboard.reservations_count = Reservations.Count();
            //}

            //return View(dashboard);
            return View();
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
