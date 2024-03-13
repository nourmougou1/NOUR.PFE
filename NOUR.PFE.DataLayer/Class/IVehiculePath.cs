using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.Class
{
    public interface IVehiculePath
    {
        IEnumerable<Entities.VehiculePath> GetAll();
        bool Add(Entities.VehiculePath vehiculePath);
        bool Update(Entities.VehiculePath vehiculePath);
        bool Delete(Entities.VehiculePath vehiculePath);
    }
}
