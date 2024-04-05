using NOUR.PFE.Entities;
using System;

namespace NOUR.PFE.WEB.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public Users Users { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string UserPhone { get; set; }
        public UserRole UserRole { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Birthday { get; set; }
    }
}
