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
        public static class VehiculePath
        {
            private static IVehiculePath VehiculePath_DL;

            static VehiculePath()
            {
            VehiculePath_DL = new VehiculePathDB();
            }
            public static Entities.VehiculePaths GetAll()
            {
                return (VehiculePath_DL != null)
                     ? new Entities.VehiculePaths(VehiculePath_DL.GetAll())
                     : null;

            }
          

           /* public static Entities.VehiculePath GetVehiculePathByID(int ID)
            {
                return (VehiculePath_DL != null)
                       ? VehiculePath_DL.GetVehiculePathByID(ID)
                       : null;
            }*/

            public static bool Add(Entities.VehiculePath vehiculePath)
            {
                return (VehiculePath_DL != null)
                       ? VehiculePath_DL.Add(vehiculePath)
                       : false;
            }

            public static bool Update(Entities.VehiculePath vehiculePath)
            {
                return (VehiculePath_DL != null)
                       ? VehiculePath_DL.Update(vehiculePath)
                       : false;
            }

            public static bool Delete(Entities.VehiculePath vehiculePath)
            {
                return (VehiculePath_DL != null)
                       ? VehiculePath_DL.Delete(vehiculePath)
                       : false;
            }
        
    }
}
