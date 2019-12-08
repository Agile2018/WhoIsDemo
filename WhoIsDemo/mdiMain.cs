using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.form;
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
        private Random random = new Random();
        IDisposable subscriptionHearInvalid;
        #endregion

        public mdiMain()
        {
            DefineCurrentUICulture();
            InitializeComponent();
            
        }

        private void DefineCurrentUICulture()
        {
            if (Thread.CurrentThread.CurrentUICulture.IetfLanguageTag != "en-US")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }

            ManagerResource.Instance.SetResourceManager();
        }

        private void SubscriptionReactive()
        {

            subscriptionHearInvalid = HearInvalidPresenter.Instance.subjectError.Subscribe(
                result => LaunchMessage(result),
                () => Console.WriteLine(ManagerResource.Instance.resourceManager
                    .GetString("complete")));

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
            SetValueRegistryLevelResolution();
            SetValueRegistryTimeRefreshEntryControl();
            GetParamsTracking();
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
           
            Configuration.Instance.TimeRefreshEntryControl = Configuration
                    .Instance.ListTimeRefreshEntryControl[Convert.ToInt16(timeIndex)];

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();
            
            
        }
  

        private void IntAipuFace()
        {
            if (!string.IsNullOrEmpty(Configuration.Instance.ConnectDatabase))
            {
                RequestAipu.Instance.InitLibrary();
                RequestAipu.Instance.LoadConfiguration(DiskPresenter.directory);
            }
            else
            {
                this.statusStrip.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("configuration_empty"), 0, this.statusStrip)));

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
            paramsDetect.maxeye = 250 ;
            paramsDetect.maxfaces = 1;
            paramsDetect.mineye = 35;
            paramsDetect.modedetect = 1;
            paramsDetect.extractionmode = 0;
            //paramsDetect.refreshInterval = 2000;
            detect.Params = paramsDetect;
            diskPresenter.SaveDetectConfiguration(detect);
        }

        private void CreateParamsIdentify()
        {
            Identify identify = new Identify();
            identify.configuration = "identify_configuration";
            ParamsIdentify paramsIdentify = new ParamsIdentify();
            paramsIdentify.A_MinEyeDist = 35;
            paramsIdentify.A_MaxEyeDist = 250;
            paramsIdentify.A_FaceDetectionForced = 2;
            paramsIdentify.A_IdentificationSpeed = 5;
            paramsIdentify.A_SimilarityThreshold = 40;
            paramsIdentify.A_FaceDetectThreshold = 450;
            paramsIdentify.A_BestMatchedCandidates = 1;
            identify.Params = paramsIdentify;
            diskPresenter.SaveIdentifyConfiguration(identify);
            
        }

        private void VerifyFileConfiguration()
        {
            if (!diskPresenter.VerifyFileOfConfiguration())
            {
                diskPresenter.CreateContentDirectoryWork();
                CreateParamsDatabase();
                CreateParamsDetect();
                CreateParamsIdentify();
                this.statusStrip.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("configuration_empty"), 0, this.statusStrip)));

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
        

        private void GetListVideos()
        {
            Configuration.Instance.ListVideo = diskPresenter.ReadListVideo();
            if (Configuration.Instance.ListVideo.Count != 0)
            {
                foreach(Video vid in Configuration.Instance.ListVideo)
                {
                    cboVideo.Items.Add(vid.path);
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
                Configuration.Instance.VideoTypeDefault = Configuration
                    .Instance.ListVideo[index].type;
            }
        }     
       

        private void enrolamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            managerControlView.SetValueTextStatusStrip("", 0, statusStrip);
            frmEnroll frmWork = new frmEnroll() { MdiParent = this };
            frmWork.strNameMenu = "enrolamientoToolStripMenuItem";
            frmWork.LinkVideo = random.Next(51);
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
            frmWork.LinkVideo = random.Next(50, 101);
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

        private void GetParamsTracking()
        {

            if (!string.IsNullOrEmpty(registryValueDataReader
                .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                RegistryValueDataReader.MAXEYE_KEY)))
            {
                Configuration.Instance.MaxEyeTrack = Convert.ToInt16(registryValueDataReader
                    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.MAXEYE_KEY));
                
            }
            if (!string.IsNullOrEmpty(registryValueDataReader
                .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                RegistryValueDataReader.MINEYE_KEY)))
            {
                Configuration.Instance.MinEyeTrack = Convert.ToInt16(registryValueDataReader
                    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.MINEYE_KEY));
               
            }

            if (!string.IsNullOrEmpty(registryValueDataReader
               .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
               RegistryValueDataReader.REFRESH_INTERVAL_KEY)))
            {
                Configuration.Instance.RefreshIntervalTrack = Convert.ToInt16(registryValueDataReader
                    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.REFRESH_INTERVAL_KEY));
                
            }

            if (!string.IsNullOrEmpty(registryValueDataReader
               .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
               RegistryValueDataReader.CONFIDENCE_KEY)))
            {
                Configuration.Instance.ConfidenceTrack = Convert.ToInt16(registryValueDataReader
                    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.CONFIDENCE_KEY));
                
            }

            if (!string.IsNullOrEmpty(registryValueDataReader
               .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
               RegistryValueDataReader.DEEPTRACK_KEY)))
            {
                Configuration.Instance.DeepTrack = registryValueDataReader
                    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.DEEPTRACK_KEY);

            }

            string level = "0";
            if (!string.IsNullOrEmpty(registryValueDataReader
               .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
               RegistryValueDataReader.TRACKMODE_KEY)))
            {

                level = registryValueDataReader
                        .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                        RegistryValueDataReader.TRACKMODE_KEY);

            }
            Configuration.Instance.TrackMode = Convert.ToInt16(level);
            level = "0";

            if (!string.IsNullOrEmpty(registryValueDataReader
               .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
               RegistryValueDataReader.TRACKSPEED_KEY)))
            {

                level = registryValueDataReader
                        .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                        RegistryValueDataReader.TRACKSPEED_KEY);

            }
            Configuration.Instance.TrackSpeed = Convert.ToInt16(level);
            level = "0";

            if (!string.IsNullOrEmpty(registryValueDataReader
               .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
               RegistryValueDataReader.TRACKMOTION_KEY)))
            {

                level = registryValueDataReader
                        .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                        RegistryValueDataReader.TRACKMOTION_KEY);

            }
            Configuration.Instance.TrackMotion = Convert.ToInt16(level);
        }
    }
}
