using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOUR.PFE.WEB.Models;

namespace NOUR.PFE.WEB.Controller
{
    public class PendingReservationController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IConfiguration _Config;
        public PendingReservationController(IConfiguration iConfig)
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
    }
}
