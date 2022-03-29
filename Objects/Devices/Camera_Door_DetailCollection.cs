using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Devices
{
    public class Camera_Door_DetailCollection : CollectionBase
    {
        // Constructor
        public Camera_Door_DetailCollection()
        {

        }

        public Camera_Door_Detail this[int index]
        {
            get { return (Camera_Door_Detail)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public Camera_Door_Detail GetCardPrivilegeByID(string camera_Door_DetailID)
        {
            foreach (Camera_Door_Detail camera_Door_Detail in InnerList)
            {
                if (camera_Door_Detail.ID == camera_Door_DetailID)
                {
                    return camera_Door_Detail;
                }
            }
            return null;
        }

        // Add
        public void Add(Camera_Door_Detail camera_Door_Detail)
        {
            InnerList.Add(camera_Door_Detail);
        }

        // Remove
        public void Remove(Camera_Door_Detail camera_Door_Detail)
        {
            InnerList.Remove(camera_Door_Detail);
        }

    }
}