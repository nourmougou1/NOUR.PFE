using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.DB
{
    public class UserDB : IUser
    {
        public bool Add(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetOne(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetOneByLogin(string userLogin)
        {
            throw new NotImplementedException();
        }

        public bool Remove(User user)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
