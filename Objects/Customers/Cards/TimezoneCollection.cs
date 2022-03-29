using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Customers.Cards
{
    public class TimezoneCollection : CollectionBase
    {
        // Constructor
        public TimezoneCollection()
        {

        }

        public AccessTimezone this[int index]
        {
            get { return (AccessTimezone)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public AccessTimezone GetTimezoneByID(string timezoneID)
        {
            foreach (AccessTimezone timezone in InnerList)
            {
                if (timezone.ID == timezoneID)
                {
                    return timezone;
                }
            }
            return null;
        }
        public string GetTimezoneByName(string timezoneName)
        {
            foreach (AccessTimezone timezone in InnerList)
            {
                if (timezone.Name == timezoneName)
                {
                    return timezone.ID;
                }
            }
            return "";
        }

        // Add
        public void Add(AccessTimezone timezone)
        {
            InnerList.Add(timezone);
        }

        // Remove
        public void Remove(AccessTimezone timezonee)
        {
            InnerList.Remove(timezonee);
        }

    }
}