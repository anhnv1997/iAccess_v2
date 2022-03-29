using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Devices
{
    public class ControllerGroupCollection : CollectionBase
    {
        // Constructor
        public ControllerGroupCollection()
        {

        }

        public ControllerGroup this[int index]
        {
            get { return (ControllerGroup)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public ControllerGroup GetControllerGroupByID(string controllerGroupID)
        {
            foreach (ControllerGroup controllerGroup in InnerList)
            {
                if (controllerGroup.ID == controllerGroupID)
                {
                    return controllerGroup;
                }
            }
            return null;
        }

        // Add
        public void Add(ControllerGroup controllerGroup)
        {
            InnerList.Add(controllerGroup);
        }

        // Remove
        public void Remove(ControllerGroup controllerGroup)
        {
            InnerList.Remove(controllerGroup);
        }

    }
}