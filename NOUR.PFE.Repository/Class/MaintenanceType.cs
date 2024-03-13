using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.DataLayer.DB;
using NOUR.PFE.DataLayer.DB.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NOUR.PFE.Entities;

namespace NOUR.PFE.Repository
{
    public static class MaintenanceType
    {
        private static IMaintenanceType MaintenanceType_DL;
        static MaintenanceType()
        {
            MaintenanceType_DL = new MaintenanceTypeDB();
        }
        public static Entities.MaintenanceTypes GetAll()
        {
            return (MaintenanceType_DL != null)
                ? new Entities.MaintenanceTypes(MaintenanceType_DL.GetAll())
                : null;

        }



        public static bool Add(Entities.MaintenanceType maintenanceType)
        {
            return (MaintenanceType_DL != null)
                   ? MaintenanceType_DL.Add(maintenanceType)
                   : false;
        }

        public static bool Update(Entities.MaintenanceType maintenanceType)
        {
            return (MaintenanceType_DL != null)
                   ? MaintenanceType_DL.Update(maintenanceType)
                   : false;
        }
        public static bool Remove(Entities.MaintenanceType maintenanceType)
        {
            return (MaintenanceType_DL != null)
                   ? MaintenanceType_DL.Remove(maintenanceType)
                   : false;
        }
    }
}
