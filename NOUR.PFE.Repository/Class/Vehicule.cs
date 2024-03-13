using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.DataLayer.DB.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Repository.Class
{
    public static class Vehicule
    {
        private static IVehicule Vehicule_DL;
        static Vehicule ()
        {
            Vehicule_DL = new VehiculeDB();
        }

        public static Entities.Vehicules GetAll()
        {
            return (Vehicule_DL != null)
                ? new Entities.Vehicules(Vehicule_DL.GetAll())
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


 

    }
}
