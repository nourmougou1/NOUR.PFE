using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer
{
    public interface IMaintenance
    {
        IEnumerable<Entities.Maintenance> GetAll();
        Entities.Maintenance GetOneByVehiculeId(int VehiculeId);
        bool Add(Entities.Maintenance maintenance);
        bool Update(Entities.Maintenance maintenance);
        bool Remove(Entities.Maintenance maintenance);
        IEnumerable<Entities.MaintenanceType> GetAllMaintenanceTypes();
        IEnumerable<Entities.Vehicule> GetAllVehicule();
        bool AddMaintenanceType(Entities.MaintenanceType maintenanceType);
        bool UpdateMaintenanceType(Entities.MaintenanceType maintenanceType);
        bool RemoveMaintenanceType(Entities.MaintenanceType maintenanceType);
        Entities.MaintenanceType GetMaintenanceTypeById(int id);
    }
}
