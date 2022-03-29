using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Customers.Cards
{
    public class CardPrivilegeCollection : CollectionBase
    {
        // Constructor
        public CardPrivilegeCollection()
        {

        }

        public CardPrivilege this[int index]
        {
            get { return (CardPrivilege)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public CardPrivilege GetCardPrivilegeByID(string cardPrivilegeID)
        {
            foreach (CardPrivilege cardPrivilege in InnerList)
            {
                if (cardPrivilege.ID == cardPrivilegeID)
                {
                    return cardPrivilege;
                }
            }
            return null;
        }
        public string GetCardPrivilegeIDByName(string cardPrivilegeName)
        {
            foreach (CardPrivilege cardPrivilege in InnerList)
            {
                if (cardPrivilege.Name == cardPrivilegeName)
                {
                    return cardPrivilege.ID;
                }
            }
            return "";
        }

        // Add
        public void Add(CardPrivilege cardPrivilege)
        {
            InnerList.Add(cardPrivilege);
        }

        // Remove
        public void Remove(CardPrivilege cardPrivilege)
        {
            InnerList.Remove(cardPrivilege);
        }

    }
}