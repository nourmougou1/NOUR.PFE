using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.Class
{
    public interface IVehicule
    {
        IEnumerable<Entities.Vehicule> GetAllVehicule();
        Entities.Vehicule GetOneByType(Type type);
        bool Add(Entities.Vehicule vehicule);
        bool Update(Entities.Vehicule vehicule);
        bool Remove(Entities.Vehicule vehicule);
        Entities.Vehicule GetOne(int vehiculeId);

        #region VehiculeBrand
        IEnumerable<Entities.VehiculeBrand> GetAllBrands();
        bool AddBrand(Entities.VehiculeBrand vehiculeBrand);
        bool UpdateBrand(Entities.VehiculeBrand vehiculeBrand);
        bool RemoveBrand(Entities.VehiculeBrand vehiculeBrand);
        Entities.VehiculeBrand GetBrandById (int brandId);
        #endregion

        #region VehiculeType
        IEnumerable<Entities.VehiculeType> GetAllTypes();
        bool AddType(Entities.VehiculeType vehiculeType);
        bool UpdateType(Entities.VehiculeType vehiculeType);
        bool DeleteType(Entities.VehiculeType vehiculeType);
        Entities.VehiculeType GetTypeById (int typeId);
        #endregion

        #region VehiculePath
        IEnumerable<Entities.VehiculePath> GetAllPaths();
        bool AddPath(Entities.VehiculePath vehiculePath);
        bool UpdatePath(Entities.VehiculePath vehiculePath);
        bool DeletePath(Entities.VehiculePath vehiculePath);
        #endregion

        #region VehiculeStatus
        IEnumerable<Entities.VehiculeStatus> GetAllStatus();
        bool AddStatus(Entities.VehiculeStatus vehiculeStatus);
        bool UpdateStatus(Entities.VehiculeStatus vehiculeStatus);
        bool DeleteStatus(Entities.VehiculeStatus vehiculeStatus);

        #endregion
    }
}
