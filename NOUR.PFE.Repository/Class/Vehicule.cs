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
    public static class Vehicule
    {
        private static IVehicule Vehicule_DL;
        static Vehicule ()
        {
            Vehicule_DL = new VehiculeDB();
        }

        #region Vehicule
        public static Entities.Vehicules GetAll()
        {
            return (Vehicule_DL != null)
                ? new Entities.Vehicules(Vehicule_DL.GetAllVehicule())
                : null;
        }
        public static Entities.Vehicule GetOneByType(Type type)
        {
            return (Vehicule_DL != null)
                ? Vehicule_DL.GetOneByType(type)
                : null;
        }
        public static bool Add(Entities.Vehicule vehicule)
        {
            return (Vehicule_DL != null)
                ? Vehicule_DL.Add(vehicule)
                : false;
        }
        public static bool Update(Entities.Vehicule vehicule)
        {
            return (Vehicule_DL != null)
                ? Vehicule_DL.Update(vehicule)
                : false;
        }
        public static bool Remove(Entities.Vehicule vehicule)
        {
            return (Vehicule_DL != null)
                ? Vehicule_DL.Remove(vehicule)
                : false;
        }
        #endregion

        #region vehiculeBrand
        public static Entities.VehiculeBrands GetAllBrands()
        {
            return (Vehicule_DL != null)
                ? new Entities.VehiculeBrands(Vehicule_DL.GetAllBrands())
                : null;
        }
        public static bool AddBrand(Entities.VehiculeBrand vehiculeBrand)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.AddBrand(vehiculeBrand)
                   : false;
        }

        public static bool UpdateBrand(Entities.VehiculeBrand vehiculeBrand)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.UpdateBrand(vehiculeBrand)
                   : false;
        }
        public static bool RemoveBrand(Entities.VehiculeBrand vehiculeBrand)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.RemoveBrand(vehiculeBrand)
                   : false;
        }
        #endregion

        #region VehiculePath
        public static Entities.VehiculePaths GetAllPaths()
        {
            return (Vehicule_DL != null)
                 ? new Entities.VehiculePaths(Vehicule_DL.GetAllPaths())
                 : null;

        }


        /* public static Entities.VehiculePath GetVehiculePathByID(int ID)
         {
             return (Vehicule_DL != null)
                    ? Vehicule_DL.GetVehiculePathByID(ID)
                    : null;
         }*/

        public static bool AddPath(Entities.VehiculePath vehiculePath)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.AddPath(vehiculePath)
                   : false;
        }

        public static bool UpdatePath(Entities.VehiculePath vehiculePath)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.UpdatePath(vehiculePath)
                   : false;
        }

        public static bool DeletePath(Entities.VehiculePath vehiculePath)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.DeletePath(vehiculePath)
                   : false;
        }

        #endregion

        #region vehiculeType
        public static Entities.VehiculeTypes GetAllTypes()
        {
            return (Vehicule_DL != null)
                 ? new Entities.VehiculeTypes(Vehicule_DL.GetAllTypes())
                 : null;

        }

        public static bool AddType(Entities.VehiculeType vehiculeType)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.AddType(vehiculeType)
                   : false;
        }

        public static bool UpdateType(Entities.VehiculeType vehiculeType)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.UpdateType(vehiculeType)
                   : false;
        }

        public static bool DeleteType(Entities.VehiculeType vehiculeType)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.DeleteType(vehiculeType)
                   : false;
        }

        #endregion


        public static Entities.VehiculeStatuss GetAllStatus()
        {
            return (Vehicule_DL != null)
                 ? new Entities.VehiculeStatuss(Vehicule_DL.GetAllStatus())
                 : null;

        }
        public static bool AddStatus(Entities.VehiculeStatus vehiculeStatus)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.AddStatus(vehiculeStatus)
                   : false;
        }
        public static bool UpdateStatus(Entities.VehiculeStatus vehiculeStatus)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.UpdateStatus(vehiculeStatus)
                   : false;
        }
        public static bool DeleteStatus(Entities.VehiculeStatus vehiculeStatus)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.DeleteStatus(vehiculeStatus)
                   : false;
        }
        public static Entities.Vehicule GetOne(int vehiculeId)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.GetOne(vehiculeId)
                   : null;
        } 
        
        public static Entities.VehiculeBrand GetBrandById(int brandId)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.GetBrandById(brandId)
                   : null;
        }
        public static Entities.VehiculeType GetTypeById(int typeId)
        {
            return (Vehicule_DL != null)
                   ? Vehicule_DL.GetTypeById(typeId)
                   : null;
        }



    }
}
