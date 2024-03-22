using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.DataLayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Repository
{
    public static class Config
    {
        private static IConfig Config_DL;

        static Config()
        {
            Config_DL = new ConfigDB();
        }
        public static Entities.UserRoles GetUserRoles()
        {
            return (Config_DL != null)
                 ? new Entities.UserRoles(Config_DL.GetUserRoles())
                 : null;

        }
        public static Entities.UserRole GetUserRoleByCode(string code)
        {
            return (Config_DL != null)
                   ? Config_DL.GetUserRoleByCode(code)
                   : null;
        }

        public static Entities.UserRole GetUserRoleByID(int ID)
        {
            return (Config_DL != null)
                   ? Config_DL.GetUserRoleByID(ID)
                   : null;
        }

        public static bool AddUserRole(Entities.UserRole UserRole)
        {
            return (Config_DL != null)
                   ? Config_DL.AddUserRole(UserRole)
                   : false;
        }

        public static bool UpdateUserRole(Entities.UserRole UserRole)
        {
            return (Config_DL != null)
                   ? Config_DL.UpdateUserRole(UserRole)
                   : false;
        }

        public static bool DeleteUserRole(Entities.UserRole UserRole)
        {
            return (Config_DL != null)
                   ? Config_DL.DeleteUserRole(UserRole)
                   : false;
        }

    }
}
