using NOUR.PFE.DataLayer;
using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.DataLayer.DB;
using NOUR.PFE.DataLayer.DB.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Repository
{
    public static class Maintenance
    {
        #region Declaration
        private static IMaintenance Maintenance_DL;
        static Maintenance()
        {
            Maintenance_DL = new MaintenanceDB();
        }
        #endregion

        #region Maintenance
        public static Entities.Maintenances GetAll()
        {
            return (Maintenance_DL != null)
                ? new Entities.Maintenances(Maintenance_DL.GetAll())
                : null;
        }

        //public static Entities.Maintenances GetAllVehicule()
        //{
        //    return (Maintenance_DL != null)
        //        ? new Entities.Maintenances(Maintenance_DL.GetAllVehicule())
        //        : null;
        //}

        public static Entities.Maintenance GetOneByVehiculeId(int VehiculeId)
        {
            return (Maintenance_DL != null)
                   ? Maintenance_DL.GetOneByVehiculeId(VehiculeId)
                   : null;
        }
        public static Entities.MaintenanceType GetMaintenanceTypeById(int MaintenanceTypeId)
        {
            return (Maintenance_DL != null)
                   ? Maintenance_DL.GetMaintenanceTypeById(MaintenanceTypeId)
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
                   ? Maintenance_DL.Update(maintenance)
                   : false;
        }

        public static bool Remove(Entities.Maintenance maintenance)
        {
            return (Maintenance_DL != null)
                   ? Maintenance_DL.Remove(maintenance)
                   : false;
        }
        #endregion

        #region MaintenanceType
        public static Entities.MaintenanceTypes GetAllMaintenanceTypes()
        {
            return (Maintenance_DL != null)
                ? new Entities.MaintenanceTypes(Maintenance_DL.GetAllMaintenanceTypes())
                : null;

        }
        public static bool AddMaintenanceType(Entities.MaintenanceType maintenanceType)
        {
            return (Maintenance_DL != null)
                   ? Maintenance_DL.AddMaintenanceType(maintenanceType)
                   : false;
        }

        public static bool UpdateMaintenanceType(Entities.MaintenanceType maintenanceType)
        {
            return (Maintenance_DL != null)
                   ? Maintenance_DL.UpdateMaintenanceType(maintenanceType)
                   : false;
        }
        public static bool RemoveMaintenanceType(Entities.MaintenanceType maintenanceType)
        {
            return (Maintenance_DL != null)
                   ? Maintenance_DL.RemoveMaintenanceType(maintenanceType)
                   : false;
        }
        #endregion





    }
}
