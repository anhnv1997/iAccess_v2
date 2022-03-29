using iAccess.Objects.Cards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KztekObject.Cards.CardFactory;

namespace iAccess.Databases
{
    public class tblCard
    {
        public const string TBL_NAME = "tblCard";
        public const string TBL_COL_ID = "ID";
        public const string TBL_COL_SortOrder = "SortOrder";
        public const string TBL_COL_Name = "Name";
        public const string TBL_COL_Code = "Code";
        public const string TBL_COL_Description = "Description";
        public const string TBL_COL_CardNumber = "CardNumber";
        public const string TBL_COL_CardCode = "CardCode";
        public const string TBL_COL_StartTime = "StartTime";
        public const string TBL_COL_EndTime = "EndTime";
        public const string TBL_COL_CardTypeID = "CardTypeID";
        public const string TBL_COL_CardGroupID = "CardGroupID";
        public const string TBL_COL_CardPrivilegeID = "CardPrivilegeID";
        public const string TBL_COL_InUse = "InUse";
        //Get
        public static string GetCMD = $@"Select {TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description},{TBL_COL_CardNumber},
                                                {TBL_COL_CardCode},{TBL_COL_StartTime},{TBL_COL_EndTime},{TBL_COL_CardTypeID},
                                                {TBL_COL_CardGroupID},{TBL_COL_CardPrivilegeID},{TBL_COL_InUse},{TBL_COL_ID},{TBL_COL_InUse}
                                         from {TBL_NAME} order by {TBL_COL_SortOrder}";
        public static CardCollection LoadCardData(CardCollection cards)
        {
            cards.Clear();
            DataTable dtCard = Staticpool.mdb.FillData(GetCMD);
            if (dtCard != null)
            {
                if (dtCard.Rows.Count > 0)
                {
                    foreach(DataRow row in dtCard.Rows)
                    {
                        Card card = new Card()
                        {
                            ID = row[TBL_COL_ID].ToString(),
                            Name = row[TBL_COL_Name].ToString(),
                            Code = row[TBL_COL_Code].ToString(),
                            Description = row[TBL_COL_Description].ToString(),
                            CardNumber = row[TBL_COL_CardNumber].ToString(),
                            CardCode = row[TBL_COL_CardCode].ToString(),
                            StartTime = DateTime.Parse(row[TBL_COL_StartTime].ToString()),
                            EndTime = DateTime.Parse(row[TBL_COL_EndTime].ToString()),
                            CardType = (EM_CardType)Convert.ToInt32(row[TBL_COL_CardTypeID].ToString()),
                            CardGroupID = row[TBL_COL_CardGroupID].ToString(),
                            CardPrivilegeID = row[TBL_COL_CardPrivilegeID].ToString(),
                            isInUse = Convert.ToBoolean(row[TBL_COL_InUse].ToString()),
                        };
                        cards.Add(card);
                    }
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(Card card)
        {
            int inUse = card.isInUse == true ? 1 : 0;
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description},{TBL_COL_CardNumber},
                                  {TBL_COL_CardCode},{TBL_COL_StartTime},{TBL_COL_EndTime},{TBL_COL_CardTypeID},{TBL_COL_CardGroupID},
                                  {TBL_COL_CardPrivilegeID},{TBL_COL_InUse})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{card.Name}',N'{card.Code}',N'{card.Description}','{card.CardNumber}',
                                           '{card.CardCode}','{card.StartTime}','{card.EndTime}',{(int)card.CardType},'{card.CardGroupID}',
                                           '{card.CardPrivilegeID}', {inUse})
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

        public static bool InsertMultyCard(List<Card> card)
        {
            return false;
        }

        //Modify
        public static bool Modify(Card card, string ID)
        {
            int isInUse = card.isInUse == true ? 1 : 0;
            string updateCMD = $@"Update {TBL_NAME} set 
                                  {TBL_COL_Name} = N'{card.Name}',
                                  {TBL_COL_Code} = N'{card.Code}',
                                  {TBL_COL_Description} = N'{card.Description}',
                                  {TBL_COL_CardNumber} = '{card.CardNumber}',
                                  {TBL_COL_CardCode} = '{card.CardCode}',
                                  {TBL_COL_StartTime} = '{card.StartTime}',
                                  {TBL_COL_EndTime} = '{card.EndTime}',
                                  {TBL_COL_CardTypeID} = {(int)card.CardType},
                                  {TBL_COL_CardGroupID} = '{card.CardGroupID}',
                                  {TBL_COL_CardPrivilegeID} = '{card.CardPrivilegeID}',
                                  {TBL_COL_InUse} = {isInUse}
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
        public static bool Delete(string cardID)
        {
            if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{cardID}'"))
            {
                if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{cardID}'"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
