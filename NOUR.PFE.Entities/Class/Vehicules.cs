using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class Vehicules : List<Vehicule>
    {
        public Vehicules() : base() { }
        public Vehicules(int capacity) : base(capacity) { }
        public Vehicules(IEnumerable<Vehicule>collection) : base(collection) { }

    }
}
