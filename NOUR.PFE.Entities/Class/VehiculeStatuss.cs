using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class VehiculeStatuss  : List<VehiculeStatus>
    {
        public VehiculeStatuss() : base() { }
        public VehiculeStatuss(int capacity) : base(capacity) { }
        public VehiculeStatuss(IEnumerable<VehiculeStatus> collection) : base(collection) { }
    }

}
