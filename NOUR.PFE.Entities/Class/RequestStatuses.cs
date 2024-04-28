using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities.Class
{
    public class RequestStatuses : List<RequestStatus>
    {
        public RequestStatuses() : base() { }
        public RequestStatuses(int capacity) : base(capacity) { }
        public RequestStatuses(IEnumerable<RequestStatus> collection) : base(collection) { }
    }
}
