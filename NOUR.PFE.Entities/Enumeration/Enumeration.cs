using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities.Enumeration
{
    public static class Enumeration
    {
        public enum Langue
        {
            AR = 1,
            FR,
            EN
        }

        public enum UserRole
        {
            ADMIN = 1,
            USER,
            RESPO
        }
    }
}
