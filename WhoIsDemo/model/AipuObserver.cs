using System;
using System.Drawing;
using System.Windows.Media;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using ASSLibrary;
using System.Windows.Media.Imaging;
using System.Threading;

namespace WhoIsDemo.model
{
    public class AipuObserver: IDisposable
    {
        #region variables
        private Aipu aipu;
        private string errorBiometrics;
        private string userJson;
        private Bitmap frame;
        private IObservable<string> observableError;
        private IObservable<string> observableUser;
        IDisposable subscriptionUser;
        IDisposable subscriptionError;
        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        public string ErrorBiometrics
        {
            get
            {
                return errorBiometrics;
            }

            set
            {
                errorBiometrics = value;
                OnError(errorBiometrics);
            }
        }

        public string UserJson
        {
            get
            {
                return userJson;
            }

            set
            {
                userJson = value;
                OnUser(userJson);
            }
        }

        public Bitmap Frame
        {
            get
            {
                return frame;
            }

            set
            {
                frame = value;
                OnFrame(frame);
            }
        }

        public delegate void MessageErrorDelegate(string error);
        public event MessageErrorDelegate OnError;
        public delegate void UserJsonDelegate(string dataUser);
        public event UserJsonDelegate OnUser;
        public delegate void FrameDelegate(Bitmap inputFrame);
        public event FrameDelegate OnFrame;
        #endregion

        #region methods
        public AipuObserver(Aipu workAipu)
        {
            this.aipu = workAipu;
            ObserverError();
            ObserverUser();
            
        }

        ~AipuObserver()
        {

        }

        private void ObserverError()
        {
            observableError = Observable.Create<string>(async observer =>
            {
                observer.OnNext(await GetErrorAsync());
                
            });
            subscriptionError = observableError
                .Where(res => res != ErrorBiometrics && res != null)
                .Concat(Observable.Empty<string>().Delay(TimeSpan.FromSeconds(1)))
                .Repeat()
                .Subscribe(
                    res => ErrorBiometrics = res
                );
        }

        private Task<string> GetErrorAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    return aipu.GetError;
                }
                catch(System.NullReferenceException ex)
                {
                    Console.WriteLine("ERROR NULL AIPU " + ex.Message);
                }
                return null;
            });

        }

        private void ObserverUser()
        {
            observableUser = Observable.Create<string>(async observer =>
            {
                observer.OnNext(await GetUserAsync());
            });
            subscriptionUser = observableUser
                .Where(res => res != UserJson && !string.IsNullOrEmpty(res)) // 
                .Concat(Observable.Empty<string>().Delay(TimeSpan.FromSeconds(0.2)))
                .Repeat()
                .Subscribe(
                    res => UserJson = res
                );

        }

        private Task<string> GetUserAsync()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("OBSERVO.......");
                return aipu.GetUser;
                
            });

        }


        public Bitmap ResizeBitmap(Bitmap bmp)
        {
            if (bmp != null)
            {
                int newWidth = Convert.ToInt16(bmp.Width * 0.5);
                int newHeight = Convert.ToInt16(bmp.Height * 0.5);
                Bitmap result = new Bitmap(newWidth, newHeight);
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.DrawImage(bmp, 0, 0, newWidth, newHeight);
                }

                return result;
            }
            return null;
        }


        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter binaryFormat = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binaryFormat.Serialize(memoryStream, obj);

            return memoryStream.ToArray();
        }

        private ImageSource ConvertBitmapToImageSource(Bitmap imToConvert)
        {
            try
            {
                Bitmap bmp = new Bitmap(imToConvert);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                image.StreamSource = ms;
                image.EndInit();
                
                ImageSource sc = (ImageSource)image;


                return sc;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void Dispose()
        {
            this.aipu = null;
            subscriptionUser.Dispose();
            subscriptionError.Dispose();
        }


        #endregion
    }
}
