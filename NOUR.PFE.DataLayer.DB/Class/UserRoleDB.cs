using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using NOUR.PFE.Entities;
using NOUR.PFE.DataLayer.Class;


namespace NOUR.PFE.DataLayer.DB
{
    public class UserRoleDB : IUserRole
    {
        public bool AddUserRole(UserRole UserRole)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserRole(UserRole UserRole)
        {
            throw new NotImplementedException();
        }

        public UserRole GetUserRoleByCode(string code)
        {
            throw new NotImplementedException();
        }

        public UserRole GetUserRoleByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            throw new NotImplementedException();
        }

      

        public bool UpdateUserRole(UserRole UserRole)
        {
            throw new NotImplementedException();
        }

       
    }
}

