using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.Class
{
    public interface IMaintenance
    {
        IEnumerable<Entities.Maintenances> GetAll();
        Entities.Maintenance GetOneByVehiculeId(int VehiculeId);
        bool Add(Entities.Maintenance maintenance);
        bool Update(Entities.Maintenance maintenance);
        bool Remove(Entities.Maintenance maintenance);
    }
}
