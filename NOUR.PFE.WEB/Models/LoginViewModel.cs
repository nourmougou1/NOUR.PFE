using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NOUR.PFE.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

    }
}
