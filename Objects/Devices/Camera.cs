using iAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Devices
{
    public class Camera
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public int ServerPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Channel { get; set; }
        public EM_CameraType CameraType { get; set; }
        public EM_StreamType StreamType { get; set; }
        public EM_Resolution Resolution { get; set; }
        public EM_SDK SDK { get; set; }
        public bool isInUse { get; set; }
    }
}
