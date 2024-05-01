using System;

namespace NOUR.PFE.WEB.Models
{
    public class DashboardViewModel
    {
        public int Vehicule_count { get; set; }
        public int Users_count { get; set; }
        public int Reservations_count { get; set; }
        public DateTime CreationDate { get; set; }
        public int Maintenance_count { get; set; }
        public int VehiculeAvailable {  get; set; }
        public int VehiculeUnderMaintenance { get; set; }
        public int VehiculeUnavailable { get; set; }
        public int VehiculeReserved { get; set; }


    }
}
