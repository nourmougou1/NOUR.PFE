using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class VehiculePath
    {
        #region Construstors
        public VehiculePath() { }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public Vehicule Vehicule { get; set; }

        #endregion

    }
}
