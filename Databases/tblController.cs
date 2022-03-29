using iAccess.Enums;
using iAccess.Objects.Devices;
using KztekObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KztekObject.ControllerType;
using static KztekObject.enums.CommunicationType;

namespace iAccess.Databases
{
    public class tblController
    {
        public const string TBL_NAME = "tblController";
        public const string TBL_COL_ID = "ID";
        public const string TBL_COL_SortOrder = "SortOrder";
        public const string TBL_COL_Name = "Name";
        public const string TBL_COL_Code = "Code";
        public const string TBL_COL_ControllerTypeID = "ControllerTypeID";
        public const string TBL_COL_CommunicationTypeID = "CommunicationTypeID";
        public const string TBL_COL_ControllerGroupID = "ControllerGroupID";
        public const string TBL_COL_IP = "IP";
        public const string TBL_COL_Port = "Port";
        public const string TBL_COL_Username = "Username";
        public const string TBL_COL_Password = "Password";
        public const string TBL_COL_InUse = "InUse";
        public const string TBL_COL_DisplayMode = "DisplayMode"; 
        public const string TBL_COL_ReaderCount = "ReaderCount"; 

        public static string GetCMD = $@"SELECT {TBL_COL_ID}, {TBL_COL_Name}, {TBL_COL_Code}, {TBL_COL_ControllerTypeID},
                                        {TBL_COL_CommunicationTypeID}, {TBL_COL_ControllerGroupID}, {TBL_COL_IP}, {TBL_COL_Port},
                                        {TBL_COL_Username}, {TBL_COL_Password}, 
                                        {TBL_COL_InUse}, {TBL_COL_DisplayMode},{TBL_COL_ReaderCount}
                                        FROM {TBL_NAME}
                                        ORDER BY {TBL_COL_SortOrder}";
        //Get
        public static AccessControllerCollection LoadDataController(AccessControllerCollection controllers)
        {
            controllers.Clear();
            DataTable dtController = Staticpool.mdb.FillData(GetCMD);
            if (dtController != null)
            {
                if (dtController.Rows.Count > 0)
                {
                    foreach (DataRow row in dtController.Rows)
                    {
                        AccessController controller = new AccessController();
                        controller.ID = row[TBL_COL_ID].ToString();
                        controller.Name = row[TBL_COL_Name].ToString();
                        controller.Code = row[TBL_COL_Code].ToString();
                        controller.ControllerType = (EM_ControllerType)Convert.ToInt32(row[TBL_COL_ControllerTypeID].ToString());
                        controller.CommunicationType = (EM_CommunicationType)Convert.ToInt32(row[TBL_COL_CommunicationTypeID].ToString());
                        controller.ControllerGroupID = row[TBL_COL_ControllerGroupID].ToString();
                        controller.IP = row[TBL_COL_IP].ToString();
                        controller.Port = Convert.ToInt32(row[TBL_COL_Port].ToString());
                        controller.Username = row[TBL_COL_Username].ToString();
                        controller.Password = row[TBL_COL_Password].ToString();
                        controller.isInUse = Convert.ToBoolean(row[TBL_COL_InUse].ToString());
                        controller.DisplayMode = (EM_DisplayMode)Convert.ToInt32(row[TBL_COL_DisplayMode].ToString());
                        controller.ReaderCount = Convert.ToInt32(row[TBL_COL_ReaderCount].ToString());
                        controllers.Add(controller);
                    }
                    return controllers;
                }
            }
            return null;
        }
        //ADD
        public static string InsertAndGetLastID(AccessController controller)
        {
            int inUse = controller.isInUse == true ? 1 : 0;
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}
                                       ({TBL_COL_Name}, {TBL_COL_Code}, {TBL_COL_ControllerTypeID},
                                        {TBL_COL_CommunicationTypeID}, {TBL_COL_ControllerGroupID}, 
                                        {TBL_COL_IP}, {TBL_COL_Port},
                                        {TBL_COL_Username}, {TBL_COL_Password}, 
                                        {TBL_COL_InUse}, {TBL_COL_DisplayMode},{TBL_COL_ReaderCount})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{controller.Name}',N'{controller.Code}', {(int)controller.ControllerType},
                                           {(int)controller.CommunicationType}, '{controller.ControllerGroupID}',
                                          '{controller.IP}', {controller.Port},
                                          '{controller.Username}', '{controller.Password}',
                                           {inUse}, {(int)controller.DisplayMode}, {controller.ReaderCount}
            
                                  )
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
        //MODIFY
        public static bool Modify(AccessController controller, string ID)
        {
            int inUse = controller.isInUse == true ? 1 : 0;
            string updateCMD = $@"UPDATE {TBL_NAME} SET
                                  {TBL_COL_Name} = N'{controller.Name}',
                                  {TBL_COL_Code} = N'{controller.Code}',
                                  {TBL_COL_ControllerTypeID} = {(int)controller.ControllerType},
                                  {TBL_COL_CommunicationTypeID} = {(int)controller.CommunicationType},
                                  {TBL_COL_ControllerGroupID} = '{controller.ControllerGroupID}',
                                  {TBL_COL_IP} = '{controller.IP}',
                                  {TBL_COL_Port} = {controller.Port},
                                  {TBL_COL_Username} = '{controller.Username}',
                                  {TBL_COL_Password} = '{controller.Password}',
                                  {TBL_COL_InUse} =  {inUse},
                                  {TBL_COL_DisplayMode} = {(int)controller.DisplayMode},
                                  {TBL_COL_ReaderCount} = {(int)controller.ReaderCount}
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
        //DELETE
        public static bool Delete(string controllerID)
        {
            if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{controllerID}'"))
            {
                if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{controllerID}'"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
