using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.Class
{
    public interface IVehiculeType
    {
        IEnumerable<Entities.VehiculeTypes> GetAll();
        bool Add(Entities.VehiculeType vehiculeType);
        bool Update(Entities.VehiculeType vehiculeType);
        bool Remove(Entities.VehiculeType vehiculeType);
    }
}
