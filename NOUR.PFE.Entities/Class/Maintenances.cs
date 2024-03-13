using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class Maintenances : List<Maintenance>
    {
        public Maintenances(IEnumerable<Maintenances> enumerable) : base() { }
        public Maintenances(int capacity) : base(capacity) { }
        public Maintenances (IEnumerable<Maintenance> list) : base(list) { }
       
       
    }
}
