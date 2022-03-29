using iAccess.Enums;
using iAccess.Objects;
using iAccess.Objects.Cards;
using iAccess.Objects.Customers;
using iAccess.Objects.Customers.Cards;
using iAccess.Objects.Devices;
using iParking.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KztekObject.Cards.CardFactory;

namespace iAccess
{
    public static class Staticpool
    {
        public static string FaceImageSavePath = Properties.Settings.Default.FaceImageSavePath;

        public static MDB mdb = null;

        public static EM_AppResolution appResolution;

        public static CameraCollection Cameras = new CameraCollection();
        public static Camera_Door_DetailCollection Camera_Doors = new Camera_Door_DetailCollection();
        public static CardCollection Cards = new CardCollection();
        public static CardGroupCollection CardGroups = new CardGroupCollection();
        public static CardPrivilegeCollection CardPrivileges = new CardPrivilegeCollection();

        public static AccessControllerCollection controllers = new AccessControllerCollection();
        public static ControllerGroupCollection controllerGroups = new ControllerGroupCollection();

        public static Controller_Door_DetailCollection Controller_Doors = new Controller_Door_DetailCollection();
        public static CustomerCollection customers = new CustomerCollection();
        public static DepartmentCollection departments = new DepartmentCollection();
        public static DoorCollection doors = new DoorCollection();
        public static TimezoneCollection timezones = new TimezoneCollection();


        #region:Datagridview
        public static string Id(DataGridView dgv)
        {
            string _lcma = "";
            if (dgv != null)
            {
                if (dgv.Rows.Count > 0)
                {
                    DataGridViewRow _drv = dgv.CurrentRow;
                    try
                    {
                        _lcma = _drv.Cells["_ID"].Value.ToString();
                    }
                    catch
                    {
                        _lcma = "";
                    }
                    return _lcma;
                }
            }
            return "";            
        }
        #endregion

        #region:Datetime
        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }
        #endregion


        #region: ALPHABET
        public static char incrementCharacter(char input)
        {
            return (input == 'z' ? 'a' : (char)(input + 1));
        }
        #endregion: END ALPHABET

        #region: ENUMS
        public static int GetCardTypeByName(string typeName)
        {
            foreach (int i in Enum.GetValues(typeof(EM_CardType)))
            {
                if (typeName == Enum.GetName(typeof(EM_CardType), i))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion: END ENUMS


        #region: IMAGES
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        #endregion: END IMAGES

    }
}
