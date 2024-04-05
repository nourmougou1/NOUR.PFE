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
    public class UserController : Controller
    {
        private IConfiguration _Config;
        public UserController(IConfiguration iConfig)
        {
            _Config = iConfig;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserViewModel _Model = new UserViewModel();
            _Model.Users = Repository.User.GetAll();
            return View("Index", _Model);
        }  
    }
}
