using Newtonsoft.Json;
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
using WhoIsDemo.locatable_resources;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.repository;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmConfiguration : Form
    {
        #region constants
        
        #endregion
        #region variables
        public string strNameMenu;
        //private RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();
        ManagerControlView managerControlView = new ManagerControlView();
        DiskPresenter diskPresenter = new DiskPresenter();
        private StatusStrip status;
        #endregion
        public frmConfiguration()
        {
            InitializeComponent();
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void SetValueRegistryIpCameraInControl()
        //{
        //    //if (!string.IsNullOrEmpty(registryValueDataReader
        //    //    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
        //    //    RegistryValueDataReader.IP_CAMERA_KEY)))

        //    //    txtIpVideo.Text = registryValueDataReader
        //    //        .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
        //    //        RegistryValueDataReader.IP_CAMERA_KEY);
        //    //else
        //    //    throw new FieldAccessException(StringResource.verify_key);
        //}

        //private void SetValueRegistryDirectoryInControl()
        //{
        //    if (!string.IsNullOrEmpty(registryValueDataReader
        //        .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
        //        RegistryValueDataReader.DIRECTORY_KEY)))

        //        txtDirectoryConfiguration.Text = registryValueDataReader
        //            .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
        //            RegistryValueDataReader.DIRECTORY_KEY);
        //    else
        //        throw new FieldAccessException(StringResource.verify_key);
        //}

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                GetDatabaseConfiguration();
                //SetValueRegistryIpCameraInControl();
                //SetValueRegistryDirectoryInControl();
            }
            catch (FieldAccessException fe)
            {
                if (fe != null)
                {

                    string messageError = StringResource.value_key_empty + ": " +
                        fe.Source + ": " + fe.Message;
                    managerControlView
                    .SetValueTextStatusStrip(messageError, 0, this.status);
                }

            }

        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    //if (!string.IsNullOrEmpty(txtIpVideo.Text))
        //    //{
        //    //    registryValueDataReader.setKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
        //    //        RegistryValueDataReader.IP_CAMERA_KEY, txtIpVideo.Text);
        //    //    managerControlView
        //    //        .SetValueTextStatusStrip(StringResource.complete, 0, this.status);
        //    //}
        //    //if (!string.IsNullOrEmpty(txtDirectoryConfiguration.Text))
        //    //{
        //    //    registryValueDataReader.setKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
        //    //        RegistryValueDataReader.DIRECTORY_KEY, txtDirectoryConfiguration.Text);
        //    //    managerControlView
        //    //        .SetValueTextStatusStrip(StringResource.complete, 0, this.status);
        //    //}
        //    //managerControlView
        //    //        .SetValueTextStatusStrip(StringResource.reset, 0, this.status);

        //}

        private void frmConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            managerControlView.EnabledOptionSubMenu(strNameMenu, mdiMain.NAME);
        }

        private bool ValidateDatabase()
        {
            return !string.IsNullOrEmpty(txtNameDatabase.Text) && 
                !string.IsNullOrEmpty(txtConnect.Text);
        }

        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            if (ValidateDatabase())
            {
                DatabaseConfig databaseConfig = new DatabaseConfig();
                databaseConfig.configuration = "database_configuration";
                ParamsDatabase paramsDatabase = new ParamsDatabase();
                paramsDatabase.connect = txtConnect.Text;
                paramsDatabase.name = txtNameDatabase.Text;
                databaseConfig.Params = paramsDatabase;
                diskPresenter.SaveDatabaseConfiguration(databaseConfig);
                lblOkDatabase.Text = "OK";
            }
        }

        private void GetDatabaseConfiguration()
        {
            DatabaseConfig databaseConfig = diskPresenter
                .ReadDatabaseConfiguration();
            if (databaseConfig != null)
            {
                txtNameDatabase.Text = (string.IsNullOrEmpty(databaseConfig
                    .Params.name.ToString())) ? " " :
                    databaseConfig.Params.name.ToString();
                txtConnect.Text = (string.IsNullOrEmpty(databaseConfig
                    .Params.connect.ToString())) ? " " :
                    databaseConfig.Params.connect.ToString();

            }

        }


    }
}
