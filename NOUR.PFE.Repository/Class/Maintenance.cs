using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.DataLayer.DB;
using NOUR.PFE.DataLayer.DB.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Repository.Class
{
    public static class Maintenance
    {
        #region Declaration
        private static IMaintenance Maintenance_DL;
        static Maintenance ()
        {
            Maintenance_DL = new MaintenanceDB();
        }
        #endregion

        public static Entities.Maintenances GetAll()
        {
            return (Maintenance_DL != null)
                ? new Entities.Maintenances(Maintenance_DL.GetAll())
                : null;
        }

        public static Entities.Maintenance GetOneByVehiculeId(int VehiculeId)
        {
            return (Maintenance_DL != null)
                   ? Maintenance_DL.GetOneByVehiculeId(VehiculeId)
                   : null;
        }

        public static bool Add(Entities.Maintenance maintenance)
        {
            return (Maintenance_DL != null)
                   ? Maintenance_DL.Add(maintenance)
                   : false;
        }

        public static bool Update(Entities.Maintenance maintenance)
        {
            return (Maintenance_DL != null)
                   ?Maintenance_DL.Update(maintenance)
                   : false;
        }

        public static bool Remove(Entities.Maintenance maintenance)
        {
            return (Maintenance_DL != null)
                   ? Maintenance_DL.Remove(maintenance)
                   : false;
        }
    }
}
