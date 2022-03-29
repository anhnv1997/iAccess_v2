using iAccess.Objects.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblCamera_Door
    {
        public const string TBL_NAME = "tblCamera_Door";
        public const string TBL_COL_CameraID = "CameraID";
        public const string TBL_COL_DoorID = "DoorID";
        public const string TBL_COL_ID = "ID";

        //Get
        static string GetCMD = $@"Select {TBL_COL_CameraID}, {TBL_COL_DoorID}, {TBL_COL_ID} from {TBL_NAME}";
        public static Camera_Door_DetailCollection LoadDataCamera_Door(Camera_Door_DetailCollection camera_Doors)
        {
            camera_Doors.Clear();
            DataTable dtCamera_Door = Staticpool.mdb.FillData(GetCMD);
            if (dtCamera_Door != null)
            {
                if (dtCamera_Door.Rows.Count > 0)
                {
                    foreach (DataRow row in dtCamera_Door.Rows)
                    {
                        Camera_Door_Detail camera_door = new Camera_Door_Detail()
                        {
                            CameraID = row[TBL_COL_CameraID].ToString(),
                            DoorID = row[TBL_COL_DoorID].ToString(),
                            ID = row[TBL_COL_ID].ToString()
                        };
                        camera_Doors.Add(camera_door);
                    }
                    return camera_Doors;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(Camera_Door_Detail camera_Door_Detail)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_CameraID},{TBL_COL_DoorID})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values('{camera_Door_Detail.CameraID}', '{camera_Door_Detail.DoorID}')
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
        public static bool Modify(string cameraID, string doorID, string ID)
        {
            string updateCMD = $@"Update {TBL_NAME} set {TBL_COL_DoorID}='{doorID}',{TBL_COL_CameraID}='{cameraID}' where {TBL_COL_ID} = '{ID}'";
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
        public static bool Delete(string cameraID, string doorID)
        {
            string deleteCMD = $@"Delete {TBL_NAME} Where {TBL_COL_DoorID}='{doorID}' AND {TBL_COL_CameraID}='{cameraID}'";
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
