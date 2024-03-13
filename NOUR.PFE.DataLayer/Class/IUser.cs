using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.Class
{
    public interface IUser
    {
        IEnumerable<Entities.User> GetAll();
        Entities.User GetOne(int userId);
        Entities.User GetOneByLogin(string userLogin);

        bool Add(Entities.User user);
        bool Update(Entities.User user);
        bool Remove(Entities.User user);
    }
}
