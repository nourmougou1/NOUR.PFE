using NOUR.PFE.Entities;
using System;

namespace NOUR.PFE.WEB.Models
{
    public class VehiculeViewModel
       
    {
        public Vehicule Vehicule { get; set; }
        public Vehicules Vehicules { get; set; }
        public int Id { get; set; }
        public string Imm { get;}
        public VehiculeType vehiculeType { get; set; }
        public VehiculeTypes VehiculeTypes { get; set; }
        public VehiculeBrands VehiculeBrands { get; set; }
        public VehiculeStatus Status { get; set; }
        public VehiculeStatuss Statuss { get; set; }
        public String Kilometrage { get; set; }
        public VehiculeDocument document { get; set; }
        public Parc parc { get; set; }
        public DateTime PurshaseDate { get; set; }
       
    }
}
