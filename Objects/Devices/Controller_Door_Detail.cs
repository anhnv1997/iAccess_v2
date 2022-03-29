﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Devices
{
    public class Controller_Door_Detail
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ControllerID { get; set; }
        public string DoorID { get; set; }
        public int ReaderIndex { get; set; }
    }
}
