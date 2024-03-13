using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class VehiculePaths : List<VehiculePath>
    {
        public VehiculePaths() : base() { }
        public VehiculePaths(int capacity) : base(capacity) { }
        public VehiculePaths(IEnumerable<VehiculePath> collection) : base(collection) { }
       

    }
}
