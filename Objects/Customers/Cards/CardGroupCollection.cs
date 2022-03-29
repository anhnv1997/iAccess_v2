using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Customers.Cards
{
    public class CardGroupCollection : CollectionBase
    {
        // Constructor
        public CardGroupCollection()
        {

        }

        public CardGroup this[int index]
        {
            get { return (CardGroup)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public CardGroup GetCardGroupByID(string cardGroupID)
        {
            foreach (CardGroup cardGroup in InnerList)
            {
                if (cardGroup.ID == cardGroupID)
                {
                    return cardGroup;
                }
            }
            return null;
        }

        public string GetCardGroupIDByName(string cardGroupName)
        {
            foreach (CardGroup cardGroup in InnerList)
            {
                if (cardGroup.Name == cardGroupName)
                {
                    return cardGroup.ID;
                }
            }
            return "";
        }

        // Add
        public void Add(CardGroup cardGroup)
        {
            InnerList.Add(cardGroup);
        }

        // Remove
        public void Remove(CardGroup cardGroup)
        {
            InnerList.Remove(cardGroup);
        }

    }
}