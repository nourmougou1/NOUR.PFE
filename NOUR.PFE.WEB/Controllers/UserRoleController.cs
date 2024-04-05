using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NOUR.PFE.Web.Controllers;
using NOUR.PFE.WEB.Models;

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
    }
}
