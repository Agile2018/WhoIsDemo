using System;
using System.Collections.Generic;
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

        //private void dispositivoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    managerControlView.SetValueTextStatusStrip("", 0, statusStrip);            
        //    frmIdentify frmWork = new frmIdentify() { MdiParent = this };           
        //    frmWork.strNameMenu = "dispositivoToolStripMenuItem";           
        //    dispositivoToolStripMenuItem.Enabled = false;
        //    frmWork.Show();
        //}

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmToolDatabase frmWork = new frmToolDatabase() { MdiParent = this };
            frmWork.strNameMenu = "baseDeDatosToolStripMenuItem";
            baseDeDatosToolStripMenuItem.Enabled = false;
            frmWork.Show();
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

        private void VerifyFileConfiguration()
        {
            if (!diskPresenter.VerifyFileOfConfiguration())
            {
                diskPresenter.CreateContentDirectoryWork();
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

        private void btnLoadLibrary_Click(object sender, EventArgs e)
        {
            if (!AipuFace.Instance.IsLoadConfiguration)
            {
                IntAipuFace();
            }
            
        }

        //private void btnStopLibrary_Click(object sender, EventArgs e)
        //{
        //    RequestAipu.Instance.StopAipu();
        //    this.statusStrip.Invoke(new Action(() => managerControlView
        //            .SetValueTextStatusStrip(StringResource.stop_library, 0, this.statusStrip)));
        //}

        //private void btnReloadLibrary_Click(object sender, EventArgs e)
        //{
        //    RequestAipu.Instance.ReloadAipu();
        //    this.statusStrip.Invoke(new Action(() => managerControlView
        //            .SetValueTextStatusStrip(StringResource.reload_library, 0, this.statusStrip)));
        //}        

        private void globalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration frmWork = new frmConfiguration() { MdiParent = this };
            frmWork.strNameMenu = "globalToolStripMenuItem";
            globalToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void parcialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigurationDinamic frmWork = new frmConfigurationDinamic() { MdiParent = this };
            frmWork.strNameMenu = "parcialToolStripMenuItem";
            parcialToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

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

        private void btnChangeMode_Click(object sender, EventArgs e)
        {
            RequestAipu.Instance.WorkMode(1);
        }

        private void enrolamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task taskLoadPeoples = SynchronizationPeoplePresenter.Instance.TaskLoadPeoples();
            managerControlView.SetValueTextStatusStrip("", 0, statusStrip);
            frmEnroll frmWork = new frmEnroll() { MdiParent = this };
            frmWork.strNameMenu = "enrolamientoToolStripMenuItem";
            frmWork.LinkVideo = 1;
            enrolamientoToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void controlDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managerControlView.SetValueTextStatusStrip("", 0, statusStrip);
            frmEntryControl frmWork = new frmEntryControl() { MdiParent = this };
            frmWork.strNameMenu = "controlDeEntradaToolStripMenuItem";
            frmWork.LinkVideo = 2;
            controlDeEntradaToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        
    }
}
