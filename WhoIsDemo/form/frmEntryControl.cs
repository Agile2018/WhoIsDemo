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
        private ImageViewer viewer;
        //private int coordinateX1, coordinateY1, rectangleWidth, rectangleHeight;
        private StatusStrip status;
        private Person personTransition = new Person();
        private List<Person> listPersonSlider = new List<Person>();
        private List<Person> listPersonRegister = new List<Person>();
        private List<TimePerson> lisTimePerson = new List<TimePerson>();
        ManagerControlView managerControlView = new ManagerControlView();
        HearUserPresenter hearUserPresenter = new HearUserPresenter();
        FindImagePresenter findImagePresenter = new FindImagePresenter();
        HearCoordinatesPresenter hearCoordinatesPresenter = new HearCoordinatesPresenter();
        GraffitsPresenter graffitsPresenter = new GraffitsPresenter();
        IDisposable subscriptionHearUser;
        IDisposable subscriptionFindImage;
        IDisposable subscriptionCoordinates;
        
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
            hearCoordinatesPresenter.EnabledCoordinates(true);
        }

        private void SubscriptionReactive()
        {

            subscriptionFindImage = findImagePresenter.subjectListImage.Subscribe(
                list => AddImageOfPerson(list),
                () => Console.WriteLine(StringResource.complete));
            subscriptionHearUser = hearUserPresenter.subjectUser.Subscribe(
                person => AddPersonIndentify(person),
                () => Console.WriteLine(StringResource.complete));
            subscriptionCoordinates = hearCoordinatesPresenter.subjectCoordinates.Subscribe(
                coor => SetCoordinatesFace(coor),
                () => Console.WriteLine(StringResource.complete));
        }

        private void SetCoordinatesFace(float[] coordinateFlow)
        {
            this.coordinatesRectFace = coordinateFlow;
            Task.Run(() =>
            {
                RefreshRectangle();

            });
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
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("ip_video_empty"),
                    0, this.status);
            }
            
        }       

        private void CaptureFrame()
        {
            using (viewer = new ImageViewer())
            using (capture = new VideoCapture(Configuration.Instance.VideoDefault)) 
            {
                capture.SetCaptureProperty(CapProp.FrameWidth, Configuration.Instance.Width);
                capture.SetCaptureProperty(CapProp.FrameHeight, Configuration.Instance.Height);
                int wait = graffitsPresenter.SetFps(Convert.ToInt16(fps));
                capture.ImageGrabbed += delegate (object sender, EventArgs e)
                {
                    Mat frame = new Mat();
                    capture.Retrieve(frame);

                    Mat frameClone = frame.Clone();

                    //Task taskTracking = graffitsPresenter.TaskTracking(frameClone);
                    //Task taskRecognition = graffitsPresenter.TaskImageForRecognition(frameClone);
                    ThreadPool.QueueUserWorkItem(new
                        WaitCallback(graffitsPresenter.WriteImageForRecognition), frameClone);
                    DrawRectangleFace(frame);
                    graffitsPresenter.PutTextInFrame(frame, listPersonRegister.Count, fps);
                    viewer.Image = frame;
                    CvInvoke.WaitKey(wait);
                    
                };

                viewer.ControlBox = false;
                viewer.Text = "Video control de entrada";
                Size sizeViewer = new Size(Configuration.Instance.Width, Configuration.Instance.Height);
                viewer.Size = sizeViewer;                
                capture.Start();
                viewer.ShowDialog();


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

            //if (this.coordinatesRectFace[0] > 0)
            //{

            //    float x1 = this.coordinatesRectFace[0] * graffitsPresenter.FactorScaling;
            //    float y1 = this.coordinatesRectFace[1] * graffitsPresenter.FactorScaling;
            //    float w = this.coordinatesRectFace[2] * graffitsPresenter.FactorScaling;
            //    float h = this.coordinatesRectFace[3] * graffitsPresenter.FactorScaling;

            //    if (this.coordinatesVolatile[0] == x1 &&
            //        this.coordinatesVolatile[1] == y1)
            //    {
            //        this.countRepeatFrame += 1;
            //    }
            //    else
            //    {
            //        this.coordinatesVolatile[0] = x1;
            //        this.coordinatesVolatile[1] = y1;
            //        this.countRepeatFrame = 0;
            //    }


            //    Console.WriteLine(x1 + ", " + y1 + ", " + w + ", " + h);
            //    if (this.countRepeatFrame < 3)
            //    {
            //        try
            //        {
            //            Rectangle rectangle = new Rectangle(Convert.ToInt32(x1),
            //            Convert.ToInt32(y1),
            //            Convert.ToInt32(w), Convert.ToInt32(h));
            //            CvInvoke.Rectangle(img, rectangle, new MCvScalar(255.0, 255.0, 255.0), 2);
            //        }
            //        catch (Exception ex)
            //        {

            //            Console.WriteLine("Error Rectangle dimension " + ex.Message);
            //        }

            //    }


            //}

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
        }

        private void BringToFrontImageViewer(IntPtr handle, int position)
        {
            SetWindowPos(handle, position, 0, 0, 0, 0, wFlags);
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
            Task.Run(() =>
            {
                CaptureFrame();

            });
            //Thread thr = new Thread(CaptureFrame);
            //thr.Start();
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.btnFrontVideo.Enabled = true;
            this.btnBackVideo.Enabled = true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            capture.Start();            
            this.btnStop.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnRestart.Enabled = true;
            this.btnStop.Enabled = false;            
            capture.Stop();
        }

        private void frmEntryControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.capture != null && this.capture.IsOpened)
                {
                    capture.Stop();
                    Task.Delay(300).Wait();                    
                    this.capture.Dispose();                    
                }
                if (viewer != null)
                {
                    this.viewer.Invoke(new Action(() => this.viewer.Close()));
                }
                graffitsPresenter.ResetIdUser();
                hearCoordinatesPresenter.EnabledCoordinates(false);
                if (subscriptionHearUser != null) subscriptionHearUser.Dispose();
                if (subscriptionFindImage != null) subscriptionFindImage.Dispose();
                if (subscriptionCoordinates != null) subscriptionCoordinates.Dispose();                
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
            this.viewer.Invoke(new Action(() => BringToFrontImageViewer(this.viewer.Handle,
                HWND_TOPMOST)));
        }

        private void btnBackVideo_Click(object sender, EventArgs e)
        {
            this.viewer.Invoke(new Action(() => BringToFrontImageViewer(this.viewer.Handle,
                HWND_BOTTOM)));
        }
    }

}
