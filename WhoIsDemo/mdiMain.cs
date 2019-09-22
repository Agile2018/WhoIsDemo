using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.form;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.repository;
using WhoIsDemo.view.tool;


namespace WhoIsDemo
{
    public partial class mdiMain : Form
    {
        #region constants
        public const string NAME = "mdiMain";
        #endregion
        #region variables
        private ManagerControlView managerControlView = new ManagerControlView();
        DiskPresenter diskPresenter = new DiskPresenter();
        private RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();
        
        IDisposable subscriptionHearInvalid;
        #endregion

        public mdiMain()
        {
            InitializeComponent();
            
        }

        private void SubscriptionReactive()
        {

            subscriptionHearInvalid = HearInvalidPresenter.Instance.subjectError.Subscribe(
                result => LaunchMessage(result),
                () => Console.WriteLine(StringResource.complete));            

        }

        private void LaunchMessage(string result)
        {

            this.statusStrip.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(result, 0, this.statusStrip)));
        }

        private void mdiMain_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Top = 0;
            this.Left = (int)((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.Black;
            managerControlView.CreateStatusBar(this, statusStrip);            
            SubscriptionReactive();
            diskPresenter.CreateDirectoryWork();
            VerifyFileConfiguration();
            GetListVideos();            
            
        }
             
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();
        }
  

        private void IntAipuFace()
        {
            if (!string.IsNullOrEmpty(Configuration.Instance.ConnectDatabase))
            {
                AipuFace.Instance.InitLibrary();
                AipuFace.Instance.LoadConfiguration(DiskPresenter.directory);
            }
            else
            {
                this.statusStrip.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(StringResource.configuration_empty, 0, this.statusStrip)));

            }


        }

        private void CreateParamsDatabase()
        {
            DatabaseConfig databaseConfig = new DatabaseConfig();
            databaseConfig.configuration = "database_configuration";
            ParamsDatabase paramsDatabase = new ParamsDatabase();
            paramsDatabase.connect = "mongodb://localhost:27017/?minPoolSize=3&maxPoolSize=3";
            paramsDatabase.name = "dbass";
            databaseConfig.Params = paramsDatabase;
            diskPresenter.SaveDatabaseConfiguration(databaseConfig);
            Configuration.Instance.ConnectDatabase = databaseConfig.Params.connect;
            Configuration.Instance.NameDatabase = databaseConfig.Params.name;
        }

        private void CreateParamsDetect()
        {
            Detect detect = new Detect();
            detect.configuration = "detect_configuration";
            ParamsDetect paramsDetect = new ParamsDetect();
            paramsDetect.accuracy = 600;
            paramsDetect.maxeye = 200 ;
            paramsDetect.maxfaces = 1;
            paramsDetect.mineye = 25;
            detect.Params = paramsDetect;
            diskPresenter.SaveDetectConfiguration(detect);
        }
        private void VerifyFileConfiguration()
        {
            if (!diskPresenter.VerifyFileOfConfiguration())
            {
                diskPresenter.CreateContentDirectoryWork();
                CreateParamsDatabase();
                CreateParamsDetect();
                this.statusStrip.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(StringResource.configuration_empty, 0, this.statusStrip)));

            }
            else
            {
                GetDatabaseConfiguration();
            }
        }

        private void mdiMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Threading.Thread closeLibrary = new System
                .Threading.Thread(new System.Threading
                .ThreadStart(RequestAipu.Instance.Terminate));
            closeLibrary.Start();
            
        }

        //private void btnLoadLibrary_Click(object sender, EventArgs e)
        //{
        //    if (!AipuFace.Instance.IsLoadConfiguration)
        //    {
        //        IntAipuFace();
        //    }
            
        //}

        private void GetListVideos()
        {
            Configuration.Instance.ListVideo = diskPresenter.ReadListVideo();
            if (Configuration.Instance.ListVideo.Count != 0)
            {
                foreach(Video vid in Configuration.Instance.ListVideo)
                {
                    cboVideo.Items.Add(vid.id);
                }
            }
        }

        private void GetDatabaseConfiguration()
        {
            DatabaseConfig databaseConfig = diskPresenter.ReadDatabaseConfiguration();
            if (!string.IsNullOrEmpty(databaseConfig.Params.connect))
            {
                Configuration.Instance.ConnectDatabase = databaseConfig.Params.connect;
                Configuration.Instance.NameDatabase = databaseConfig.Params.name;
                
            }
        }

        private void cboVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboVideo.SelectedIndex;
            if (index != -1)
            {
                Configuration.Instance.VideoDefault = Configuration
                    .Instance.ListVideo[index].path;
            }
        }     
       

        private void enrolamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task taskLoadPeoples = SynchronizationPeoplePresenter.Instance.TaskLoadPeoples();
            managerControlView.SetValueTextStatusStrip("", 0, statusStrip);
            frmEnroll frmWork = new frmEnroll() { MdiParent = this };
            frmWork.strNameMenu = "enrolamientoToolStripMenuItem";
            frmWork.LinkVideo = 1;
            enrolamientoToolStripMenuItem.Enabled = false;
            controlDeEntradaToolStripMenuItem.Enabled = false;
            configuraciónToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void controlDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managerControlView.SetValueTextStatusStrip("", 0, statusStrip);
            frmEntryControl frmWork = new frmEntryControl() { MdiParent = this };
            frmWork.strNameMenu = "controlDeEntradaToolStripMenuItem";
            frmWork.LinkVideo = 2;
            controlDeEntradaToolStripMenuItem.Enabled = false;
            enrolamientoToolStripMenuItem.Enabled = false;
            configuraciónToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void mdiMain_Shown(object sender, EventArgs e)
        {
            IntAipuFace();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration frmWork = new frmConfiguration() { MdiParent = this };
            frmWork.strNameMenu = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Enabled = false;
            controlDeEntradaToolStripMenuItem.Enabled = false;
            enrolamientoToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }
    }
}
