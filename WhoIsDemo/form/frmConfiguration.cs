using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.domain.interactor;
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
        ManagerControlView managerControlView = new ManagerControlView();
        DiskPresenter diskPresenter = new DiskPresenter();
        DropDatabasePresenter dropDatabasePresenter = new DropDatabasePresenter();
        private RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();
        private StatusStrip status;
        ToolStripComboBox cboVideos;
        #endregion
        public frmConfiguration()
        {
            InitializeComponent();
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
            this.cboVideos = managerControlView.GetToolStripComboBoxMain(mdiMain.NAME);
        }      

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                InitControls();
                GetDetectionConfiguration();
                GetVideoConfiguration();
                GetDatabaseConfiguration();
                SetValueRegistryLevelResolution();
                SetValueRegistryTimeRefreshEntryControl();
                dropDatabasePresenter.Connect();
            }
            catch (FieldAccessException fe)
            {
                if (fe != null)
                {

                    string messageError = ManagerResource.Instance.resourceManager
                    .GetString("value_key_empty") + ": " +
                        fe.Source + ": " + fe.Message;
                    managerControlView
                    .SetValueTextStatusStrip(messageError, 0, this.status);
                }

            }

        }
    

        private void frmConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            //managerControlView.EnabledOptionSubMenu(strNameMenu, mdiMain.NAME);
            managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
            managerControlView.EnabledOptionMenu("controlDeEntradaToolStripMenuItem", mdiMain.NAME);
            managerControlView.EnabledOptionMenu("enrolamientoToolStripMenuItem", mdiMain.NAME);
        }

        private bool ValidateDatabase()
        {
            return !string.IsNullOrEmpty(txtNameDatabase.Text) && 
                !string.IsNullOrEmpty(txtConnect.Text);
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

        private void InitControls()
        {

            lvwVideo.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvwVideo.Columns.Add("Ruta", 600, HorizontalAlignment.Center);
            
        }

        private void GetDetectionConfiguration()
        {
            Detect detect = diskPresenter.ReadDetectConfiguration();
            Identify identify = diskPresenter.ReadIdentifyConfiguration();
            if (detect != null && identify != null)
            {
                txtAccurancy.Text = (string.IsNullOrEmpty(detect.Params.accuracy.ToString())) ? "0" :
                    detect.Params.accuracy.ToString();
                txtMaxEye.Text = (string.IsNullOrEmpty(detect.Params.maxeye.ToString())) ? "0" :
                    detect.Params.maxeye.ToString();
                txtMaxDetect.Text = (string.IsNullOrEmpty(detect.Params.maxfaces.ToString())) ? "0" :
                    detect.Params.maxfaces.ToString();
                txtMinEye.Text = (string.IsNullOrEmpty(detect.Params.mineye.ToString())) ? "0" :
                    detect.Params.mineye.ToString();

                managerControlView.SetValueToComboBox(cboDetectForced,
                    identify.Params.A_FaceDetectionForced.ToString());
                managerControlView.SetValueToComboBox(cboIdentificationSpeed,
                    identify.Params.A_IdentificationSpeed.ToString());
                if (detect.Params.modedetect == 1)
                {
                    cboDetectorMode.SelectedIndex = 0;
                }
                else
                {
                    cboDetectorMode.SelectedIndex = 1;
                }
            }

        }

        private void GetVideoConfiguration()
        {
            VideoConfig videoConfig = diskPresenter
                .ReadVideoConfiguration();
            if (videoConfig != null)
            {
                foreach (Video vid in videoConfig.videos)
                {
                    ListViewItem item = new ListViewItem(vid.id,
                        lvwVideo.Items.Count);
                    item.SubItems.Add(vid.path);
                    lvwVideo.Items.Add(item);
                }
            }

        }

        private void txtMaxDetect_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtAccurancy_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtMaxEye_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtMinEye_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            if (VerifyInputDetect())
            {
                Detect detect = new Detect();
                Identify identify = new Identify();
                identify.configuration = "identify_configuration";
                detect.configuration = "detect_configuration";
                ParamsIdentify paramsIdentify = new ParamsIdentify();
                ParamsDetect paramsDetect = new ParamsDetect();
                paramsDetect.accuracy = Convert.ToInt16(txtAccurancy.Text);
                paramsDetect.maxeye = Convert.ToInt16(txtMaxEye.Text);
                paramsIdentify.A_MaxEyeDist = Convert.ToInt16(txtMaxEye.Text);
                paramsDetect.maxfaces = Convert.ToInt16(txtMaxDetect.Text); 
                paramsDetect.mineye = Convert.ToInt16(txtMinEye.Text);
                paramsIdentify.A_MinEyeDist = Convert.ToInt16(txtMinEye.Text);
                paramsIdentify.A_FaceDetectionForced = Convert.ToInt16(cboDetectForced.Text);
                paramsIdentify.A_IdentificationSpeed = Convert.ToInt16(cboIdentificationSpeed.Text);
                if (cboDetectorMode.SelectedIndex == 0)
                {
                    paramsDetect.modedetect = 1;
                }
                else
                {
                    paramsDetect.modedetect = 2;
                }

                detect.Params = paramsDetect;
                identify.Params = paramsIdentify;
                diskPresenter.SaveDetectConfiguration(detect);
                diskPresenter.SaveIdentifyConfiguration(identify);
                this.lblOkDetect.Text = "Wait...";
                RequestAipu.Instance.StopAipu();
                Task.Delay(500).Wait();
                RequestAipu.Instance.ReloadAipu();
                this.lblOkDetect.Text = "OK";
            }
        }

        private bool VerifyInputDetect()
        {
            return (!string.IsNullOrEmpty(txtAccurancy.Text) &&
                !string.IsNullOrEmpty(txtMaxDetect.Text) &&
                !string.IsNullOrEmpty(txtMaxEye.Text) &&
                !string.IsNullOrEmpty(txtMinEye.Text) && 
                cboDetectForced.SelectedIndex != -1 && 
                cboIdentificationSpeed.SelectedIndex != -1 && 
                cboDetectorMode.SelectedIndex != -1);
        }        

        private void btnSaveVideoList_Click(object sender, EventArgs e)
        {
            string quantityVideo = "video_" + (lvwVideo.Items.Count + 1).ToString();

            ListViewItem item = new ListViewItem(quantityVideo,
                    lvwVideo.Items.Count);
            item.SubItems.Add(txtIpVideo.Text);
            lvwVideo.Items.Add(item);
        }

        private void SaveVideos()
        {
            List<Video> list = new List<Video>();
            foreach (ListViewItem item in lvwVideo.Items)
            {
                Video video = new Video();
                video.id = item.Text;
                video.path = item.SubItems[1].Text;
                list.Add(video);
            }

            VideoConfig videoConfig = new VideoConfig();
            videoConfig.configuration = "video_configuration";
            videoConfig.videos = list;
            Configuration.Instance.ListVideo = list;
            SetVideoInControl();
            diskPresenter.SaveVideoConfiguration(videoConfig);
            this.lblVideoOk.Text = "OK";
        }

        private void SetVideoInControl()
        {
            if (Configuration.Instance.ListVideo.Count != 0)
            {
                cboVideos.Items.Clear();
                foreach (Video vid in Configuration.Instance.ListVideo)
                {
                    cboVideos.Items.Add(vid.path);
                }
            }
        }

        private void btnSaveVideosFile_Click(object sender, EventArgs e)
        {
            SaveVideos();
        }

        private void lvwVideo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                lvwVideo.SelectedItems[0].Remove();
            }
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
                System.Threading.Thread closeLibrary = new System
                .Threading.Thread(new System.Threading
                .ThreadStart(RequestAipu.Instance.Terminate));
                closeLibrary.Start();
                System.Windows.Forms.Application.Exit();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(ManagerResource.Instance.resourceManager
                    .GetString("delete_database"), "Confirm", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dropDatabasePresenter.DropCurrentDatabase())
                {
                    diskPresenter.FileDelete("iengine.db");
                    lblOkClearDatabase.Text = "OK";
                    managerControlView.SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                        .GetString("complete"),
                        0, this.status);
                }
                else
                {
                    managerControlView.SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                        .GetString("error"),
                        0, this.status);
                }
            }            
            
            
        }

        private void SetValueRegistryLevelResolution()
        {
            string level = "0";
            if (!string.IsNullOrEmpty(registryValueDataReader
                .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                RegistryValueDataReader.LEVEL_RESOLUTION)))
            {
                level = registryValueDataReader
                    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.LEVEL_RESOLUTION);                
            }
            cboLevelResolution.SelectedIndex = Convert.ToInt16(level);
            Configuration.Instance.ResolutionWidthDefault = Configuration
                    .Instance.ListWidthResolution[Convert.ToInt16(level)];
            Configuration.Instance.ResolutionHeightDefault = Configuration
                .Instance.ListHeightResolution[Convert.ToInt16(level)];
        }

        private void SetValueRegistryTimeRefreshEntryControl()
        {
            string timeIndex = "0";
            if (!string.IsNullOrEmpty(registryValueDataReader
                .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                RegistryValueDataReader.REFRESH_ENTRY_CONTROL)))
            {
                timeIndex = registryValueDataReader
                    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.REFRESH_ENTRY_CONTROL);
            }
            cboRefreshCapture.SelectedIndex = Convert.ToInt16(timeIndex);
            Configuration.Instance.TimeRefreshEntryControl = Configuration
                    .Instance.ListTimeRefreshEntryControl[Convert.ToInt16(timeIndex)];

        }

        private void cboLevelResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboLevelResolution.SelectedIndex;
            if (index != -1)
            {
                Configuration.Instance.ResolutionWidthDefault = Configuration
                    .Instance.ListWidthResolution[index];
                Configuration.Instance.ResolutionHeightDefault = Configuration
                    .Instance.ListHeightResolution[index];
                registryValueDataReader.setKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.LEVEL_RESOLUTION, index.ToString());

            }
        }

        private void cboRefreshCapture_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboRefreshCapture.SelectedIndex;
            if (index != -1)
            {
                Configuration.Instance.TimeRefreshEntryControl = Configuration
                    .Instance.ListTimeRefreshEntryControl[index];
                registryValueDataReader.setKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.REFRESH_ENTRY_CONTROL, index.ToString());
            }
        }
    }
}
