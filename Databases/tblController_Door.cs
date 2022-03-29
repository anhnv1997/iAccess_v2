using iAccess.Objects.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblController_Door
    {
        public const string TBL_NAME = "tbl_Controller_Door";
        public const string TBL_COL_ID = "ID";
        public const string TBL_COL_Name = "Name";
        public const string TBL_COL_Code = "Code";
        public const string TBL_COL_Description = "Description";
        public const string TBL_COL_ControllerID = "ControllerID";
        public const string TBL_COL_DoorID = "DoorID";
        public const string TBL_COL_ReaderIndex = "ReaderIndex";

        //Get
        static string GetCMD = $@"SELECT 
                                  {TBL_COL_ID}, {TBL_COL_Name}, {TBL_COL_Code}, {TBL_COL_Description},                            
                                  {TBL_COL_ControllerID}, {TBL_COL_DoorID}, {TBL_COL_ReaderIndex}
                                  FROM {TBL_NAME}";
        public static Controller_Door_DetailCollection LoadDataController_Door(Controller_Door_DetailCollection Controller_Doors)
        {
            Controller_Doors.Clear();
            DataTable dtController_Door = Staticpool.mdb.FillData(GetCMD);
            if (dtController_Door != null)
            {
                if (dtController_Door.Rows.Count > 0)
                {
                    foreach (DataRow row in dtController_Door.Rows)
                    {
                        Controller_Door_Detail Controller_door = new Controller_Door_Detail()
                        {
                            ID = row[TBL_COL_ID].ToString(),
                            Name = row[TBL_COL_Name].ToString(),
                            Code = row[TBL_COL_Code].ToString(),
                            Description = row[TBL_COL_Description].ToString(),
                            ControllerID = row[TBL_COL_ControllerID].ToString(),
                            DoorID = row[TBL_COL_DoorID].ToString(),
                            ReaderIndex = Convert.ToInt32(row[TBL_COL_ReaderIndex].ToString())
                        };
                        Controller_Doors.Add(Controller_door);
                    }
                    return Controller_Doors;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(Controller_Door_Detail controller_Door_Detail)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description},{TBL_COL_ControllerID},{TBL_COL_DoorID},{TBL_COL_ReaderIndex})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{controller_Door_Detail.Name}',N'{controller_Door_Detail.Code}',N'{controller_Door_Detail.Description}','{controller_Door_Detail.ControllerID}', '{controller_Door_Detail.DoorID}', {controller_Door_Detail.ReaderIndex})
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
        public static bool Modify(string name, string code, string description, string ControllerID, string doorID, int readerIndex, string ID)
        {
            string updateCMD = $@"Update {TBL_NAME} set 
                                  {TBL_COL_Name} = N'{name}',
                                  {TBL_COL_Code} = N'{code}',
                                  {TBL_COL_Description} = N'{description}',
                                  {TBL_COL_DoorID} = '{doorID}',
                                  {TBL_COL_ControllerID} = '{ControllerID}',
                                  {TBL_COL_ReaderIndex} = {readerIndex}
                                  Where {TBL_COL_ID} = '{ID}'
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
        public static bool Delete(string ControllerID, string doorID, int readerIndex )
        {
            string deleteCMD = $@"Delete {TBL_NAME} 
                                  Where {TBL_COL_DoorID}='{doorID}' 
                                        AND {TBL_COL_ControllerID}='{ControllerID}' 
                                        AND {TBL_COL_ReaderIndex} = {readerIndex}
                                 ";
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
