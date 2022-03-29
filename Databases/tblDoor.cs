using iAccess.Objects;
using iAccess.Objects.Customers.Cards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblDoor
    {
        public const string TBL_NAME = "tblDoor";
        public const string TBL_COL_ID = "ID";
        public const string TBL_COL_Name = "Name";
        public const string TBL_COL_Code = "Code";
        public const string TBL_COL_Description = "Description";
        public const string TBL_COL_SortOrder = "SortOrder";

        public static string GetCMD = $@"Select {TBL_COL_ID},{TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description} from {TBL_NAME} order by {TBL_COL_SortOrder}";
        //Get
        public static DoorCollection LoadDataDoor(DoorCollection Doors)
        {
            Doors.Clear();
            DataTable dtDoor = Staticpool.mdb.FillData(GetCMD);
            if (dtDoor != null)
            {
                if (dtDoor.Rows.Count > 0)
                {
                    foreach (DataRow row in dtDoor.Rows)
                    {
                        Door Door = new Door()
                        {
                            ID = row[TBL_COL_ID].ToString(),
                            Name = row[TBL_COL_Name].ToString(),
                            Code = row[TBL_COL_Code].ToString(),
                            Description = row[TBL_COL_Description].ToString(),
                        };
                        Doors.Add(Door);
                    }
                    return Doors;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(Door door)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{door.Name}',N'{door.Code}',N'{door.Description}')
                                  Select * from @generated_keys";

            DataTable dtbLastID = Staticpool.mdb.FillData(insertCMD);
            if ((dtbLastID == null))
            {
                dtbLastID = Staticpool.mdb.FillData(insertCMD);
                if ((dtbLastID == null))
                {
                    return "";
                }
            }
            return dtbLastID.Rows[0][TBL_COL_ID].ToString();
        }
        //Modify
        public static bool Modify(Door door, string ID)
        {
            string updateCMD = $@"UPDATE {TBL_NAME} SET 
                                  {TBL_COL_Name} = N'{door.Name}',
                                  {TBL_COL_Code} = N'{door.Code}',
                                  {TBL_COL_Description} = N'{door.Description}'
                                  WHERE {TBL_COL_ID} = '{ID}'
                                 ";
            if (!Staticpool.mdb.ExecuteCommand(updateCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(updateCMD))
                {
                    return false;
                }
            }
            return true;
        }
        //Delete
        public static bool Delete(string doorID)
        {
            string deleteCMD = $@"Delete {TBL_NAME} Where {TBL_COL_ID}='{doorID}'";
            if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
