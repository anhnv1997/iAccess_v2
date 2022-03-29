using iAccess.Objects.Customers.Cards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblTimezone
    {
        public const string TBL_NAME = "tblTimezone";
        public const string TBL_COL_ID = "ID";
        public const string TBL_COL_NAME = "Name";
        public const string TBL_COL_CODE = "Code";
        public const string TBL_COL_DESCRIPTION = "Description";
        public const string TBL_COL_SORT_ORDER = "SortOrder";
        public const string TBL_COL_START_MON = "StartMON";
        public const string TBL_COL_END_MON = "EndMON";
        public const string TBL_COL_START_TUE = "StartTUE";
        public const string TBL_COL_END_TUE = "EndTUE";
        public const string TBL_COL_START_WED = "StartWED";
        public const string TBL_COL_END_WED = "EndWED";
        public const string TBL_COL_START_THU = "StartTHU";
        public const string TBL_COL_END_THU = "EndTHU";
        public const string TBL_COL_START_FRI = "StartFRI";
        public const string TBL_COL_END_FRI = "EndFRI";
        public const string TBL_COL_START_SAT = "StartSAT";
        public const string TBL_COL_END_SAT = "EndSAT";
        public const string TBL_COL_START_SUN = "StartSUN";
        public const string TBL_COL_END_SUN = "EndSUN";
        public const string TBL_COL_INUSE = "InUSe";

        public static string GetCMD = $@"Select {TBL_COL_ID},{TBL_COL_NAME},{TBL_COL_CODE},{TBL_COL_DESCRIPTION},
                                                {TBL_COL_START_MON}, {TBL_COL_END_MON},
                                                {TBL_COL_START_TUE}, {TBL_COL_END_TUE},
                                                {TBL_COL_START_WED}, {TBL_COL_END_WED},
                                                {TBL_COL_START_THU}, {TBL_COL_END_THU},
                                                {TBL_COL_START_FRI}, {TBL_COL_END_FRI},
                                                {TBL_COL_START_SAT}, {TBL_COL_END_SAT},
                                                {TBL_COL_START_SUN}, {TBL_COL_END_SUN},
                                                {TBL_COL_INUSE}
                                         from {TBL_NAME} order by {TBL_COL_SORT_ORDER}";
        //Get
        public static TimezoneCollection LoadDataTimezone(TimezoneCollection timezoneCollection)
        {
            timezoneCollection.Clear();
            DataTable dtTimezones = Staticpool.mdb.FillData(GetCMD);
            if (dtTimezones != null)
            {
                if (dtTimezones.Rows.Count > 0)
                {
                    foreach (DataRow row in dtTimezones.Rows)
                    {
                        AccessTimezone timezone = new AccessTimezone()
                        {
                            ID = row[TBL_COL_ID].ToString(),
                            Name = row[TBL_COL_NAME].ToString(),
                            Code = row[TBL_COL_CODE].ToString(),
                            Description = row[TBL_COL_DESCRIPTION].ToString(),
                            StartMON = DateTime.Parse(row[TBL_COL_START_MON].ToString()),
                            EndMON = DateTime.Parse(row[TBL_COL_END_MON].ToString()),
                            StartTUE = DateTime.Parse(row[TBL_COL_START_TUE].ToString()),
                            EndTUE = DateTime.Parse(row[TBL_COL_END_TUE].ToString()),
                            StartWED = DateTime.Parse(row[TBL_COL_START_WED].ToString()),
                            EndWED = DateTime.Parse(row[TBL_COL_END_WED].ToString()),
                            StartTHU = DateTime.Parse(row[TBL_COL_START_THU].ToString()),
                            EndTHU = DateTime.Parse(row[TBL_COL_END_THU].ToString()),
                            StartFRI = DateTime.Parse(row[TBL_COL_START_FRI].ToString()),
                            EndFRI = DateTime.Parse(row[TBL_COL_END_FRI].ToString()),
                            StartSAT = DateTime.Parse(row[TBL_COL_START_SAT].ToString()),
                            EndSAT = DateTime.Parse(row[TBL_COL_END_SAT].ToString()),
                            StartSUN = DateTime.Parse(row[TBL_COL_START_SUN].ToString()),
                            EndSUN = DateTime.Parse(row[TBL_COL_END_SUN].ToString()),
                            IsInUse = Convert.ToBoolean(row[TBL_COL_INUSE].ToString()),
                        };
                        timezoneCollection.Add(timezone);
                    }
                    return timezoneCollection;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(AccessTimezone timezone)
        {
            int inUse = timezone.IsInUse == true ? 1 : 0;
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}
                                    (
                                     {TBL_COL_NAME}, {TBL_COL_CODE}, {TBL_COL_DESCRIPTION},
                                     {TBL_COL_START_MON}, {TBL_COL_END_MON},
                                     {TBL_COL_START_TUE}, {TBL_COL_END_TUE},
                                     {TBL_COL_START_WED}, {TBL_COL_END_WED},
                                     {TBL_COL_START_THU}, {TBL_COL_END_THU},
                                     {TBL_COL_START_FRI}, {TBL_COL_END_FRI},
                                     {TBL_COL_START_SAT}, {TBL_COL_END_SAT},
                                     {TBL_COL_START_SUN}, {TBL_COL_END_SUN},
                                     {TBL_COL_INUSE}
                                    )
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values
                                    (
                                     N'{timezone.Name}', N'{timezone.Code}', N'{timezone.Description}',
                                    '{timezone.StartMON}', '{timezone.EndMON}', 
                                    '{timezone.StartTUE}', '{timezone.EndTUE}', 
                                    '{timezone.StartWED}', '{timezone.EndWED}', 
                                    '{timezone.StartTHU}', '{timezone.EndTHU}', 
                                    '{timezone.StartFRI}', '{timezone.EndFRI}', 
                                    '{timezone.StartSAT}', '{timezone.EndSAT}', 
                                    '{timezone.StartSUN}', '{timezone.EndSUN}',
                                    {inUse}
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
        //Modify
        public static bool Modify(AccessTimezone timezone, string ID)
        {
            string updateCMD = $@"UPDATE {TBL_NAME} SET 
                                  {TBL_COL_NAME} = N'{timezone.Name}',
                                  {TBL_COL_CODE} = N'{timezone.Code}',
                                  {TBL_COL_DESCRIPTION} = N'{timezone.Description}',
                                  {TBL_COL_START_MON} = N'{timezone.StartMON}',
                                  {TBL_COL_END_MON} = N'{timezone.EndMON}',
                                  {TBL_COL_START_TUE} = N'{timezone.StartTUE}',
                                  {TBL_COL_END_TUE} = N'{timezone.EndTUE}',
                                  {TBL_COL_START_WED} = N'{timezone.StartWED}',
                                  {TBL_COL_END_WED} = N'{timezone.EndWED}',
                                  {TBL_COL_START_THU} = N'{timezone.StartTHU}',
                                  {TBL_COL_END_THU} = N'{timezone.EndTHU}',
                                  {TBL_COL_START_FRI} = N'{timezone.StartFRI}',
                                  {TBL_COL_END_FRI} = N'{timezone.EndFRI}',
                                  {TBL_COL_START_SAT} = N'{timezone.StartSAT}',
                                  {TBL_COL_END_SAT} = N'{timezone.EndSAT}',
                                  {TBL_COL_START_SUN} = N'{timezone.StartSUN}',
                                  {TBL_COL_END_SUN} = N'{timezone.EndSUN}',
                                  {TBL_COL_INUSE} = {Convert.ToInt16(timezone.IsInUse)}
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
        public static bool Delete(string timezoneID)
        {
            string deleteCMD = $@"Delete {TBL_NAME} Where {TBL_COL_ID}='{timezoneID}'";
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
