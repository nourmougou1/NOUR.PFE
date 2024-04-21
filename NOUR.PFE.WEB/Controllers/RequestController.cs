using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOUR.PFE.WEB.Models;

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
    }
}