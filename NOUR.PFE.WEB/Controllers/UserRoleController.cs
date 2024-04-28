using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NOUR.PFE.Web.Controllers;
using NOUR.PFE.WEB.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NOUR.PFE.Entities;

namespace NOUR.PFE.WEB.Controller
{
    public class UserRoleController : Microsoft.AspNetCore.Mvc.Controller
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

        public IActionResult Edit(int id)
        {
            var userRole = Repository.Config.GetUserRoleByID(id);
            try
            {
                Models.UserRoleViewModel _Model = new Models.UserRoleViewModel
                {
                    Name = userRole.Name,
                    Code = userRole.Code,
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("UserRole.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.UserRoleViewModel _Model)
        {
            {
                if (ModelState.IsValid)
                {
                    var Role = new UserRole
                    {
                        Name = _Model.Name,
                        Code = _Model.Code
                    };
                    Repository.Config.UpdateUserRole(Role);
                    return RedirectToAction(nameof(Index));
                }
            }
            ModelState.AddModelError("", "Error");
            return View(_Model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Models.UserRoleViewModel _Model = new Models.UserRoleViewModel
            {
                UserRoles = Repository.Config.GetUserRoles()
            };

            return View(_Model);
        }


        [HttpPost]
        public IActionResult Create(Models.UserRoleViewModel _Model)
        {
            if (ModelState.IsValid)
            {
                Entities.UserRoles _UserRoles = Repository.Config.GetUserRoles();

                //if (_UserRoles.FirstOrDefault(ur => ur.Code.Trim().Equals(_Model.UserRole.Code.Trim())) != null)
                //{
                //    ModelState.AddModelError("Code", "Code invalide!");
                //    _Model.UserRoles = Repository.Config.GetUserRoles();

                //    return View(_Model);
                //}
                var userRole = new Entities.UserRole
                {
                    Name = _Model.Name,
                    Code = _Model.Code

                };

                if (Repository.Config.AddUserRole(userRole))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            _Model.UserRoles = Repository.Config.GetUserRoles();
            return View(_Model);

        }

        public ActionResult Delete(int id)
        {
            var userRole = Repository.Config.GetUserRoleByID(id);
            return View(userRole);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Entities.UserRole userRole)
        {
            try
            {
                Repository.Config.DeleteUserRole(userRole);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            NOUR.PFE.WEB.Models.UserRoleViewModel _Model = new NOUR.PFE.WEB.Models.UserRoleViewModel();
            _Model.UserRole = Repository.Config.GetUserRoleByID(id);
            return View(_Model);
        }
    }
}
