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
        public Vehicule Vehicule { get; set; }
        public bool Status { get; set; }

        #endregion

    }
}
