using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.Class
{
    public interface IMaintenanceType
    {
        IEnumerable<Entities.MaintenanceTypes> GetAll();
        bool Add(Entities.MaintenanceType maintenanceType);
        bool Update(Entities.MaintenanceType maintenanceType);
        bool Remove(Entities.MaintenanceType maintenanceType);
    }
}
