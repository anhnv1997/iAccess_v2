using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblEvent
    {
        public const string TBL_NAME     = "tblEvent";
        public const string COL_ID = "ID";
        public const string COL_TIME = "Time";
        public const string COL_EVENT_TYPE = "EventType";
        public const string COL_EVENT_STATUS = "EventStatus";
        public const string COL_DEVICE_ID = "DeviceID";
        public const string COL_DEVICE_TYPE = "DeviceType";
        public const string COL_CARDNUMBER = "CardNumber";

        //Add
        public static string InsertAndGetLastID(DateTime time, int eventType, int eventStatus,string deviceID, int deviceType,string cardNumber)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}(
                                  {COL_TIME},{COL_EVENT_TYPE},{COL_EVENT_STATUS},
                                  {COL_DEVICE_ID},{COL_DEVICE_TYPE},{COL_CARDNUMBER}
                                  )
                                  OUTPUT inserted.{COL_DEVICE_ID} 
                                  Into @generated_keys
                                  values(
                                  '{time}',{eventType},{eventStatus},
                                  '{deviceID}',{deviceType},'{cardNumber}' 
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
            return dtbLastID.Rows[0][COL_ID].ToString();
        }
    }
}
