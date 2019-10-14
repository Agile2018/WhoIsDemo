using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reactive.Linq;
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
    public partial class frmEnroll : Form
    {
        #region constants
        private const int queueImage = 9;
        private const int sizeMaxFlowLayout = 30;
        private const int sizeCoordinates = 20;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOACTIVATE = 0x10;
        const int wFlags = SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE;        
        const int HWND_TOPMOST = -1;
        const int HWND_BOTTOM = 1;
        #endregion
        #region variables
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, 
            int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
       
        public string strNameMenu;        
        private int indexPerson = 0;
        //private int countRepeatFrame = 0;
        private int countFlowLayoutControls = 0;
        private float[] coordinatesRectFace;
        private float[] coordinatesVolatile = new float[sizeCoordinates];
        private double totalFrame;
        private double fps;
        private int countNewPerson = 0;        
        private ImageViewer viewer;
        //private int coordinateX1, coordinateY1, rectangleWidth, rectangleHeight;
        private StatusStrip status;
        private Person personTransition = new Person();
        private List<Person> listPersonSlider = new List<Person>();
        ManagerControlView managerControlView = new ManagerControlView();
        HearUserPresenter hearUserPresenter = new HearUserPresenter();
        FindImagePresenter findImagePresenter = new FindImagePresenter();
        HearCoordinatesPresenter hearCoordinatesPresenter = new HearCoordinatesPresenter();
        GraffitsPresenter graffitsPresenter = new GraffitsPresenter();
        IDisposable subscriptionHearUser;
        IDisposable subscriptionFindImage;
        IDisposable subscriptionCoordinates;
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

        VideoCapture capture;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        #endregion
        public frmEnroll()
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

        private void frmEnroll_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.PerformAutoScale();
            this.Top = 0;
            this.Left = 0;
            this.Width = 1205;
            this.Height = 894;
            //this.Left = (int)((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);

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
            RequestAipu.Instance.IsRegister(true);
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
            this.openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            this.openFileDialog.Multiselect = true;
            this.lblQuantityRecords.Text = SynchronizationPeoplePresenter
                .Instance.GetNumbersPersons().ToString();
            
            //if (CudaInvoke.HasCuda == true)
            //{
            //    Console.WriteLine("CUDA EXIST");
            //}
            //else
            //{
            //    Console.WriteLine("CUDA NO EXIST");
            //}

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

            SynchronizationPeoplePresenter.Instance.OnListPeople += new SynchronizationPeoplePresenter
                .ListPeopleDelegate(LoadListSyncUp);
        }

        private void LoadListSyncUp(List<People> list)
        {
            Task taskUploadPeople = TaskUploadPeopleOfDatabase(list);
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
            hearCoordinatesPresenter.EnabledCoordinates(true);
        }

        private void SubscriptionReactive()
        {

            subscriptionFindImage = findImagePresenter.subjectImage.Subscribe(
                image => AddImageOfPerson(image),
                () => Console.WriteLine(StringResource.complete));
            subscriptionHearUser = hearUserPresenter.subjectUser.Subscribe(
                person => AddPersonIndentify(person),
                () => Console.WriteLine(StringResource.complete));
            subscriptionCoordinates = hearCoordinatesPresenter.subjectCoordinates.Subscribe(
                coor => SetCoordinatesFace(coor),
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
                this.lblQuantityRecords.Invoke(new Action(() => this.lblQuantityRecords.Text = SynchronizationPeoplePresenter
                .Instance.GetNumbersPersons().ToString()));
                this.status.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("complete"),
                    0, this.status)));
                int countLowScore = RequestAipu.Instance.GetCountLowScore();
                int countRepeatUser = RequestAipu.Instance.GetCountRepeatUser();
               // int countNotDetect = RequestAipu.Instance.GetCountNotDetect();
                this.lblLowScore.Invoke(new Action(() => this.lblLowScore.Text =
                ManagerResource.Instance.resourceManager
                    .GetString("low_score") + countLowScore.ToString()));

                this.lblRepeated.Invoke(new Action(() => this.lblRepeated.Text =
                ManagerResource.Instance.resourceManager
                    .GetString("repetead_user") + countRepeatUser.ToString()));

                //this.lblNotDetect.Invoke(new Action(() => this.lblNotDetect.Text =
                //"ND: " + countNotDetect.ToString()));

                this.lblLowScore.Invoke(new Action(() => this.lblLowScore.Visible = true));

                this.lblRepeated.Invoke(new Action(() => this.lblRepeated.Visible = true));

                //this.lblNotDetect.Invoke(new Action(() => this.lblNotDetect.Visible = true));

            }
        }

        private void SetCoordinatesFace(float[] coordinateFlow)
        {            
            this.coordinatesRectFace = coordinateFlow;
            Task.Run(() =>
            {
                RefreshRectangle();

            });
        }

        private void ThreadAddImageOfPerson(Bitmap image)
        {
            if (!SearchPersonList(Convert.ToInt32(personTransition.Params.Id_face),
                    this.listPersonSlider))
            {
                SetPersonInList();
                
                this.Invoke(new Action(() => this.SetImage(image)));
            }

            if (personTransition.Params.Register == "1")
            {
                countNewPerson++;                
                this.AddNewCardPerson(image);
                this.lblCountNewPersons.Invoke(new Action(() =>
                this.lblCountNewPersons.Text = countNewPerson.ToString()));
                
            }
        }

        private void AddImageOfPerson(Bitmap image)
        {
            Task t = this.TaskAddImageOfPerson(image);
        }
        private async Task TaskAddImageOfPerson(Bitmap image)
        {
            await Task.Run(() =>
            {
                ThreadAddImageOfPerson(image);

            });
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
        private void SetPersonInList()
        {            
            listPersonSlider[indexPerson] = personTransition;
            indexPerson += 1;
            if (indexPerson == queueImage)
            {
                indexPerson = 0;
            }
        }
        private void AddNewCardPerson(Bitmap image)
        {

            if (this.countFlowLayoutControls >= sizeMaxFlowLayout)
            {
                this.countFlowLayoutControls = 0;
                this.flowLayoutPanel1.Invoke(new Action(() =>
                this.flowLayoutPanel1.Controls.Clear()));
                Task.Delay(20);
            }
            CardPerson cardPerson = new CardPerson();
            cardPerson.IdFace = personTransition.Params.Id_face;
            cardPerson.Id = personTransition.Params.Identification;
            cardPerson.FirstName = personTransition.Params.Name;
            cardPerson.LastName = personTransition.Params.Lastname;
            if (image != null)
            {
                Bitmap imgResize = findImagePresenter.ResizeBitmap(image);
                cardPerson.Photo = imgResize;
            }
            this.flowLayoutPanel1.Invoke(new Action(() =>
            this.flowLayoutPanel1.Controls.Add(cardPerson)));
            this.flowLayoutPanel1.Invoke(new Action(() =>
            this.flowLayoutPanel1.Refresh()));
            this.countFlowLayoutControls++;
        }

        private async Task TaskUploadPeopleOfDatabase(List<People> list)
        {
            await Task.Run(() =>
            {
                UploadPeopleOfDatabase(list);

            });
        }

        private void UploadPeopleOfDatabase(List<People> list)
        {
            this.flpDatabase.Invoke(new Action(() =>
            this.flpDatabase.Controls.Clear()));

            foreach (People people in list)
            {
                AddCardSimple(people);
            }

            
        }

        private void AddCardSimple(People people)
        {
            CardSimple cardSimple = new CardSimple();
            cardSimple.IdFace = people.Id_face;
            cardSimple.NamePerson = people.Name + " " + people.Lastname;
            Bitmap img = findImagePresenter.Base64StringToBitmap(people.Image);
            if (img != null)
            {
                Bitmap imgResize = findImagePresenter.ResizeBitmap(img);
                cardSimple.Photo = imgResize;
            }
            this.flpDatabase.Invoke(new Action(() =>
            this.flpDatabase.Controls.Add(cardSimple)));
        }
       
        private void AddPersonIndentify(Person person)
        {
            personTransition = person;
            findImagePresenter.GetImage64ByUser(Convert
                .ToInt16(person.Params.Id_face));

        }      
        
        public void CaptureFrame()
        {                        
            using (viewer = new ImageViewer()) 
            using (capture = new VideoCapture(Configuration.Instance.VideoDefault)) //create a camera captue
            {
                capture.SetCaptureProperty(CapProp.FrameWidth, Configuration.Instance.Width);
                capture.SetCaptureProperty(CapProp.FrameHeight, Configuration.Instance.Height);
                int wait = graffitsPresenter.SetFps(Convert.ToInt16(fps));
                capture.ImageGrabbed += delegate (object sender, EventArgs e)
                {  
                    Mat frame = new Mat();
                    capture.Retrieve(frame);

                    Mat frameClone = frame.Clone();
                    //Task taskRecognition = graffitsPresenter.TaskImageForRecognition(frameClone);
                    ThreadPool.QueueUserWorkItem(new
                        WaitCallback(graffitsPresenter.WriteImageForRecognition), frameClone);

                    DrawRectangleFace(frame);
                    graffitsPresenter.PutTextInFrame(frame, countNewPerson, fps);
                    viewer.Image = frame;
                    CvInvoke.WaitKey(wait);                    

                };
                
                viewer.ControlBox = false;                                
                viewer.Text = "Video enrolamiento";
                Size sizeViewer = new Size(Configuration.Instance.Width, Configuration.Instance.Height);
                viewer.Size = sizeViewer;
                capture.Start();
                viewer.ShowDialog(); 
                
                
            }
            

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
                Configuration.Instance.CalculeArea();
                graffitsPresenter.DimesionAdjustment(frame.Width, frame.Height);
                graffitsPresenter.ImageScalingAdjustment();
                graffitsPresenter.TextScalingAdjustment();
                Task taskInitTracking = graffitsPresenter.TaskInitTracking();
                captureInit.Dispose();
            }
            else
            {
                this.btnStart.Enabled = false;

                managerControlView
                    .SetValueTextStatusStrip(StringResource.ip_video_empty,
                    0, this.status);
            }

        }      

        private void DrawRectangleFace(Mat img)
        {
            if (this.coordinatesVolatile[0] != 0)
            {
                int indexVolatile = 0;
                int x1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile]);
                int y1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 1]);
                int w = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 2]);
                int h = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 3]);
                Rectangle rectangle = new Rectangle(x1, y1, w, h);
                CvInvoke.Rectangle(img, rectangle, new MCvScalar(255.0, 255.0, 255.0), 2);
            }

            if (this.coordinatesVolatile[4] != 0)
            {
                int indexVolatile = 4;
                int x1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile]);
                int y1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 1]);
                int w = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 2]);
                int h = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 3]);
                Rectangle rectangle = new Rectangle(x1, y1, w, h);
                CvInvoke.Rectangle(img, rectangle, new MCvScalar(255.0, 255.0, 255.0), 2);
            }

            if (this.coordinatesVolatile[8] != 0)
            {
                int indexVolatile = 8;
                int x1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile]);
                int y1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 1]);
                int w = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 2]);
                int h = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 3]);
                Rectangle rectangle = new Rectangle(x1, y1, w, h);
                CvInvoke.Rectangle(img, rectangle, new MCvScalar(255.0, 255.0, 255.0), 2);
            }

            if (this.coordinatesVolatile[12] != 0)
            {
                int indexVolatile = 12;
                int x1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile]);
                int y1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 1]);
                int w = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 2]);
                int h = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 3]);
                Rectangle rectangle = new Rectangle(x1, y1, w, h);
                CvInvoke.Rectangle(img, rectangle, new MCvScalar(255.0, 255.0, 255.0), 2);
            }

            if (this.coordinatesVolatile[16] != 0)
            {
                int indexVolatile = 16;
                int x1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile]);
                int y1 = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 1]);
                int w = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 2]);
                int h = Convert.ToInt16(this.coordinatesVolatile[indexVolatile + 3]);
                Rectangle rectangle = new Rectangle(x1, y1, w, h);
                CvInvoke.Rectangle(img, rectangle, new MCvScalar(255.0, 255.0, 255.0), 2);
            }

        }

        private void RefreshRectangle()
        {
            for (int i = 0; i < sizeCoordinates; i += 4)
            {
                this.coordinatesVolatile[i] = this.coordinatesRectFace[i] * graffitsPresenter.FactorScalingWidth;
                this.coordinatesVolatile[i + 1] = this.coordinatesRectFace[i + 1] * graffitsPresenter.FactorScalingHeight;
                this.coordinatesVolatile[i + 2] = this.coordinatesRectFace[i + 2] * graffitsPresenter.FactorScalingWidth;
                this.coordinatesVolatile[i + 3] = this.coordinatesRectFace[i + 3] * graffitsPresenter.FactorScalingHeight;
                
            }

            //float x1 = this.coordinatesRectFace[0] * graffitsPresenter.FactorScaling;
            //float y1 = this.coordinatesRectFace[1] * graffitsPresenter.FactorScaling;
            //float w = this.coordinatesRectFace[2] * graffitsPresenter.FactorScaling;
            //float h = this.coordinatesRectFace[3] * graffitsPresenter.FactorScaling;


            //coordinateX1 = Convert.ToInt16(x1);
            //coordinateY1 = Convert.ToInt16(y1);
            //rectangleWidth = Convert.ToInt16(w);
            //rectangleHeight = Convert.ToInt16(h);

            //if (this.coordinatesRectFace[0] > 0)
            //{

            //    float x1 = this.coordinatesRectFace[0] * graffitsPresenter.FactorScaling;
            //    float y1 = this.coordinatesRectFace[1] * graffitsPresenter.FactorScaling;
            //    float w = this.coordinatesRectFace[2] * graffitsPresenter.FactorScaling;
            //    float h = this.coordinatesRectFace[3] * graffitsPresenter.FactorScaling;

            //    coordinateX1 = Convert.ToInt16(x1);
            //    coordinateY1 = Convert.ToInt16(y1);
            //    rectangleWidth = Convert.ToInt16(w);
            //    rectangleHeight = Convert.ToInt16(h);

            //}
            //else
            //{
            //    coordinateX1 = 0;
            //    coordinateY1 = 0;
            //    rectangleWidth = 0;
            //    rectangleHeight = 0;
            //}
        }
        

        #endregion

        private void BringToFrontImageViewer(IntPtr handle, int position)
        {
            SetWindowPos(handle, position, 0, 0, 0, 0, wFlags); 
        }

        private void frmEnroll_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (capture != null && capture.IsOpened)
                {
                    capture.Stop();
                    Task.Delay(300).Wait();
                    this.capture.Dispose();

                }

                if (viewer != null)
                {
                    this.viewer.Invoke(new Action(() => this.viewer.Close()));
                }

                if (graffitsPresenter.IsLoadFile)
                {
                    graffitsPresenter.IsLoadFile = false;
                    graffitsPresenter.CancelLoad = true;
                    Task.Delay(300).Wait();
                }
                
                graffitsPresenter.ResetIdUser();
                hearCoordinatesPresenter.EnabledCoordinates(false);
                if (subscriptionHearUser != null) subscriptionHearUser.Dispose();
                if (subscriptionFindImage != null) subscriptionFindImage.Dispose();
                if (subscriptionCoordinates != null) subscriptionCoordinates.Dispose();
                if (subscriptionGraffits != null) subscriptionGraffits.Dispose();
                System.Threading.Thread closeTracking = new System
                    .Threading.Thread(new System.Threading
               .ThreadStart(graffitsPresenter.TerminateTracking));
                closeTracking.Start();
                
                managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
                managerControlView.EnabledOptionMenu("controlDeEntradaToolStripMenuItem", mdiMain.NAME);
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

        private void frmEnroll_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void frmEnroll_Shown(object sender, EventArgs e)
        {
            SubscriptionReactive();
            Task taskLoadPeoples = SynchronizationPeoplePresenter.Instance.TaskLoadPeoples();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnRestart.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnLoadFile.Enabled = true;
            capture.Stop();
            //isStopFrame = true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            capture.Start();
            //isStopFrame = false;
            this.btnStop.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                CaptureFrame();
                
            });
            this.btnLoadFile.Enabled = false;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.btnFrontVideo.Enabled = true;
            this.btnBackVideo.Enabled = true;
            this.lblFiles.Visible = false;
            this.lblLowScore.Visible = false;
            this.lblRepeated.Visible = false;
            this.lblNotDetect.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //isStopFrame = false;
            this.Close();
        }

        private void btnFrontVideo_Click(object sender, EventArgs e)
        {
            this.viewer.Invoke(new Action(() => BringToFrontImageViewer(this.viewer.Handle, 
                HWND_TOPMOST)));
        }

        private void btnBackVideo_Click(object sender, EventArgs e)
        {
            this.viewer.Invoke(new Action(() => BringToFrontImageViewer(this.viewer.Handle,
                HWND_BOTTOM)));
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog.ShowDialog() == DialogResult.OK)
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
                this.lblRepeated.Visible = false;
                this.lblLowScore.Visible = false;
                this.lblNotDetect.Visible = false;
                this.lblFiles.Visible = true;
                this.lblFiles.Text = ManagerResource.Instance.resourceManager
                    .GetString("files") + openFileDialog.FileNames.Count().ToString();
                managerControlView.StartProgressStatusStrip(1, this.status);
                RequestAipu.Instance.WorkMode(1);
                RequestAipu.Instance.ResetCountRepeatUser();
                RequestAipu.Instance.ResetLowScore();
                Task taskRecognition = graffitsPresenter
                    .TaskImageFileForRecognition(openFileDialog.FileNames);

            }
        }

        private void btnStopLoadFile_Click(object sender, EventArgs e)
        {
            graffitsPresenter.CancelLoad = true;
        }

        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.Refresh();
        }          

        private void flpDatabase_Scroll(object sender, ScrollEventArgs e)
        {
            //Console.WriteLine(flpDatabase.VerticalScroll.Maximum);
            //Console.WriteLine(e.NewValue);
            //Console.WriteLine(e.OldValue);
            
            flpDatabase.Refresh();

        }

        private void btnDownRecords_Click(object sender, EventArgs e)
        {
            SynchronizationPeoplePresenter.Instance.GetListPeople(true);
        }

        private void btnUploadRecords_Click(object sender, EventArgs e)
        {
            SynchronizationPeoplePresenter.Instance.GetListPeople(false);
        }
    }
}
