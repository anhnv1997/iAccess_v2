using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Customers.Cards
{
    public class CardPrivilege
    {
        public string ID { get; set; }
        public int SortOrder { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<string> ControllerDoorIDs { get; set; } = new List<string>();
        public string TimezoneID { get; set; }
    }
}
