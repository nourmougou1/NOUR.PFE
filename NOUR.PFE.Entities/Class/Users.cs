﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities

{
    public class Users : List<User>
    {
        public Users() : base() { }
        public Users(int capacity) : base(capacity) { }
        public Users(IEnumerable<User> collection) : base(collection) { }

    }

}

