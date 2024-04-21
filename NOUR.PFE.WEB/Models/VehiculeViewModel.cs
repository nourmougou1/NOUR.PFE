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
        public DateTime PurshaseDate { get; set; }


        public int Id { get; set; }
        public int TypeId { get; set; }
        public int BrandId { get; set; }
        public int StatusId { get; set; }
        public string RegNumber { get; set; }
        public string Kilometrage { get; set; }

        public string brandName { get; set; }
        public string  parcName{ get; set; }

    }
}
