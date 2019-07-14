using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.presenter;
using System.Windows.Forms;
using WhoIsDemo.view.tool;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.model;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WhoIsDemo.domain.interactor;

namespace WhoIsDemo.view
{
    class MainView
    {
        #region constants
        private const string LABEL_MESSAGE_ERROR = "label1";
        private const string TXT_ID = "txtId";
        private const string TXT_NAME = "txtName";
        private const string TXT_ADDRESS = "txtAddress";
        private const string PIC_PHOTO = "picPhoto";
        private const string BTN_SAVE = "btnSave"; 
        #endregion
        #region variables
        readonly Form form;
        CreateVideoPresenter createVideoPresenter = new CreateVideoPresenter();
        LoadVideoPresenter loadVideoPresenter = new LoadVideoPresenter();
        HearInvalidPresenter hearInvalidPresenter;
        HearUserPresenter hearUserPresenter;
        //HearFramePresenter hearFramePresenter;
        ManagerControlView managerControlView = new ManagerControlView();
        //TestFrame testFrame;
        IDisposable subscriptionCreateVideo;
        IDisposable subscriptionHearInvalid;
        IDisposable subscriptionHearUser;
        //IDisposable subscriptionHearFrame;
        readonly Label labelMessageError;
        readonly TextBox txtId;
        readonly TextBox txtName;
        readonly TextBox txtAddress;
        readonly PictureBox picPhoto;
        readonly Button btnSave;
        private int linkVideo;

        public int LinkVideo { get => linkVideo; set => linkVideo = value; }
        #endregion

        #region methods
        public MainView(Form workForm)
        {
            this.form = (mdiMain)workForm;
            this.labelMessageError = managerControlView
                .GetControlLabelThisForm(this.form, LABEL_MESSAGE_ERROR);
            this.txtId = managerControlView.GetControlTextThisForm(this.form, TXT_ID);
            this.txtName = managerControlView.GetControlTextThisForm(this.form, TXT_NAME);
            this.txtAddress = managerControlView.GetControlTextThisForm(this.form, TXT_ADDRESS);
            this.picPhoto = managerControlView.GetControlPictureBoxThisForm(this.form, PIC_PHOTO);
            //this.btnSave = managerControlView.GetControlButtonThisForm(this.form, BTN_SAVE);
            //this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            SubscriptionReactive();
            createVideoPresenter.ExecuteCreate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Bitmap img = testFrame.GetFrame();
            //img.Save("end.bmp");
            //this.picPhoto.Image = img;
        } 

        private void SubscriptionReactive()
        {
            subscriptionCreateVideo = createVideoPresenter.subjectIndex.Subscribe(
                index => LaunchLoadVideo(index),
                () => Console.WriteLine(StringResource.complete));
        }


        private void LaunchLoadVideo(int indexObserver)
        {
            LinkVideo = indexObserver;
            hearInvalidPresenter = new HearInvalidPresenter(indexObserver);
            //hearUserPresenter = new HearUserPresenter(indexObserver);
            //testFrame = new TestFrame(indexObserver);

            //hearFramePresenter = new HearFramePresenter(indexObserver);
            PostSubscriptionReactive();
            loadVideoPresenter.IndexVideo = indexObserver;
            loadVideoPresenter.NameFile = "directory1.txt";
            loadVideoPresenter.ExecuteLoadVideo();
            ExecuteVideo();
        }

        private void ExecuteVideo()
        {
            //Task t = this.RunVideo();
            //if (t.IsCompleted)
            //{
            //    t.Dispose();

            //}
        }

        //private async Task RunVideo()
        //{
        //    await Task.Factory.StartNew(() =>
        //         loadVideoPresenter.RunVideo());

        //}

        private void PostSubscriptionReactive()
        {
            subscriptionHearInvalid = hearInvalidPresenter.subjectError.Subscribe(
                result => LaunchMessage(result, this.labelMessageError),
                () => Console.WriteLine(StringResource.complete));
            subscriptionHearUser = hearUserPresenter.subjectUser.Subscribe(
                person => SetControlsUser(person),
                () => Console.WriteLine(StringResource.complete));
            //subscriptionHearFrame = hearFramePresenter.subjectFrame.Subscribe(
            //    image => SetImageControl(image),
            //    () => Console.WriteLine(StringResource.complete));
        }

        private void LaunchMessage(string message, Label label)
        {
            label.Invoke(new Action(() => label.Text = message));
        }

        private void SetControlsUser(Person user)
        {
            this.txtId.Invoke(new Action(() => this.txtId.Text = user.Params.Id_face));
            this.txtName.Invoke(new Action(() => this.txtName.Text = user.Params.Name));
            this.txtAddress.Invoke(new Action(() => this.txtAddress.Text = user.Params.Address));
            this.picPhoto.Invoke(new Action(() => this
            .picPhoto.ImageLocation = Application.StartupPath + "\\camera1\\imgCrop.png"));
        }

        //private void SetImageControl(Bitmap image)
        //{
        //    try
        //    {

        //        //this.picPhoto.Invoke(new Action(() => this
        //        //.picPhoto.Image = image));
        //        //this.picPhoto.Invoke(new Action(() => this
        //        //.picPhoto.Refresh()));
        //        //image.Save("uno.bmp");
        //        Console.WriteLine(image.Size);
        //    }
        //    catch (System.InvalidOperationException ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //public Bitmap BitmapFromSource(System.Windows.Media.Imaging.BitmapSource bitmapsource)
        //{
        //    //convert image format
        //    var src = new System.Windows.Media.Imaging.FormatConvertedBitmap();
        //    src.BeginInit();
        //    src.Source = bitmapsource;
        //    src.DestinationFormat = System.Windows.Media.PixelFormats.Bgra32;
        //    src.EndInit();

        //    //copy to bitmap
        //    Bitmap bitmap = new Bitmap(src.PixelWidth, src.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //    var data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //    src.CopyPixels(System.Windows.Int32Rect.Empty, 
        //        data.Scan0, data.Height * data.Stride, data.Stride);
        //    bitmap.UnlockBits(data);

        //    return bitmap;
        //}

        ~MainView()
        {
            if(subscriptionCreateVideo != null 
                && subscriptionHearInvalid != null 
                && subscriptionHearUser != null)
            {
                subscriptionCreateVideo.Dispose();
                subscriptionHearInvalid.Dispose();
                subscriptionHearUser.Dispose();                
            }
        }
        #endregion
    }
}
