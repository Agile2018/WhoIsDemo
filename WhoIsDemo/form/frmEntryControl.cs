using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
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
        #endregion

        #region variables
        //EnrollPresenter enrollPresenter = new EnrollPresenter();
        public string strNameMenu;
        private bool flagProccessSave = false;
        private int indexPerson = 0;
        private StatusStrip status;
        private Person personTransition = new Person();
        private List<Person> listPersonSlider = new List<Person>();
        private List<Person> listPersonRegister = new List<Person>();
        ManagerControlView managerControlView = new ManagerControlView();
        HearUserPresenter hearUserPresenter = new HearUserPresenter();
        FindImagePresenter findImagePresenter = new FindImagePresenter();

        IDisposable subscriptionHearUser;
        IDisposable subscriptionFindImage;

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
            this.Width = 1203;
            this.Height = 818;
            this.Left = (int)((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);

            InitControls();
            InitListPerson();            
            EnableObserverUser();            
            ConnectDatabase();

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }

        private void ConnectDatabase()
        {
            findImagePresenter.Connect();
        }

        private void EnableObserverUser()
        {
            if (!hearUserPresenter.EnableObserverUser())
            {
                managerControlView.SetValueTextStatusStrip(
                    StringResource.load_library, 0, this.status);

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

        }

        private void ThreadAddImageOfPerson(List<Bitmap> listImage)
        {
            if (!SearchPersonList(Convert.ToInt32(personTransition.Params.Id_face),
                    this.listPersonSlider))
            {
                SetPersonInList();
                //this.SetImage(listImage[0]);
                this.Invoke(new Action(() => this.SetImage(listImage[0])));
            }

            if (personTransition.Params.Register == "0" && !SearchPersonList(Convert.ToInt32(personTransition.Params.Id_face),
                    this.listPersonRegister))
            {
                this.listPersonRegister.Add(personTransition);
                
                this.AddNewCardPerson(listImage);
                //this.Invoke(new Action(() => this.AddNewCardPerson(listImage)));
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
            CardTwoImage cardPerson = new CardTwoImage();
            cardPerson.IdFace = personTransition.Params.Id_face;
            cardPerson.Id = personTransition.Params.Identification;
            cardPerson.FirstName = personTransition.Params.Name;
            cardPerson.LastName = personTransition.Params.Lastname;
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
            //flowLayoutPanel1.Controls.Add(cardPerson);
        }

        private void AddPersonIndentify(Person person)
        {
            personTransition = person;
            findImagePresenter.GetListImage64ByUser(Convert
                .ToInt16(person.Params.Id_face));

        }

        private void InitCapture()
        {

            capture = new VideoCapture(Configuration.Instance.VideoDefault);
            capture.ImageGrabbed += ProcessFrame;

            if (capture != null)
            {
                try
                {

                    capture.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (capture != null && capture.Ptr != IntPtr.Zero)
            {

                CaptureFrame();
            }
        }

        private void CaptureFrame()
        {
            Mat frame = new Mat();
            try
            {
                if (capture.Retrieve(frame, 0))
                {
                    this.imbVideo.Invoke(new Action(() =>
                    this.imbVideo.Image = frame));


                }
                if (!flagProccessSave && frame != null)
                {
                    Task t = this.TaskWriteImage(frame);
                }

            }
            catch (System.InvalidOperationException ex)
            {
                this.status.Invoke(new Action(() => managerControlView
                .SetValueTextStatusStrip(ex.Message, 0, this.status)));
            }
            catch (System.AccessViolationException ex)
            {
                this.status.Invoke(new Action(() => managerControlView
                .SetValueTextStatusStrip(ex.Message, 0, this.status)));
            }

        }

        private async Task TaskAddImageOfPerson(List<Bitmap> listImage)
        {
            await Task.Run(() =>
            {
                ThreadAddImageOfPerson(listImage);

            });
        }
        private async Task TaskWriteImage(Mat img)
        {


            await Task.Run(() =>
            {
                LaunchThreadSaveImage(img);

            });

        }

        private void LaunchThreadSaveImage(Mat img)
        {
            flagProccessSave = true;
            WriteImage(img);

        }

        private void WriteImage(Mat img)
        {
            Mat clone = img.Clone();
            CvInvoke.Resize(clone, clone, new Size(Configuration.Instance.Width,
                Configuration.Instance.Height)); //  320, 240 640, 480

            int length = clone.Width * clone.Height * clone.NumberOfChannels;
            byte[] data = new byte[length];

            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            using (Mat m2 = new Mat(clone.Size, DepthType.Cv8U, clone.NumberOfChannels,
                handle.AddrOfPinnedObject(), clone.Width * clone.NumberOfChannels))
                CvInvoke.BitwiseNot(clone, m2);
            handle.Free();

            RequestAipu.Instance.SendFrame(data, clone.Height,
                clone.Width, LinkVideo);
            clone.Dispose();
            flagProccessSave = false;
        }


        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Configuration.Instance.VideoDefault))
            {
                InitCapture();

                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                managerControlView
                    .SetValueTextStatusStrip(StringResource.ip_video_empty,
                    0, this.status);
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            capture.Start();

            btnStop.Enabled = true;
            btnRestart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnRestart.Enabled = true;
            btnStop.Enabled = false;
            capture.Stop();
        }

        private void frmEntryControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.capture != null && this.capture.IsOpened)
            {
                capture.Stop();
                Task.Delay(300).Wait();
                this.imbVideo.Invoke(new Action(() =>
                        this.imbVideo.Dispose()));
                this.capture.Dispose();

                if (subscriptionHearUser != null) subscriptionHearUser.Dispose();
                if (subscriptionFindImage != null) subscriptionFindImage.Dispose();
            }
            managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);

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
    }

}
