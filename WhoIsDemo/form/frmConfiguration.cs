using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.repository;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmConfiguration : Form
    {
        #region variables
        private RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();
        ManagerControlView managerControlView = new ManagerControlView();
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

        private void SetValueRegistryIpCameraInControl()
        {
            if (!string.IsNullOrEmpty(registryValueDataReader
                .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                RegistryValueDataReader.IP_CAMERA_KEY)))

                txtIpVideo.Text = registryValueDataReader
                    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.IP_CAMERA_KEY);
            else
                throw new FieldAccessException("Value Configuration empty.");
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                SetValueRegistryIpCameraInControl();
            }
            catch (FieldAccessException fe)
            {
                if (fe != null)
                {

                    string messageError = StringResource.value_key_epty + ": " +
                        fe.Source + ": " + fe.Message;
                    managerControlView
                    .SetValueTextStatusStrip(messageError, 0, this.status);
                }

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIpVideo.Text))
            {
                registryValueDataReader.setKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.IP_CAMERA_KEY, txtIpVideo.Text);
                managerControlView
                    .SetValueTextStatusStrip(StringResource.complete, 0, this.status);
            }

        }
    }
}
