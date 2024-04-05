using NOUR.PFE.Entities;

namespace NOUR.PFE.WEB.Models
{
    public class UserRoleViewModel
    {
        public UserRoles UserRoles { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
