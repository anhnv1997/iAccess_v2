using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Customers.Cards
{
    public class AccessTimezone
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime StartMON { get; set; }
        public DateTime EndMON { get; set; }
        public DateTime StartTUE { get; set; }
        public DateTime EndTUE { get; set; }
        public DateTime StartWED { get; set; }
        public DateTime EndWED { get; set; }
        public DateTime StartTHU { get; set; }
        public DateTime EndTHU { get; set; }
        public DateTime StartFRI { get; set; }
        public DateTime EndFRI { get; set; }
        public DateTime StartSAT { get; set; }
        public DateTime EndSAT { get; set; }
        public DateTime StartSUN { get; set; }
        public DateTime EndSUN { get; set; }
        public bool IsInUse { get; set; }
    }
}
