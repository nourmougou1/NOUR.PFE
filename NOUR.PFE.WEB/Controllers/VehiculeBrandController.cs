using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOUR.PFE.Entities;
using NOUR.PFE.WEB.Models;
using System;
using System.Linq;

namespace NOUR.PFE.WEB.Controller
{
    public class VehiculeBrandController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IConfiguration _Config;
        public VehiculeBrandController(IConfiguration iConfig)
        {
            _Config = iConfig;
        }

        [HttpGet]
        public IActionResult Index()
        {
            BrandViewModel _Model = new BrandViewModel();
            _Model.VehiculeBrands = Repository.Vehicule.GetAllBrands();
            return View("Index", _Model);
        }

        [HttpPost]
        public ActionResult Create()
        {
            Models.BrandViewModel _Model = new Models.BrandViewModel
            {
                VehiculeBrands = Repository.Vehicule.GetAllBrands()
            };

            return View(_Model);

        }
        [HttpPost]

        public IActionResult Create(Models.BrandViewModel _Model)
        {
            if (ModelState.IsValid)
            {
                Entities.VehiculeBrands _brands = Repository.Vehicule.GetAllBrands();

                if (_brands.FirstOrDefault(vb => vb.Name.Trim().Equals(_Model.VehiculeBrand.Name.Trim())) != null)
                {
                    ModelState.AddModelError("Code", "Code invalide!");
                    _Model.VehiculeBrands = Repository.Vehicule.GetAllBrands();

                    return View(_Model);
                }
                var vehiculeBrand = new Entities.VehiculeBrand
                {
                    Name = _Model.VehiculeBrand.Name,
                    Logo = _Model.VehiculeBrand.Logo

                };

                if (Repository.Vehicule.AddBrand(vehiculeBrand))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            _Model.VehiculeBrands = Repository.Vehicule.GetAllBrands();
            return View(_Model);

        }

        public IActionResult Details(int id)
        {
            NOUR.PFE.WEB.Models.BrandViewModel _Model = new NOUR.PFE.WEB.Models.BrandViewModel();
            _Model.VehiculeBrand = Repository.Vehicule.GetBrandById(id);
            return View(_Model);
        }

        public ActionResult Delete(int id)
        {
            var vehiculeBrand = Repository.Vehicule.GetBrandById(id);
            return View(vehiculeBrand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Entities.VehiculeBrand brand)
        {

            try
            {

                Repository.Vehicule.RemoveBrand(brand);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var vehiculeBrand = Repository.Vehicule.GetBrandById(id);
            try
            {
                Models.BrandViewModel _Model = new Models.BrandViewModel
                {
                    Name = vehiculeBrand.Name,
                    Logo = vehiculeBrand.Logo,
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("VehiculeBrand.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.BrandViewModel _Model)
        {
            {
                if (ModelState.IsValid)
                {
                    var Brand = new VehiculeBrand
                    {

                        Name = _Model.Name,
                        Logo = _Model.Logo

                    };
                    Repository.Vehicule.UpdateBrand(Brand);
                    return RedirectToAction(nameof(Index));
                }

            }
            ModelState.AddModelError("", "Error");
            return View(_Model);
        }
    }
}
