using NOUR.PFE.Entities;
using NOUR.PFE.Entities.Class;
using NOUR.PFE.Repository;
using System;

namespace NOUR.PFE.WEB.Models
{
    public class RequestViewModel
    {
        public Entities.Request Request { get; set; }
        public Entities.Requests Requests { get; set; }
        public int Id { get; set; }
        public Entities.User User { get; set; }
        public Users Users { get; set; }
        public RequestStatus Status { get; set; }
        public RequestStatuses Statuses { get; set; }
        public string Description { get; set; }
        public DateTime MissionDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string MissionAddress { get; set; }
        public int VehiculeTypeId { get; set; }
        public int VehiculeTypeName { get; set; }
        public int VehiculeId { get; set; }
        public Vehicules vehicules { get; set; }
        public VehiculeTypes VehiculeTypes { get; set; }
        public VehiculeType VehiculeType { get; set; }


        public int StatusId { get; set; }
    }
}
