using iAccess.Objects.Cards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Customers
{
    public class CustomerCollection : CollectionBase
    {
        // Constructor
        public CustomerCollection()
        {

        }

        public Customer this[int index]
        {
            get { return (Customer)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public Customer GetCustomerByID(string customerID)
        {
            foreach (Customer Customer in InnerList)
            {
                if (Customer.ID == customerID)
                {
                    return Customer;
                }
            }
            return null;
        }

        public Customer GetCustomerByCardNumber(string cardNumber)
        {
            foreach (Customer customer in InnerList)
            {
                Card mainCard = customer.MainCardID == "" ? null : Staticpool.Cards.GetCardByID(customer.MainCardID);
                Card secondaryCard = customer.SecondaryCardID == "" ? null : Staticpool.Cards.GetCardByID(customer.SecondaryCardID);
                if (mainCard != null)
                {
                    if (mainCard.CardNumber == cardNumber)
                    {
                        return customer;
                    }
                }
                if (secondaryCard != null)
                {
                    if (secondaryCard.CardNumber == cardNumber)
                    {
                        return customer;
                    }
                }
            }
            return null;
        }

        // Add
        public void Add(Customer customer)
        {
            InnerList.Add(customer);
        }

        // Remove
        public void Remove(Customer customer)
        {
            InnerList.Remove(customer);
        }

    }
}