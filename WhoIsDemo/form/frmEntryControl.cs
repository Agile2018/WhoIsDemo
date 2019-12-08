using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmEntryControl : Form
    {
        #region constants
        private const int queueImage = 9;
        private const int sizeMaxFlowLayout = 30;
        
        const int HWND_TOPMOST = -1;
        const int HWND_BOTTOM = 1;
        #endregion

        #region variables
        
        
        public string strNameMenu;
        private int indexPerson = 0;
        
        private int countFlowLayoutControls = 0;
        
        private double totalFrame;
        private double fps;
        
        private StatusStrip status;
        private Person personTransition = new Person();
        private List<Person> listPersonSlider = new List<Person>();
        private List<Person> listPersonRegister = new List<Person>();
        private List<TimePerson> lisTimePerson = new List<TimePerson>();
        ManagerControlView managerControlView = new ManagerControlView();
        HearUserPresenter hearUserPresenter = new HearUserPresenter();
        FindImagePresenter findImagePresenter = new FindImagePresenter();
        
        GraffitsPresenter graffitsPresenter = new GraffitsPresenter();
        IDisposable subscriptionHearUser;
        IDisposable subscriptionFindImage;
        IDisposable subscriptionGraffits;

        private int linkVideo;

        public int LinkVideo
        {
            get
            {
                return linkVideo;
            }

            set
            {
                linkVideo = value;
                hearUserPresenter.IdVideo = linkVideo;
                graffitsPresenter.LinkVideo = linkVideo;
            }

        }

        OpenFileDialog openFileDialog = new OpenFileDialog();

        #endregion

        public frmEntryControl()
        {
            InitializeComponent();
        }

        private void SetImage(Bitmap image)
        {
            Bitmap imgLeft = null;
            Bitmap imgRight = null;
            try
            {
                imgLeft = new Bitmap(pic1.Image);
                pic1.Image = imgRight;
                imgRight = new Bitmap(pic2.Image);
                pic2.Image = findImagePresenter
                    .AdjustAlpha(new Bitmap(imgLeft), 0.7f);
                imgLeft = new Bitmap(pic3.Image);
                pic3.Image = imgRight;
                imgRight = new Bitmap(pic4.Image);
                pic4.Image = imgLeft;
                imgLeft = new Bitmap(pic5.Image);
                pic5.Image = imgRight;
                imgRight = new Bitmap(pic6.Image);
                pic6.Image = imgLeft;
                imgLeft = new Bitmap(pic7.Image);
                pic7.Image = imgRight;
                imgRight = new Bitmap(pic8.Image);
                pic8.Image = imgLeft;
                imgLeft = new Bitmap(pic9.Image);
                pic9.Image = imgRight;
            }
            catch (NullReferenceException ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                pic1.Image = image;
            }

        }

        private void frmEntryControl_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.PerformAutoScale();
            this.Top = 0;
            this.Left = 0;
            this.Width = 1086;
            this.Height = 867;
            
            InitControls();
            InitListPerson();            
            EnableObservers();            
            ConnectDatabase();

        }        

        #region methods
        private void InitListPerson()
        {
            Person person = new Person();
            Params paramsPerson = new Params();
            paramsPerson.Id_face = "-1";
            person.Params = paramsPerson;

            for (int i = 0; i < queueImage; i++)
            {
                listPersonSlider.Add(person);
            }
        }
        private void InitControls()
        {
            RequestAipu.Instance.IsRegister(false);
            //RequestAipu.Instance.InitLibraryIdentify();
            this.openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            this.openFileDialog.Multiselect = true;
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
            if (!string.IsNullOrEmpty(Configuration.Instance.VideoDefault))
            {
                InitCapture();
            }
            else
            {
                this.btnStart.Enabled = false;

                managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("ip_video_empty"),
                    0, this.status);
            }
        }

        private void ConnectDatabase()
        {
            findImagePresenter.Connect();
        }

        private void EnableObservers()
        {
            if (!hearUserPresenter.EnableObserverUser())
            {
                managerControlView.SetValueTextStatusStrip(
                    ManagerResource.Instance.resourceManager
                    .GetString("load_library"), 0, this.status);

            }
            
        }

        private void SubscriptionReactive()
        {

            subscriptionFindImage = findImagePresenter.subjectListImage.Subscribe(
                list => AddImageOfPerson(list),
                () => Console.WriteLine(StringResource.complete));
            subscriptionHearUser = hearUserPresenter.subjectUser.Subscribe(
                person => AddPersonIndentify(person),
                () => Console.WriteLine(StringResource.complete));
            subscriptionGraffits = graffitsPresenter.subjectLoad.Subscribe(
                load => FinishLoadFile(load),
                () => Console.WriteLine(StringResource.complete));
        }

        private void FinishLoadFile(bool value)
        {
            if (value)
            {
                graffitsPresenter.IsLoadFile = false;
                this.btnStopLoadFile.Invoke(new Action(() => this.btnStopLoadFile.Enabled = false));
                this.btnLoadFile.Invoke(new Action(() => this.btnLoadFile.Enabled = true));
                this.btnStart.Invoke(new Action(() => this.btnStart.Enabled = true));
                this.status.Invoke(new Action(() => managerControlView
                .StopProgressStatusStrip(1, this.status)));
                
                this.status.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("complete"),
                    0, this.status)));                

            }
        }

        private void ThreadAddImageOfPerson(List<Bitmap> listImage)
        {
            if (!SearchPersonList(Convert.ToInt32(personTransition.Params.Id_face),
                    this.listPersonSlider))
            {
                SetPersonInList();
                
                this.Invoke(new Action(() => this.SetImage(listImage[0])));
            }

            if (personTransition.Params.Register == "0")
            {
                if (!SearchPersonList(Convert.ToInt32(personTransition.Params.Id_face),
                    this.listPersonRegister))
                {
                    if (this.countFlowLayoutControls >= sizeMaxFlowLayout)
                    {
                        this.listPersonRegister.Clear();
                        this.lisTimePerson.Clear();
                    }
                    TimePerson timePerson = new TimePerson();
                    timePerson.id = Convert.ToInt32(personTransition.Params.Id_face);
                    timePerson.income = DateTime.Now;
                    this.lisTimePerson.Add(timePerson);
                    this.listPersonRegister.Add(personTransition);
                    this.AddNewCardPerson(listImage);
                }
                else
                {
                    if (VerifyTimePerson(Convert.ToInt32(personTransition.Params.Id_face)))
                    {
                        this.AddNewCardPerson(listImage);
                    }
                }
                               
            }
        }

        private void AddImageOfPerson(List<Bitmap> listImage)
        {            
            Task t = this.TaskAddImageOfPerson(listImage);
        }

        private bool SearchPersonList(int id, List<Person> people)
        {
            Person personSearch = people
                .FirstOrDefault(item => item.Params.Id_face == id.ToString());
            if (personSearch != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool VerifyTimePerson(int id)
        {
            TimePerson timePerson = this.lisTimePerson
                .FirstOrDefault(item => item.id == id);
            int index = this.lisTimePerson.IndexOf(timePerson);

            if (timePerson != null)
            {
                DateTime now = DateTime.Now;
                TimeSpan ts = now - timePerson.income;
                if (ts.Minutes > Configuration.Instance.TimeRefreshEntryControl)
                {
                    this.lisTimePerson[index].income = now;
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }


        private void SetPersonInList()
        {
            listPersonSlider[indexPerson] = personTransition;
            indexPerson += 1;
            if (indexPerson == queueImage)
            {
                indexPerson = 0;
            }
        }
        private void AddNewCardPerson(List<Bitmap> listImage)
        {
            if (this.countFlowLayoutControls >= sizeMaxFlowLayout)
            {
                this.countFlowLayoutControls = 0;
                this.flowLayoutPanel1.Invoke(new Action(() =>
                this.flowLayoutPanel1.Controls.Clear()));
                Task.Delay(20);
            }

            CardTwoImage cardPerson = new CardTwoImage();
            cardPerson.IdFace = personTransition.Params.Id_face;
            cardPerson.Id = personTransition.Params.Identification;
            cardPerson.FirstName = personTransition.Params.Name;
            cardPerson.LastName = personTransition.Params.Lastname;
            cardPerson.DateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            if (listImage.Count == 2)
            {
                Bitmap imgGallery = findImagePresenter.ResizeBitmap(listImage[0]);
                cardPerson.Photo = imgGallery;
                Bitmap imgCamera = findImagePresenter.ResizeBitmap(listImage[1]);
                cardPerson.PhotoCamera = imgCamera;
            }
            else if (listImage[0] != null)
            {
                Bitmap imgGallery = findImagePresenter.ResizeBitmap(listImage[0]);
                cardPerson.Photo = imgGallery;
            }

            this.flowLayoutPanel1.Invoke(new Action(() => 
            this.flowLayoutPanel1.Controls.Add(cardPerson)));
            this.flowLayoutPanel1.Invoke(new Action(() =>
            this.flowLayoutPanel1.Refresh()));
            this.countFlowLayoutControls++;
        }

        private void AddPersonIndentify(Person person)
        {
            personTransition = person;
            findImagePresenter.GetListImage64ByUser(Convert
                .ToInt16(person.Params.Id_face));

        }

        private void InitCapture()
        {

            VideoCapture captureInit = new VideoCapture(Configuration.Instance.VideoDefault);
            if (captureInit.IsOpened)
            {
                Mat frame = new Mat();
                captureInit.Read(frame);
                totalFrame = captureInit.GetCaptureProperty(CapProp.FrameCount);
                fps = captureInit.GetCaptureProperty(CapProp.Fps);
                graffitsPresenter.SetSequenceFps(Convert.ToInt32(fps));
                graffitsPresenter.SetWidthFrame(Configuration.Instance.ResolutionWidthDefault);
                graffitsPresenter.SetHeightFrame(Configuration.Instance.ResolutionHeightDefault);
                graffitsPresenter.SetClient(LinkVideo);
                graffitsPresenter.SetMinEyeDistance(Configuration.Instance.MinEyeTrack);
                graffitsPresenter.SetMaxEyeDistance(Configuration.Instance.MaxEyeTrack);
                graffitsPresenter.SetFaceConfidenceThresh(Configuration.Instance.ConfidenceTrack);
                graffitsPresenter.SetRefreshInterval(Configuration.Instance.RefreshIntervalTrack);
                graffitsPresenter.SetDeepTrack(Configuration.Instance.DeepTrack);
                graffitsPresenter.SetTrackingMode(Configuration.Instance.TrackMode);
                graffitsPresenter.SetTrackSpeed(Configuration.Instance.TrackSpeed);
                graffitsPresenter.SetMotionOptimization(Configuration.Instance.TrackMotion);
                switch (Configuration.Instance.VideoTypeDefault)
                {
                    case Configuration.VIDEO_TYPE_IP:
                        graffitsPresenter.SetIpCamera(Configuration.Instance.VideoDefault);
                        break;
                    case Configuration.VIDEO_TYPE_FILE:
                        graffitsPresenter.SetFileVideo(Configuration.Instance.VideoDefault);
                        break;
                    case Configuration.VIDEO_TYPE_CAMERA:
                        graffitsPresenter.SetDeviceVideo(Configuration.Instance.VideoDefault);
                        break;

                }
                string nameWindow = "Entry_Control_" + LinkVideo.ToString();
                graffitsPresenter.SetNameWindow(nameWindow);
                graffitsPresenter.SetFlagFlow(false);
                
                captureInit.Dispose();
            }
            else
            {
                this.btnStart.Enabled = false;

                managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("ip_video_empty"),
                    0, this.status);
            }
            
        }       


        private void BringToFrontImageViewer(int position)
        {
            graffitsPresenter.ShowWindow(position);
        }

        private async Task TaskAddImageOfPerson(List<Bitmap> listImage)
        {
            await Task.Run(() =>
            {
                ThreadAddImageOfPerson(listImage);

            });
        }
        
        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Task.Run(() =>
            //{
            //    CaptureFrame();

            //});
            //Thread thr = new Thread(CaptureFrame);
            //thr.Start();
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.btnFrontVideo.Enabled = true;
            this.btnBackVideo.Enabled = true;
            graffitsPresenter.CaptureFlow(Configuration.Instance.VideoTypeDefault);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            graffitsPresenter.StatePlay();
            this.btnStop.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnRestart.Enabled = true;
            this.btnStop.Enabled = false;
            graffitsPresenter.StatePaused();
        }

        private void frmEntryControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                
                if (subscriptionHearUser != null) subscriptionHearUser.Dispose();
                if (subscriptionFindImage != null) subscriptionFindImage.Dispose();
                                
                System.Threading.Thread closeTracking = new System
                    .Threading.Thread(new System.Threading
               .ThreadStart(graffitsPresenter.TerminateTracking));
                closeTracking.Start();
                managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
                managerControlView.EnabledOptionMenu("enrolamientoToolStripMenuItem", mdiMain.NAME);
                managerControlView.EnabledOptionMenu("configuraciónToolStripMenuItem", mdiMain.NAME);
            }
            catch (System.AccessViolationException ex)
            {

                Console.WriteLine(ex.Message);
            }
            

        }

        private void pic1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic1.Width, pic1.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic1.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic2.Width, pic2.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic2.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic3_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic3.Width, pic3.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic3.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic4_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic4.Width, pic4.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic4.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic5_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic5.Width, pic5.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic5.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic6_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic6.Width, pic6.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic6.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic7_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic7.Width, pic7.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic7.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic8_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic8.Width, pic8.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic8.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic9_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic9.Width, pic9.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic9.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void frmEntryControl_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void frmEntryControl_Shown(object sender, EventArgs e)
        {
            SubscriptionReactive();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFrontVideo_Click(object sender, EventArgs e)
        {
            
            BringToFrontImageViewer(HWND_TOPMOST);
        }

        private void btnBackVideo_Click(object sender, EventArgs e)
        {
            
            BringToFrontImageViewer(HWND_BOTTOM);
        }
        
        

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                graffitsPresenter.IsLoadFile = true;
                this.btnLoadFile.Enabled = false;
                this.btnStart.Enabled = false;
                this.btnFrontVideo.Enabled = false;
                this.btnFrontVideo.Enabled = false;
                this.btnStopLoadFile.Enabled = true;
                managerControlView
                    .SetValueTextStatusStrip(StringResource.work,
                    0, this.status);
                managerControlView.StartProgressStatusStrip(1, this.status);
                RequestAipu.Instance.SetIsFinishLoadFiles(true);
                RequestAipu.Instance.ResetCountNotDetect();
                RequestAipu.Instance.ResetLowScore();
                RequestAipu.Instance.ResetCountRepeatUser();
                Task taskRecognition = graffitsPresenter
                    .TaskImageFileForRecognition(openFileDialog.FileNames);

            }
        }

        private void btnStopLoadFile_Click(object sender, EventArgs e)
        {
            graffitsPresenter.CancelLoad = true;
        }
    }

}
