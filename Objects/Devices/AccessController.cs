using iAccess.Enums;
using KztekObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KztekObject.ControllerType;
using static KztekObject.enums.CommunicationType;

namespace iAccess.Objects.Devices
{
    public class AccessController
    {
        public string ID { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public string Description { get; set; } = "";
        public EM_ControllerType ControllerType { get; set; }
        public EM_CommunicationType CommunicationType { get; set; }
        public string ControllerGroupID { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isInUse { get; set; }
        public EM_DisplayMode DisplayMode { get; set; }
        public int ReaderCount { get; set; }

    }
}
