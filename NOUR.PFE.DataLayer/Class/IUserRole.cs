﻿using System;
using System.Collections.Generic;

namespace NOUR.PFE.DataLayer.Class
{
    public interface IUserRole
    {
        IEnumerable<Entities.UserRole> GetUserRoles();
        Entities.UserRole GetUserRoleByCode(string code);
        Entities.UserRole GetUserRoleByID(int ID);

        bool AddUserRole(Entities.UserRole UserRole);
        bool UpdateUserRole(Entities.UserRole UserRole);
        bool DeleteUserRole(Entities.UserRole UserRole);
    }
}
