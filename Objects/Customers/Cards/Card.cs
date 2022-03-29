using iAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KztekObject.Cards.CardFactory;

namespace iAccess.Objects.Cards
{
    public class Card
    {
        public string ID { get; set; }
        public int SortOrder { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CardNumber { get; set; }
        public string CardCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public EM_CardType CardType { get; set; }
        public string CardGroupID { get; set; }
        public string CardPrivilegeID { get; set; }
        public bool isInUse { get; set; }
    }
}
