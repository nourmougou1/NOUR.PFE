using NOUR.PFE.Entities;
using System;
using System.Collections.Generic;

namespace NOUR.PFE.WEB.Models
{
    public class MaintenanceViewModel
    {
        public Maintenance Maintenance { get; set; }
        public int Id { get; set; }
        public int VehiculeId {  get; set; } 
        public int MaintenanceTypeId { get; set; }
        public MaintenanceType MaintenanceType { get; set; }
        public DateTime DateDebut { get; set; }
        public string Address { get; set; }
        public Vehicule Vehicule { get; set; }
        public IEnumerable<Vehicule> Vehicules { get; set; }
        public IEnumerable<MaintenanceType> MaintenanceTypes { get; set; }
        public IEnumerable<Maintenance> Maintenances { get; set; }


    }
}
