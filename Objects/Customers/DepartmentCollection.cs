using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Objects.Customers
{
    public class DepartmentCollection : CollectionBase
    {
        // Constructor
        public DepartmentCollection()
        {

        }

        public Department this[int index]
        {
            get { return (Department)InnerList[index]; }
        }
        // Get ccu by it's ccuID
        public Department GetDepartmentByID(string departmentID)
        {
            foreach (Department department in InnerList)
            {
                if (department.ID == departmentID)
                {
                    return department;
                }
            }
            return null;
        }

        // Add
        public void Add(Department department)
        {
            InnerList.Add(department);
        }

        // Remove
        public void Remove(Department department)
        {
            InnerList.Remove(department);
        }

    }
}