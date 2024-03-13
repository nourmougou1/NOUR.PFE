using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.DataLayer.DB;
using NOUR.PFE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Repository.Class
{
    public static class UserRole
    {
        private static IUserRole UserRole_DL;

        static UserRole()
        {
            UserRole_DL = new UserRoleDB();
        }
        public static Entities.UserRoles GetUserRoles()
        {
            return (UserRole_DL != null)
                 ? new Entities.UserRoles(UserRole_DL.GetUserRoles())
                 : null;

        }
        public static Entities.UserRole GetUserRoleByCode(string code)
        {
            return (UserRole_DL != null)
                   ? UserRole_DL.GetUserRoleByCode(code)
                   : null;
        }

        public static Entities.UserRole GetUserRoleByID(int ID)
        {
            return (UserRole_DL != null)
                   ? UserRole_DL.GetUserRoleByID(ID)
                   : null;
        }

        public static bool AddUserRole(Entities.UserRole UserRole)
        {
            return (UserRole_DL != null)
                   ? UserRole_DL.AddUserRole(UserRole)
                   : false;
        }

        public static bool UpdateUserRole(Entities.UserRole UserRole)
        {
            return (UserRole_DL != null)
                   ? UserRole_DL.UpdateUserRole(UserRole)
                   : false;
        }

        public static bool DeleteUserRole(Entities.UserRole UserRole)
        {
            return (UserRole_DL != null)
                   ? UserRole_DL.DeleteUserRole(UserRole)
                   : false;
        }
    }

   
}
