using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities

{
    public class ApiUsers : List<ApiUser>
    {
        public ApiUsers() : base() { }
        public ApiUsers(int capacity) : base(capacity) { }
        public ApiUsers(IEnumerable<ApiUser> collection) : base(collection) { }

    }

}

