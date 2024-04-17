using Microsoft.AspNetCore.Mvc;
using NOUR.PFE.WEB.Models;

namespace NOUR.PFE.WEB.Controllers
{
    public class MaintenanceTypeController : Controller
    {
        public IActionResult Index()
        {
            MaintenanceTypeViewModel _Model = new MaintenanceTypeViewModel();
            _Model.MaintenanceTypes = Repository.Maintenance.GetAllMaintenanceTypes();
            return View("Index", _Model);
        }
    }
}
