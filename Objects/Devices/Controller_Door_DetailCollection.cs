using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Devices
{
    public class Controller_Door_DetailCollection : CollectionBase
    {
        // Constructor
        public Controller_Door_DetailCollection()
        {

        }

        public Controller_Door_Detail this[int index]
        {
            get { return (Controller_Door_Detail)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public Controller_Door_Detail GetControllerDoorByID(string controller_Door_DetailID)
        {
            foreach (Controller_Door_Detail controller_Door_Detail in InnerList)
            {
                if (controller_Door_Detail.ID == controller_Door_DetailID)
                {
                    return controller_Door_Detail;
                }
            }
            return null;
        }

        // Add
        public void Add(Controller_Door_Detail controller_Door_Detail)
        {
            InnerList.Add(controller_Door_Detail);
        }

        // Remove
        public void Remove(Controller_Door_Detail controller_Door_Detail)
        {
            InnerList.Remove(controller_Door_Detail);
        }

    }
}