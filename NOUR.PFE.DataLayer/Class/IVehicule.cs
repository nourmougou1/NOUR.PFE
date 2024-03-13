using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.Class
{
    public interface IVehicule
    {
        IEnumerable<Entities.Vehicule> GetAll();
        Entities.Vehicule GetOneByType(Type type);
        bool Add(Entities.Vehicule vehicule);
        bool Update(Entities.Vehicule vehicule);
        bool Remove(Entities.Vehicule vehicule);

    }
}
