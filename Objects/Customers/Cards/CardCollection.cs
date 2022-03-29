using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Cards
{
    public class CardCollection : CollectionBase
    {
        // Constructor
        public CardCollection()
        {

        }

        public Card this[int index]
        {
            get { return (Card)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public Card GetCardByID(string cardID)
        {
            foreach (Card card in InnerList)
            {
                if (card.ID == cardID)
                {
                    return card;
                }
            }
            return null;
        }

        // Add
        public void Add(Card ccu)
        {
            InnerList.Add(ccu);
        }

        // Remove
        public void Remove(Card ccu)
        {
            InnerList.Remove(ccu);
        }

    }
}