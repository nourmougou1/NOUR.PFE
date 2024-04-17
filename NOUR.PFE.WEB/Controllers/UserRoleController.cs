using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NOUR.PFE.Web.Controllers;
using NOUR.PFE.WEB.Models;
using System.Linq;
using System;

namespace NOUR.PFE.WEB.Controllers
{
    public class UserRoleController : Controller
    {
        private IConfiguration _Config;
        public UserRoleController(IConfiguration iConfig) 
        {
            _Config = iConfig;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserRoleViewModel _Model = new UserRoleViewModel();
            _Model.UserRoles = Repository.Config.GetUserRoles();
            return View("Index", _Model);
        }
        public IActionResult Create()
        {
            Models.UserRoleViewModel _Model = new Models.UserRoleViewModel
            {
                UserRoles = Repository.Config.GetUserRoles()
            };

            return View(_Model);
        }
        public IActionResult Create(Models.UserViewModel _Model) 
        {
            if (ModelState.IsValid)
            {
                Entities.UserRoles _UserRoles = Repository.Config.GetUserRoles();

                if (_UserRoles.FirstOrDefault(ur => ur.Code.Trim().Equals(_Model.UserRole.Code.Trim())) != null)
                {
                    ModelState.AddModelError("Code", "Code invalide!");
                    _Model.UserRoles = Repository.Config.GetUserRoles();

                    return View(_Model);
                }
                var userRole = new Entities.UserRole
                {
                    Name = _Model.UserRole.Name, 
                    Code = _Model.UserRole.Code
                
                };

                if (Repository.Config.AddUserRole(userRole))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            _Model.UserRoles = Repository.Config.GetUserRoles();
            return View(_Model);

        }
       
    }
}
