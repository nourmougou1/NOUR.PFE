using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Status { get; set; }
        public DateTime PurshaseDate { get; set; }
        public VehiculeType VehiculeType { get; set; }
        public VehiculeBrand VehiculeBrand { get; set; }

        public string Kilometrage { get; set; }
        


        #endregion

    }
}
