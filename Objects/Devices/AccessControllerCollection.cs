using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Devices
{
    public class AccessControllerCollection : CollectionBase
    {
        // Constructor
        public AccessControllerCollection()
        {

        }

        public AccessController this[int index]
        {
            get { return (AccessController)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public AccessController GetControllerByID(string controllerID)
        {
            foreach (AccessController controller in InnerList)
            {
                if (controller.ID == controllerID)
                {
                    return controller;
                }
            }
            return null;
        }

        // Add
        public void Add(AccessController controller)
        {
            InnerList.Add(controller);
        }

        // Remove
        public void Remove(AccessController controller)
        {
            InnerList.Remove(controller);
        }

    }
}