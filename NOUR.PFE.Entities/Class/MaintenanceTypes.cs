using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class MaintenanceTypes : List<Maintenance>
    {
        public MaintenanceTypes(IEnumerable<MaintenanceTypes> enumerable) : base() { }
        public MaintenanceTypes(int capacity) : base(capacity) { }
        public MaintenanceTypes(IEnumerable<Maintenance> list) : base(list) { }
       
    }
}
