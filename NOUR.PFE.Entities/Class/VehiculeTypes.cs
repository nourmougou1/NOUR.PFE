using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class VehiculeTypes : List<VehiculeType>
    {
        public VehiculeTypes() : base() { }
        public VehiculeTypes(int capacity) : base(capacity) { }
        public VehiculeTypes(IEnumerable<VehiculeType>collection) : base(collection) { }

    }
}
