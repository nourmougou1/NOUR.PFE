using NOUR.PFE.Entities;
using NOUR.PFE.Repository;
using System;

namespace NOUR.PFE.WEB.Models
{
    public class RequestViewModel
    {
        public Entities.Request Request { get; set; }
        public Entities.Requests Requests { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime MissionDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string MissionAddress { get; set; }
        public Entities.User User { get; set; }
        public Entities.Vehicule Vehicule { get; set; }
        public bool Status { get; set; }
    }
}
