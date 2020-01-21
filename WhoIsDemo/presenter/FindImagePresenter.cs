using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;

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
        public Subject<List<Bitmap>> subjectListImage = new Subject<List<Bitmap>>();
        #endregion

        #region methods
        public FindImagePresenter()
        {
            this.findImage.OnImage += new FindImage
                .ImageDelegate(SendBitmap);
            this.findImage.OnListImage += new FindImage
                .ListImageDelegate(SendListBitmap);
        }
        //public void Connect()
        //{
        //    Connection = Configuration.Instance.ConnectDatabase; // "mongodb://localhost:27017";
        //    NameDatabase = Configuration.Instance.NameDatabase; //"dbass";
        //    findImage.Connect();
        //}

        public void GetImage64ByUser(int idFace)
        {
            findImage.GetImageByIdFace(idFace);
        }

        public void GetListImage64ByUser(int idFace)
        {
            findImage.GetListImageByIdFace(idFace);
        }

        private void SendBitmap(string image64)
        {
            Bitmap imageTransform = Base64StringToBitmap(image64);
            subjectImage.OnNext(imageTransform);
        }

        private void SendListBitmap(List<String> list)
        {
            Bitmap imageGallery = Base64StringToBitmap(list[0]);
            Bitmap imageCamera = Base64StringToBitmap(list[1]);

            List<Bitmap> listImage = new List<Bitmap>();
            if (imageGallery != null)
            {
                listImage.Add(imageGallery);
            }
            if (imageCamera != null)
            {
                listImage.Add(imageCamera);
            }
            subjectListImage.OnNext(listImage);

        }

        public Bitmap Base64StringToBitmap(string
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
                Console.WriteLine("Error Access Violation. " + ex.Message);
            }
            catch (System.ArgumentException ax)
            {
                Console.WriteLine("Error Access Violation. " + ax.Message);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine("Error Format. " + ex.Message);
            }
            finally
            {
                memoryStream = null;
                byteBuffer = null;
            }

            return bmpReturn;
        }

        public void ClearPlanCacheImages()
        {
            findImage.ClearPlanCacheImages();
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

        public Bitmap AdjustAlpha(Bitmap image, float translucency)
        {

            float t = translucency;
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, t, 0},
                    new float[] {0, 0, 0, 0, 1},
                });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect =
                new Rectangle(0, 0, image.Width, image.Height);


            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }

            return bm;
        }
        #endregion
    }
}
