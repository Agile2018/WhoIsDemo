using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.form;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.view
{
    class IdentifyView
    {
        #region constant
        private const int queueImage = 7;
        private const int quantityOfImagesSaved = 4; // index = 0  so 5 number primus
        private const int zero = 0;
        #endregion
        #region variables
        readonly Form form;
        readonly SplitContainer splitContainer;
        //readonly PictureBox pibVideo;
        readonly Button btnStart;
        readonly Button btnStop;
        readonly Button btnRestart;
        readonly Button btnClose;
        readonly DataGridView dgvImages;
        readonly DataGridView dgvRepeat;
        readonly DataGridView dgvNew;
        readonly Emgu.CV.UI.ImageBox imbVideo;

        private StatusStrip status;
        private List<Person> listPersonSlider = new List<Person>();
        private List<Person> listPersonRepeat = new List<Person>();
        private List<Person> listPersonNew = new List<Person>();
        ManagerControlView managerControlView = new ManagerControlView();
        CreateVideoPresenter createVideoPresenter = new CreateVideoPresenter();
        LoadVideoPresenter loadVideoPresenter = new LoadVideoPresenter();
        HearInvalidPresenter hearInvalidPresenter = new HearInvalidPresenter();
        HearUserPresenter hearUserPresenter = new HearUserPresenter();
        FindImagePresenter findImagePresenter = new FindImagePresenter();

        IDisposable subscriptionCreateVideo;
        IDisposable subscriptionHearInvalid;
        IDisposable subscriptionHearUser;
        IDisposable subscriptionFindImage;
        private int linkVideo;

        public int LinkVideo { get => linkVideo; set => linkVideo = value; }
        public string IpVideo { get => ipVideo; set => ipVideo = value; }

        VideoCapture capture;
        
        private string pathImageTemp = Application.StartupPath + "\\camera1\\"; //temp.png
        
        private int indexCell = zero;
        private int indexImage = zero;
        private Person personTransition = new Person();                   
        private bool flagProccessSave = false;
        private int rowRepeatPerson = 0;
        private int colummRepeatPerson = 0;
        private int rowNewPerson = 0;
        private int colummNewPerson = 0;
        private string ipVideo;
        #endregion

        #region methods
        public IdentifyView(Form workForm)
        {
            
            this.form = (frmIdentify)workForm;
           
            this.splitContainer = managerControlView.GetControlSplitContainerThisForm(
                this.form, "splitContainer");
            //this.pibVideo = managerControlView.GetControlPictureBoxThisSplitContainer(
            //    this.splitContainer, "pibVideo");
            this.btnStart = managerControlView.GetControlButtonThisSplitContainer(
                this.splitContainer, "btnStart");
            this.btnStop = managerControlView.GetControlButtonThisSplitContainer(
                this.splitContainer, "btnStop");
            this.btnRestart = managerControlView.GetControlButtonThisSplitContainer(
                this.splitContainer, "btnRestart");
            this.btnClose = managerControlView.GetControlButtonThisSplitContainer(
                this.splitContainer, "btnClose");
            this.dgvImages = managerControlView.GetControlDataGridViewThisSplitContainer(
                this.splitContainer, "dgvImages");
            this.dgvRepeat = managerControlView.GetControlDataGridViewThisSplitContainerPanel2(
                this.splitContainer, "dgvRepeat");
            this.dgvNew = managerControlView.GetControlDataGridViewThisSplitContainerPanel2(
                this.splitContainer, "dgvNew");
            this.imbVideo = managerControlView.GetControlImageBoxThisSplitContainer(
                this.splitContainer, "imbVideo");
            this.dgvRepeat.CellDoubleClick += new System.Windows
                .Forms.DataGridViewCellEventHandler(this.dgvRepeat_CellDoubleClick);
            this.dgvNew.CellDoubleClick += new System.Windows
                .Forms.DataGridViewCellEventHandler(this.dgvNew_CellDoubleClick);
            this.dgvRepeat.CellFormatting += new System.Windows
                .Forms.DataGridViewCellFormattingEventHandler(this.dgvRepeat_CellFormatting);

            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnStart.MouseDown += new System.Windows.Forms
                .MouseEventHandler(this.btnStart_MouseDown);
            this.form.FormClosing += new System.Windows
                .Forms.FormClosingEventHandler(this.frmIdentify_FormClosing);
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
            
            SubscriptionReactive();            
            ConnectDatabase();
            InitListPerson();
            Cursor.Current = Cursors.Default;
            //createVideoPresenter.ExecuteCreate();
        }

        private void SubscriptionReactive()
        {
            subscriptionCreateVideo = createVideoPresenter.subjectIndex.Subscribe(
                index => LaunchLoadVideo(index),
                () => Console.WriteLine(StringResource.complete));
            subscriptionFindImage = findImagePresenter.subjectImage.Subscribe(
                image => InvokeGridForImage(image),
                () => Console.WriteLine(StringResource.complete));
            
        }

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
       
        private void LaunchLoadVideo(int indexObserver)
        {
            LinkVideo = indexObserver;
            this.hearInvalidPresenter = new HearInvalidPresenter(indexObserver);
            this.hearUserPresenter = new HearUserPresenter(indexObserver);
            PostSubscriptionReactive();
            loadVideoPresenter.IndexVideo = indexObserver;
            loadVideoPresenter.NameFile = "directory1.txt";
            loadVideoPresenter.ExecuteLoadVideo();
            ExecuteVideo();
            Cursor.Current = Cursors.Default;
            managerControlView.StopProgressStatusStrip(1, this.status);
        }

        private void InvokeGridForImage(Bitmap image)
        {
            
            this.form.Invoke(new Action(() => this.SetImageInGrid(image)));
        }

        public Person GetPersonOfList(string id, List<Person> people)
        {
            return people
                .FirstOrDefault(item => item.Params.Id_face == id);

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
        private void SetImageInGrid(Bitmap image)
        {
            if (image != null)
            {
                
                if (!SearchPersonList(Convert.ToInt32(personTransition.Params.Id_face),
                    this.listPersonSlider))
                {
                    
                    AddPersonSlider(image);
                }
                if (personTransition.Params.Register == "1")
                {
                    AddPersonGrid(this.dgvNew, ref this.colummNewPerson, 
                        ref this.rowNewPerson, image, 
                        personTransition.Params.Id_face, this.listPersonNew);
                    
                }
                else if(!SearchPersonList(Convert.ToInt32(personTransition.Params.Id_face),
                    this.listPersonRepeat) && !SearchPersonList(Convert.ToInt32(personTransition.Params.Id_face),
                    this.listPersonNew))
                {
                    AddPersonGrid(this.dgvRepeat, ref this.colummRepeatPerson,
                        ref this.rowRepeatPerson, image, 
                        personTransition.Params.Id_face, this.listPersonRepeat);
                    
                }

            }
        }
        private void AddPersonSlider(Bitmap image)
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            if (this.dgvImages.Columns.Count < queueImage) this.dgvImages.Columns.Add(img);
            if (this.dgvImages.Rows.Count == 0) this.dgvImages.Rows.Add();
            this.dgvImages.Rows[zero].Cells[indexCell].Value = image;
            this.dgvImages.AutoResizeColumn(indexCell);
            this.dgvImages.AutoResizeRow(zero);
            listPersonSlider[indexCell] = personTransition;
            indexCell += 1;
            if (indexCell == queueImage)
            {
                indexCell = 0;
            }
        }

        private void AddPersonGrid(DataGridView dataGrid, ref int columm, 
            ref int row, Bitmap image, string idFace, List<Person> people)
        {
            people.Add(personTransition);
            Bitmap imgResize = findImagePresenter.ResizeBitmap(image);
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            if (dataGrid.Columns.Count < 3)
            {
                dataGrid.Columns.Add(img);
            }

            if (dataGrid.Rows.Count == 0)
            {
                dataGrid.Rows.Add();
            }
            else if (columm == 0) 
            {
                dataGrid.Rows.Add();
            }

            dataGrid.Rows[row].Cells[columm].Value = imgResize;
            dataGrid.Rows[row].Cells[columm].Tag = idFace;
            dataGrid.AutoResizeColumn(columm);
            dataGrid.AutoResizeRow(row);
            
            columm += 1;

            if (columm > 2)
            {
                columm = 0;
                row += 1;
                
            }

        }
  
        private void ExecuteVideo()
        {
            Task t = this.RunVideo();
            if (t.IsCompleted)
            {
                t.Dispose();

            }
        }

        private async Task CreateVideo()
        {
            await Task.Factory.StartNew(() =>
                 this.status.Invoke(new Action(() => 
                 createVideoPresenter.ExecuteCreate())));
            
        }
        private async Task RunVideo()
        {
            await Task.Factory.StartNew(() =>
                 loadVideoPresenter.RunVideo());

        }
        private void PostSubscriptionReactive()
        {
            
            subscriptionHearInvalid = hearInvalidPresenter.subjectError.Subscribe(
                result => LaunchMessage(result),
                () => Console.WriteLine(StringResource.complete));
            subscriptionHearUser = hearUserPresenter.subjectUser.Subscribe(
                person => AddPersonIndentify(person),
                () => Console.WriteLine(StringResource.complete));

        }

        private void LaunchMessage(string result)
        {
            
            this.status.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(result, 0, this.status)));
        }

        private void AddPersonIndentify(Person person)
        {                       
            
            personTransition = person;
            findImagePresenter.GetImage64ByUser(Convert.ToInt16(person.Params.Id_face));            
        }

        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            managerControlView.StartProgressStatusStrip(1, this.status);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!string.IsNullOrEmpty(IpVideo))
            {
                InitCapture();
                Task t = this.CreateVideo();
                if (t.IsCompleted)
                {
                    t.Dispose();

                }
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                managerControlView
                    .SetValueTextStatusStrip(StringResource.ip_video_empty, 0, this.status);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.form.Close();          
            
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            capture.Start();
            ExecuteVideo();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnRestart.Enabled = true;
            CaptureStop();
        }

        private void dgvRepeat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDataPerson frmwork = new frmDataPerson();
            string idFace = Convert.ToString(this
                .dgvRepeat.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag);
            frmwork.person = GetPersonOfList(idFace, this.listPersonRepeat);
            if (frmwork.person != null)
            {
                frmwork.ShowDialog();
            }
        }

        private void dgvNew_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDataPerson frmwork = new frmDataPerson();
            string idFace = Convert.ToString(this
                .dgvNew.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag);
            frmwork.person = GetPersonOfList(idFace, this.listPersonNew);
            if (frmwork.person != null)
            {
                frmwork.ShowDialog();
            }
            
        }

        private void dgvRepeat_CellFormatting(object sender, 
            DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = this.dgvRepeat
                .Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Tag != null)
            {
                Person person = GetPersonOfList(Convert.ToString(cell.Tag), 
                    this.listPersonRepeat);
                if (person != null)
                {
                    string perfil = string.Format("Nombre: {0} \n Identidad: {1}",
                    person.Params.Name, person.Params.Address);
                    cell.ToolTipText = perfil;
                }
                
            }
        }

        private void InitCapture()
        {
            //capture = new VideoCapture("rtsp://root:admin@192.168.0.10:554/axis-media/media.amp?videocodec=h264&resolution=640x480");
            capture = new VideoCapture(IpVideo);
            Size size = new Size(640, 480);
            //capture = new VideoCapture("rtsp://admin:admin@192.168.0.10:554?resolution=640x480");
            //capture = new VideoCapture("video.mp4");
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, size.Width);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, size.Height);
            capture.ImageGrabbed += ProcessFrame;
            
            //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 40);            
            if (capture != null)
            {
                try
                {
                    //fps = capture.GetCaptureProperty(CapProp.Fps);
                    
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
                try
                {
                    Mat frame = new Mat();
                    if (capture.Retrieve(frame, 0))
                    {
                        this.imbVideo.Image = frame;                        
                        //GC.SuppressFinalize(bitmap);
                        LaunchThreadSaveImage(frame);
                        CvInvoke.WaitKey(1);
                        

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
        }  

        private void LaunchThreadSaveImage(Mat img)
        {
            if (!flagProccessSave)
            {
                Mat clone = img.Clone();
                flagProccessSave = true;
                Task t = this.TaskWriteImage(clone);
                if (t.IsCompleted)
                {
                    t.Dispose();
                    
                }
            }
 
        }
        private void ConnectDatabase()
        {
            findImagePresenter.Connection = "mongodb://localhost:27017";
            findImagePresenter.NameDatabase = "dbass";
            findImagePresenter.Connect();
        }

        private async Task TaskWriteImage(Mat img)
        {
            await Task.Factory.StartNew(() =>
                 WriteImage(img));
        }

        private void WriteImage(Mat img)
        {                        
            
            DateTime start;
            TimeSpan time;
               
            string name = "temp" + indexImage.ToString() + ".png";
            string fullName = pathImageTemp + name;
            start = DateTime.Now;
            try
            {
                CvInvoke.Imwrite(fullName, img);
                time = DateTime.Now - start;
                Console.WriteLine(String.Format("{0}.{1} Index: {2}",
                    time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0'), indexImage));
                SetIndexImage(indexImage);
                //SetLapseWriteImage(time.Milliseconds);
            }
            catch (Exception ex)
            {

                this.status.Invoke(new Action(() => managerControlView
                .SetValueTextStatusStrip(ex.Message, 0, this.status)));
            }
                
            ResetIndexImage();
                
            flagProccessSave = false;
            

        }

        private void ResetIndexImage()
        {
            if (indexImage == quantityOfImagesSaved)
            {                
                indexImage = zero;
            }
            else
            {
                indexImage += 1;
            }
        }
        public void CaptureStop()
        {
            capture.Stop();
            loadVideoPresenter.StopVideo();
        }

        public void frmIdentify_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (this.capture != null && this.capture.IsOpened)
            {
                this.capture.Pause();
                CaptureStop();
                Task.Delay(300).Wait();
                this.imbVideo.Invoke(new Action(() =>
                        this.imbVideo.Dispose()));
                this.capture.Dispose();
                loadVideoPresenter.RemoveVideo();
                subscriptionCreateVideo.Dispose();
                subscriptionHearInvalid.Dispose();
                subscriptionHearUser.Dispose();
                subscriptionFindImage.Dispose();
                
            }
            managerControlView.EnabledOptionMenu((this.form as frmIdentify)
                    .strNameMenu, mdiMain.NAME);
            this.form.Dispose();
        }

        private void SetIndexImage(int index)
        {
            if (loadVideoPresenter.IsRunVideo)
            {

                loadVideoPresenter.IndexWriteImage(index);
            }

        }
        private void SetLapseWriteImage(int timeCurrent)
        {
            if (loadVideoPresenter.IsRunVideo)
            {
                
                loadVideoPresenter.LapseRead(timeCurrent);
            }

        }
        #endregion
    }
}
