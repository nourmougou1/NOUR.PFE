using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class VehiculeDocument
    {
        #region Constructors

        public VehiculeDocument() { }

        #endregion

        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public Vehicule Vehicule { get; set; }

        #endregion
    }
}
