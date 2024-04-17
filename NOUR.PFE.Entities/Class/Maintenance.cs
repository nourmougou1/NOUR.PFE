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


        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public MaintenanceType MaintenanceType { get; set; }
        public DateTime DateDebut { get; set; }
        public string Address { get; set; }
        public Vehicule Vehicule { get; set; } 
        #endregion


    }
}
