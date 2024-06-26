﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NOUR.PFE.Entities;
using NOUR.PFE.Repository;
using NOUR.PFE.WEB.Models;
using Org.BouncyCastle.Ocsp;
using System;
using System.IO;

namespace NOUR.PFE.WEB.Controller
{
    public class MaintenanceController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IConfiguration _Config;
        public MaintenanceController(IConfiguration iConfig)
        {
            _Config = iConfig;
        }

        [HttpGet]
        public IActionResult Index()
        {
            MaintenanceViewModel _Model = new MaintenanceViewModel();
            _Model.Maintenances = Repository.Maintenance.GetAll();
            return View("Index", _Model);
        }

        public IActionResult Create()
        {
            MaintenanceViewModel Model = new MaintenanceViewModel();
            Model.MaintenanceTypes = Repository.Maintenance.GetAllMaintenanceTypes();
            Model.Vehicules = Repository.Vehicule.GetAll();
            return View(Model);
        }

        [HttpPost]
        public IActionResult Create(Models.MaintenanceViewModel _Model)
        {
            Entities.Vehicule veh = new Entities.Vehicule() { Id = _Model.VehiculeId };
            if (ModelState.IsValid)
            {
                Entities.Maintenances _maintenance = Repository.Maintenance.GetAll();
                var maintenance = new Entities.Maintenance
                {
                    Vehicule = veh,
                    MaintenanceType = new MaintenanceType() { Id = _Model.MaintenanceTypeId },
                    DateDebut = _Model.DateDebut,
                    Address = _Model.Address,
                    description = _Model.description
                };

                if (Repository.Maintenance.Add(maintenance))
                {
                    veh.Status = new NOUR.PFE.Entities.VehiculeStatus() { Status_id = (int)Entities.Enumeration.Enumeration.VehiculeStat.Maintenance };
                    Repository.Vehicule.UpdateVehiculeStatus(veh);
                    return RedirectToAction(nameof(Index));
                } 
            }
            _Model.Maintenances = Repository.Maintenance.GetAll();
            return View(_Model);
        }

        public IActionResult Delete(int maintenanceId)
        {
            var maintenance = Repository.Maintenance.GetMaintenanceById(maintenanceId);
            return View(maintenance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Entities.Maintenance maintenance)
        {
            try
            {
                Repository.Maintenance.Remove(maintenance);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Details(int id)
        {

            var maintenance = Repository.Maintenance.GetMaintenanceById(id);
            Models.MaintenanceViewModel _Model = new Models.MaintenanceViewModel
            {
                VehiculeId = maintenance.VehiculeId,
                MaintenanceTypeId = maintenance.MaintenanceTypeId,
                MaintenanceType = Repository.Maintenance.GetMaintenanceTypeById(maintenance.MaintenanceTypeId),
                Address = maintenance.Address,
                MaintenanceTypes = Repository.Maintenance.GetAllMaintenanceTypes(),
                Vehicules = Repository.Vehicule.GetAll(),
                Vehicule = Repository.Vehicule.GetOne(maintenance.VehiculeId),
                DateDebut = maintenance.DateDebut,
                description = maintenance.description,
                Maintenances = Repository.Maintenance.GetAll(),
            };
            return View(_Model);
        }
        public IActionResult Edit(int id)
        {
            var maintenance = Repository.Maintenance.GetMaintenanceById(id);
            try
            {
                Models.MaintenanceViewModel _Model = new Models.MaintenanceViewModel
                {
                    VehiculeId = maintenance.VehiculeId,
                    MaintenanceTypeId = maintenance.MaintenanceTypeId,
                    MaintenanceType = Repository.Maintenance.GetMaintenanceTypeById(maintenance.MaintenanceTypeId),
                    Address = maintenance.Address,
                    MaintenanceTypes = Repository.Maintenance.GetAllMaintenanceTypes(),
                    Vehicules = Repository.Vehicule.GetAll(),
                    Vehicule = Repository.Vehicule.GetOne(maintenance.VehiculeId),
                    DateDebut = maintenance.DateDebut,
                    description = maintenance.description,
                    Maintenances = Repository.Maintenance.GetAll(),
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("User.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.MaintenanceViewModel _Model)
        {
            var maintenance = Repository.Maintenance.GetMaintenanceById(id);
            if (ModelState.IsValid)
            {
                var editMaintenance = new Entities.Maintenance
                {
                    Id = _Model.Id,
                    VehiculeId = _Model.VehiculeId,
                    MaintenanceType = _Model.MaintenanceType,
                    MaintenanceTypeId = _Model.MaintenanceTypeId,
                    Address = _Model.Address,
                    description = _Model.description,
                    DateDebut = _Model.DateDebut
                };

                Repository.Maintenance.Update(editMaintenance);
                return RedirectToAction(nameof(Index));
            }
            return View(_Model);
        }
    }
}
