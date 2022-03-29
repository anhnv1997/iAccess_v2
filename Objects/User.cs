﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects
{
    public class User
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SortOrder { get; set; }
        public bool isActive { get; set; }
    }
}
