using Microsoft.AspNetCore.Mvc;

namespace NOUR.PFE.WEB.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
