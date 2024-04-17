using NOUR.PFE.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NOUR.PFE.WEB.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public Users Users { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "please complete this field"), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "please complete this field"), MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "please complete this field"), MaxLength(50)]
        public string Login { get; set; }

        [Required(ErrorMessage = "please complete this field"), MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "please complete this field"), MaxLength(50)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "please complete this field"), MaxLength(50)]
        public string UserPhone { get; set; }

        public UserRole UserRole { get; set; }

        public int UserRoleId { get; set; }
        public string Image { get; set; }

        public DateTime CreationDate { get; set; }
 
        public DateTime Birthday { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
