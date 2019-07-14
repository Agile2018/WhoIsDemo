using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;

namespace WhoIsDemo.presenter
{
    class FindImagePresenter
    {
        #region variables
        private string connection;
        private string nameDatabase;
        FindImage findImage = new FindImage();

        public string Connection {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
                findImage.Connection = connection;
            }
        }

        public string NameDatabase {
            get
            {
                return nameDatabase;
            }

            set
            {
                nameDatabase = value;
                findImage.NameDatabase = nameDatabase;
            }
        }

        public Subject<Bitmap> subjectImage = new Subject<Bitmap>();

        #endregion

        #region methods
        public FindImagePresenter()
        {
            this.findImage.OnImage += new FindImage
                .ImageDelegate(SendBitmap);
        }
        public void Connect()
        {
            Connection = "mongodb://localhost:27017";
            NameDatabase = "dbass";
            findImage.Connect();
        }

        public void GetImage64ByUser(int idFace)
        {
            findImage.GetImageByIdFace(idFace);
        }

        private void SendBitmap(string image64)
        {
            Bitmap imageTransform = Base64StringToBitmap(image64);
            subjectImage.OnNext(imageTransform);
        }

        private Bitmap Base64StringToBitmap(string
                                           base64String)
        {
            Bitmap bmpReturn = null;
            byte[] byteBuffer;
            MemoryStream memoryStream;
            try
            {
                byteBuffer = Convert.FromBase64String(base64String);
                memoryStream = new MemoryStream(byteBuffer);


                memoryStream.Position = 0;


                bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);
                                
                memoryStream.Close();
                
            }
            catch (System.InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (System.AccessViolationException ex)
            {
                Console.WriteLine("Error Access Violation");
            }
            finally
            {
                memoryStream = null;
                byteBuffer = null;
            }

            return bmpReturn;
        }

        public Bitmap ResizeBitmap(Bitmap bmp)
        {
            int width = (int)(bmp.Width * 0.5);
            int height = (int)(bmp.Height * 0.5);
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
        #endregion
    }
}
