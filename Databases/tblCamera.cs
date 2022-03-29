using iAccess.Objects.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblCamera
    {
        #region:Properties
        public static string TBL_Name = "tblCamera";
        public static string TBL_COL_ID = "ID";
        public static string TBL_COL_SortOrder = "SortOrder";
        public static string TBL_COL_Name = "Name";
        public static string TBL_COL_Code = "Code";
        public static string TBL_COL_Description = "Description";
        public static string TBL_COL_IP = "IP";
        public static string TBL_COL_Port = "Port";
        public static string TBL_COL_server_Port = "server_Port";
        public static string TBL_COL_Username = "Username";
        public static string TBL_COL_Password = "Password";
        public static string TBL_COL_Channel = "Channel";
        public static string TBL_COL_CameraTypeID = "CameraTypeID";
        public static string TBL_COL_StreamTypeID = "StreamTypeID";
        public static string TBL_COL_ResolutionID = "ResolutionID";
        public static string TBL_COL_SDK_ID = "SDK_ID";
        public static string TBL_COL_Inuse = "Inuse";
        #endregion: End Properties
        //Get
        public static string GetCMD = $@"Select {TBL_COL_ID},{TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description},
                                                {TBL_COL_IP},{TBL_COL_Port},{TBL_COL_server_Port},{TBL_COL_Username},
                                                {TBL_COL_Password},{TBL_COL_Channel},{TBL_COL_CameraTypeID},{TBL_COL_StreamTypeID},
                                                {TBL_COL_ResolutionID},{TBL_COL_SDK_ID},{TBL_COL_Inuse}
                               from {TBL_Name} order by {TBL_COL_SortOrder}";
        public static CameraCollection LoadDataCamera(CameraCollection cameras)
        {
            DataTable dtCamera = Staticpool.mdb.FillData(GetCMD);
            cameras.Clear();
            if (dtCamera != null)
            {
                if (dtCamera.Rows.Count > 0)
                {
                    foreach (DataRow row in dtCamera.Rows)
                    {
                      Camera camera = new Camera()
                        {
                            ID = row[TBL_COL_ID].ToString(),
                            Name = row[TBL_COL_Name].ToString(),
                            Code = row[TBL_COL_Code].ToString(),
                            Description = row[TBL_COL_Description].ToString(),
                            IP = row[TBL_COL_IP].ToString(),
                            Port = Convert.ToInt32(row[TBL_COL_Port].ToString()),
                            ServerPort = Convert.ToInt32(row[TBL_COL_server_Port].ToString()),
                            Username = row[TBL_COL_Username].ToString(),
                            Password = row[TBL_COL_Password].ToString(),
                            Channel = Convert.ToInt32(row[TBL_COL_Channel].ToString()),
                            CameraType = (Enums.EM_CameraType)Convert.ToInt32(row[TBL_COL_CameraTypeID].ToString()),
                            StreamType = (Enums.EM_StreamType)Convert.ToInt32(row[TBL_COL_StreamTypeID].ToString()),
                            Resolution = (Enums.EM_Resolution)Convert.ToInt32(row[TBL_COL_ResolutionID].ToString()),
                            SDK = (Enums.EM_SDK)Convert.ToInt32(row[TBL_COL_SDK_ID].ToString()),
                            isInUse = Convert.ToBoolean(Convert.ToInt32( row[TBL_COL_Inuse].ToString())),

                        };
                        cameras.Add(camera);
                    }
                    dtCamera.Dispose();
                    return cameras;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(Camera camera)
        {
            int inUse = camera.isInUse == true ? 1 : 0;
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_Name}({TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description},{TBL_COL_IP},
                                  {TBL_COL_Port},{TBL_COL_server_Port},{TBL_COL_Username},{TBL_COL_Password},{TBL_COL_Channel},{TBL_COL_CameraTypeID},
                                  {TBL_COL_StreamTypeID},{TBL_COL_ResolutionID},{TBL_COL_SDK_ID},{TBL_COL_Inuse})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{camera.Name}', N'{camera.Code}', N'{camera.Description}', '{camera.IP}',
                                           {camera.Port}, {camera.ServerPort}, '{camera.Username}', '{camera.Password}',{camera.Channel} ,{(int)camera.CameraType},
                                           {(int)camera.StreamType}, {(int)camera.Resolution}, {(int)camera.SDK},{inUse})
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
        public static bool Modify(Camera camera, string ID)
        {
            int isInUse = camera.isInUse == true ? 1 : 0;
            string updateCMD = $@"Update {TBL_Name} set 
                                  {TBL_COL_Name} = N'{camera.Name}',
                                  {TBL_COL_Code} = N'{camera.Code}',
                                  {TBL_COL_Description} = N'{camera.Description}',
                                  {TBL_COL_IP} = '{camera.IP}',
                                  {TBL_COL_Port} = {camera.Port},
                                  {TBL_COL_server_Port} = {camera.ServerPort},
                                  {TBL_COL_Username} = '{camera.Username}',
                                  {TBL_COL_Password} = '{camera.Password}',
                                  {TBL_COL_Channel} = {camera.Channel},
                                  {TBL_COL_CameraTypeID} = '{(int)camera.CameraType}',
                                  {TBL_COL_StreamTypeID} = '{(int)camera.StreamType}',
                                  {TBL_COL_ResolutionID} = '{(int)camera.Resolution}',
                                  {TBL_COL_SDK_ID} = '{(int)camera.SDK}',
                                  {TBL_COL_Inuse} = {isInUse}
                                  Where {TBL_COL_ID} ='{ID}'
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
        public static bool Delete(string cameraID)
        {
            if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_Name} where {TBL_COL_ID}='{cameraID}'"))
            {
                if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_Name} where {TBL_COL_ID}='{cameraID}'"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
