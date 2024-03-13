using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class VehiculeBrands : List<VehiculeBrand>
    {
        public VehiculeBrands() : base() { }
        public VehiculeBrands(int capacity) : base(capacity) { }
        public VehiculeBrands(IEnumerable<VehiculeBrand> collection) : base(collection) { }
    }
}
