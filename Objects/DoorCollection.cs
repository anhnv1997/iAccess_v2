using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects
{
    public class DoorCollection : CollectionBase
    {
        // Constructor
        public DoorCollection()
        {

        }

        public Door this[int index]
        {
            get { return (Door)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public Door GetDoorByID(string doorID)
        {
            foreach (Door door in InnerList)
            {
                if (door.ID == doorID)
                {
                    return door;
                }
            }
            return null;
        }

        // Add
        public void Add(Door door)
        {
            InnerList.Add(door);
        }

        // Remove
        public void Remove(Door door)
        {
            InnerList.Remove(door);
        }

    }
}