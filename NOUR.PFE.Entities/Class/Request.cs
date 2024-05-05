using NOUR.PFE.Entities.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class Request
    {
        #region Constructors
        public Request() { }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime MissionDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string MissionAddress { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public RequestStatus status { get; set; }
        public RequestStatuses statuss { get; set; }
        public VehiculeType VehiculeType { get; set; }
        public int VehiculeTypeId { get; set; }
        public string VehiculeTypeName { get; set; }
        public VehiculeTypes VehiculeTypes { get; set; }
        public Vehicule Vehicule { get; set; }
        public int vehiculeId { get; set; }

        #endregion

    }
}
