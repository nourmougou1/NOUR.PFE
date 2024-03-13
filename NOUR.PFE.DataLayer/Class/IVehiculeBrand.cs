using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.Class
{
    public interface IVehiculeBrand
    {
        IEnumerable<Entities.VehiculeBrand> GetAll();
        bool Add(Entities.VehiculeBrand vehiculeBrand);
        bool Update(Entities.VehiculeBrand vehiculeBrand);
        bool Remove(Entities.VehiculeBrand vehiculeBrand);
    }
}
