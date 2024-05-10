using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class Vehicule
    {

        #region Constructor
        public Vehicule()
        {
            VehiculeType = new VehiculeType();
            VehiculeBrand = new VehiculeBrand();
          
        }
        #endregion

        #region Properties


        public int Id { get; set; }
        public string Imm { get; set; }
        public VehiculeType VehiculeType { get; set; }
        public VehiculeBrand VehiculeBrand { get; set; }
        public VehiculeStatus Status { get; set; }
        public int VehiculeTypeId { get; set; }
        public int VehiculeBrandId { get; set; }
        public int StatusId { get; set; }
        public string Kilometrage { get; set; }
        public VehiculeDocument document { get; set; }
        public int ParcId { get; set; }
        public Parc parc { get; set; }
        public DateTime PurshaseDate { get; set; }




        #endregion

    }
}
