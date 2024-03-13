using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class VehiculeDocuments : List<VehiculeDocument>
    {
        public VehiculeDocuments():base() { }
        public VehiculeDocuments(int capacity) : base(capacity) { }
        public VehiculeDocuments(IEnumerable<VehiculeDocument> collection) : base(collection) { }
        
    }
}
