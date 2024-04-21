using NOUR.PFE.Entities;

namespace NOUR.PFE.WEB.Models
{
    public class MaintenanceTypeViewModel
    {
        public MaintenanceType MaintenanceType {  get; set; }
        public MaintenanceTypes MaintenanceTypes { get; set; }
        public int maintenanceTypeId { get; set; }
        public string maintenanceTypeName { get; set; }
        public string description { get; set; }
    }
}
