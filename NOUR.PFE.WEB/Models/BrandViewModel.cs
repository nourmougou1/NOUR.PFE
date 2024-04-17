using NOUR.PFE.Entities;

namespace NOUR.PFE.WEB.Models
{
    public class BrandViewModel
    {
        public VehiculeBrand VehiculeBrand { get; set; }
        public VehiculeBrands VehiculeBrands { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
