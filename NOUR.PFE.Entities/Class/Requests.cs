using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities
{
    public class Requests : List<Request>
    {
        public Requests(IEnumerable<Requests> enumerable) : base() { }
        public Requests(int capacity) : base(capacity) { }
        public Requests(IEnumerable<Request> collection) : base(collection) { }

    }
}
