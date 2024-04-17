using NOUR.PFE.Entities;

namespace NOUR.PFE.WEB.Models
{
    public class MaintenanceTypeViewModel
    {
        public MaintenanceType MaintenanceType {  get; set; }
        public MaintenanceTypes MaintenanceTypes { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
