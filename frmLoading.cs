using CryptorEngines;
using FileXMLs;
using iAccess.Databases;
using iParking.Database;
using SQLConns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess
{
    public partial class frmLoading : Form
    {
        public static bool isLoadingSuccess = false;
        SQLConn[] sqls = null;
        public frmLoading()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            lblStatus?.Invoke(new Action(() =>
            {
                lblStatus.Text = text;
            }));
        }
        public void SetProgressValue(int value)
        {
            progressBarLoading?.Invoke(new Action(() =>
            {
                progressBarLoading.Value = value;
            }));
        }
        private async void frmLoading_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await Task.Run(() =>
            {
                SetProgressValue(progressBarLoading.Minimum);
                SetText("Connect to SQL Server...");
                try
                {
                    if (File.Exists(Application.StartupPath + "\\SQLConn.xml"))
                    {
                        FileXML.ReadXMLSQLConn(Application.StartupPath + "\\SQLConn.xml", ref sqls);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmConnectionConfig: " + ex.Message);
                }

                ConnectToSQLServer();

                if (!Staticpool.mdb.OpenMDB())
                {
                    if (MessageBox.Show("Connect To Database Error, Do you want continue", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                SetProgressValue(progressBarLoading.Value + 10);




                SetText("Load Card Data...");
                tblCard.LoadCardData(Staticpool.Cards);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Card Privilege...");
                tblCardPrivilege.LoadDataCardPrivilege(Staticpool.CardPrivileges);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Card Group...");
                tblCardGroup.LoadDataCardGroup(Staticpool.CardGroups);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Timezone...");
                tblTimezone.LoadDataTimezone(Staticpool.timezones);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Camera...");
                tblCamera.LoadDataCamera(Staticpool.Cameras);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Access Controller...");
                tblController.LoadDataController(Staticpool.controllers);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Controller Group...");
                tblControllerGroup.LoadDataControllerGroup(Staticpool.controllerGroups);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Output...");
                tblController_Door.LoadDataController_Door(Staticpool.Controller_Doors);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Customer...");
                tblCustomer.LoadCustomer(Staticpool.customers);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Department...");
                tblDepartment.LoadDataDepartment(Staticpool.departments);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Door...");
                tblDoor.LoadDataDoor(Staticpool.doors);
                SetProgressValue(progressBarLoading.Value + 10);

                isLoadingSuccess = true;
                this.DialogResult = DialogResult.OK;
            });

        }
        private void ConnectToSQLServer()
        {
            if (sqls != null && sqls.Length > 0)
            {
                string cbSQLServerName = sqls[0].SQLServerName;
                string cbSQLDatabaseName = sqls[0].SQLDatabase;
                string cbSQLAuthentication = sqls[0].SQLAuthentication;
                string txtSQLUserName = sqls[0].SQLUserName;
                string txtSQLPassword = CryptorEngine.Decrypt(sqls[0].SQLPassword, true);
                Staticpool.mdb = new MDB(cbSQLServerName, cbSQLDatabaseName, cbSQLAuthentication, txtSQLUserName, txtSQLPassword);
            }
        }
    }
}
