using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.DataLayer.DB.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Repository
{
    public static class VehiculeBrand
    {
        private static IVehiculeBrand VehiculeBrand_DL;
        static VehiculeBrand()
        {
            VehiculeBrand_DL = new VehiculeBrandDB();
        }
      
        public static Entities.VehiculeBrands GetAll()
        {
            return (VehiculeBrand_DL != null)
                ? new Entities.VehiculeBrands(VehiculeBrand_DL.GetAll())
                : null;
        }
        public static bool Add(Entities.VehiculeBrand vehiculeBrand)
        {
            return (VehiculeBrand_DL != null)
                   ? VehiculeBrand_DL.Add(vehiculeBrand)
                   : false;
        }

        public static bool Update(Entities.VehiculeBrand vehiculeBrand)
        {
            return (VehiculeBrand_DL != null)
                   ? VehiculeBrand_DL.Update(vehiculeBrand)
                   : false;
        }
        public static bool Remove(Entities.VehiculeBrand vehiculeBrand)
        {
            return (VehiculeBrand_DL != null)
                   ? VehiculeBrand_DL.Remove(vehiculeBrand)
                   : false;
        }
    }
}
