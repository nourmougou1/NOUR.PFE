using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities.Class
{
    internal class User
    {
        #region Constructeur 
        public User()
        {

        }
        #endregion
        #region Properties
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string UserPhone { get; set; }
        public UserRole UserRode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Birthday { get; set; }
        #endregion

        

    }
}
