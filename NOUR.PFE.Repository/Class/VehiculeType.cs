using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.DataLayer.DB;
using NOUR.PFE.DataLayer.DB.Class;
using NOUR.PFE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Repository
{
    public static class VehiculeType
    {
        private static IVehiculeType VehiculeType_DL;
        static VehiculeType()
        {
            VehiculeType_DL = new VehiculeTypeDB();
        }

        public static Entities.VehiculeTypes GetAll()
        {
            return (VehiculeType_DL != null)
                ? new Entities.VehiculeTypes(VehiculeType_DL.GetAll())
                : null;
        }
        public static bool Add(Entities.VehiculeType vehiculeType)
        {
            return (VehiculeType_DL != null)
                   ? VehiculeType_DL.Add(vehiculeType)
                   : false;
        }

        public static bool Update(Entities.VehiculeType vehiculeType)
        {
            return (VehiculeType_DL != null)
                   ? VehiculeType_DL.Update(vehiculeType)
                   : false;
        }
        public static bool Remove(Entities.VehiculeType vehiculeType)
        {
            return (VehiculeType_DL != null)
                   ? VehiculeType_DL.Remove(vehiculeType)
                   : false;
        }
    }
}
