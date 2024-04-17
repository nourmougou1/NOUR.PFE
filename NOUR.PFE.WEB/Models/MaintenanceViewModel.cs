using NOUR.PFE.Entities;
using System;

namespace NOUR.PFE.WEB.Models
{
    public class MaintenanceViewModel
    {
        public Maintenance Maintenance { get; set; }
        public Maintenances Maintenances { get; set; }
        public int Id { get; set; }
        public MaintenanceType MaintenanceType { get; set; }
        public DateTime DateDebut { get; set; }
        public string Address { get; set; }
        public Vehicule Vehicule { get; set; }
  
    }
}
