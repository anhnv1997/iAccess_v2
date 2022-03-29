using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Devices
{
    public class CameraCollection : CollectionBase
    {
        // Constructor
        public CameraCollection()
        {

        }

        public Camera this[int index]
        {
            get { return (Camera)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public Camera GetCameraByID(string cameraID)
        {
            foreach (Camera camera in InnerList)
            {
                if (camera.ID == cameraID)
                {
                    return camera;
                }
            }
            return null;
        }

        // Add
        public void Add(Camera camera)
        {
            InnerList.Add(camera);
        }

        // Remove
        public void Remove(Camera camera)
        {
            InnerList.Remove(camera);
        }

    }
}