using NOUR.PFE.Entities;
using System;

namespace NOUR.PFE.WEB.Models
{
    public class VehiculeViewModel
       
    {
        public Vehicule Vehicule { get; set; }
        public Vehicules Vehicules { get; set; }
        public VehiculeType vehiculeType { get; set; }
        public VehiculeTypes VehiculeTypes { get; set; }
        public VehiculeBrands VehiculeBrands { get; set; }
        public VehiculeBrand VehiculeBrand { get; set; }
        public VehiculeStatus Status { get; set; }
        public VehiculeStatuss Statuss { get; set; }
        public VehiculeDocument document { get; set; }
        public Parc parc { get; set; }


        public int Id { get; set; }
      

    }
}
