using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer
{
    public interface IRequest
    {
        IEnumerable<Entities.Request> GetAll();
        bool Add(Entities.Request request);
        bool Update(Entities.Request request);
        bool Remove(Entities.Request request);
    }
}
