using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmConfigurationDinamic : Form
    {
        #region constant
        
        #endregion
        #region variables
        public string strNameMenu;
        ToolStripComboBox cboVideos;
        DiskPresenter diskPresenter = new DiskPresenter();
        ManagerControlView managerControlView = new ManagerControlView();
        #endregion

        #region methods
        private bool VerifyInputDetect()
        {
            return (!string.IsNullOrEmpty(txtAccurancy.Text) &&
                !string.IsNullOrEmpty(txtMaxDetect.Text) &&
                !string.IsNullOrEmpty(txtMaxEye.Text) &&
                !string.IsNullOrEmpty(txtMinEye.Text));
        }

        #endregion


        public frmConfigurationDinamic()
        {
            InitializeComponent();
            cboVideos = managerControlView.GetToolStripComboBoxMain(mdiMain.NAME);

        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            if (VerifyInputDetect())
            {
                Detect detect = new Detect();
                detect.configuration = "detect_configuration";
                ParamsDetect paramsDetect = new ParamsDetect();
                paramsDetect.accuracy = Convert.ToInt16(txtAccurancy.Text);
                paramsDetect.maxeye = Convert.ToInt16(txtMaxEye.Text); ;
                paramsDetect.maxfaces = Convert.ToInt16(txtMaxDetect.Text); ;
                paramsDetect.mineye = Convert.ToInt16(txtMinEye.Text); ;
                detect.Params = paramsDetect;
                diskPresenter.SaveDetectConfiguration(detect);
                this.lblOkDetect.Text = "Wait...";
                RequestAipu.Instance.StopAipu();
                Task.Delay(500).Wait();
                RequestAipu.Instance.ReloadAipu();
                this.lblOkDetect.Text = "OK";
            }
        }

        private void frmConfigurationDinamic_Load(object sender, EventArgs e)
        {
            InitControls();
            GetDetectionConfiguration();
            GetVideoConfiguration();
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

        private void GetDetectionConfiguration()
        {
            Detect detect = diskPresenter.ReadDetectConfiguration();
            if (detect != null)
            {
                txtAccurancy.Text = (string.IsNullOrEmpty(detect.Params.accuracy.ToString())) ? "0" :
                    detect.Params.accuracy.ToString();
                txtMaxEye.Text = (string.IsNullOrEmpty(detect.Params.maxeye.ToString())) ? "0" :
                    detect.Params.maxeye.ToString();
                txtMaxDetect.Text = (string.IsNullOrEmpty(detect.Params.maxfaces.ToString())) ? "0" :
                    detect.Params.maxfaces.ToString();
                txtMinEye.Text = (string.IsNullOrEmpty(detect.Params.mineye.ToString())) ? "0" :
                    detect.Params.mineye.ToString();

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

        private void InitControls()
        {

            lvwVideo.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvwVideo.Columns.Add("Ruta", 600, HorizontalAlignment.Center);
            cboLevelResolution.SelectedIndex = 0;
        }

        private void btnSaveVideo_Click(object sender, EventArgs e)
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
            foreach(ListViewItem item in lvwVideo.Items)
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
        }

        private void SetVideoInControl()
        {
            if (Configuration.Instance.ListVideo.Count != 0)
            {
                cboVideos.Items.Clear();
                foreach (Video vid in Configuration.Instance.ListVideo)
                {
                    cboVideos.Items.Add(vid.id);
                }
            }
        }
        private void btnSaveVideos_Click(object sender, EventArgs e)
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

        private void frmConfigurationDinamic_FormClosing(object sender, FormClosingEventArgs e)
        {
            managerControlView.EnabledOptionSubMenu(strNameMenu, mdiMain.NAME);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            }
        }
    }
}
