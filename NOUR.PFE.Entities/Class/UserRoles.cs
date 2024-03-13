using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class UserRoles : List<UserRole>
    {
        public UserRoles() : base() { }
        public UserRoles(int capacity) : base(capacity) { }
        public UserRoles(IEnumerable<UserRole> collection) : base(collection) { }

        #region Methods   

        public string Test()
        {
            try
            {
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        #endregion
    }
}
