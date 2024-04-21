using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class Maintenance
    {
        #region Constructors
        public Maintenance() 
        {
            MaintenanceType = new MaintenanceType();
            Vehicule = new Vehicule();

        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public MaintenanceType MaintenanceType { get; set; }
        public int MaintenanceTypeId { get; set; }
        public DateTime DateDebut { get; set; }
        public string Address { get; set; }
        public Vehicule Vehicule { get; set; } 
        public int VehiculeId { get; set; }
        public string description { get; set; }
        #endregion


    }
}
