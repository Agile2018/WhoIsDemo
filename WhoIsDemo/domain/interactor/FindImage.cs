using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class FindImage
    {
        #region variables
        private string connection;
        private string nameDatabase;
        private string imageBase64;
        private Database database = new Database();
        public delegate void ImageDelegate(string imageBase64);
        public event ImageDelegate OnImage;
        #endregion

        #region methods
        public FindImage() { }

        public void Connect()
        {
            database.Connect();
            database.GetImages();
        }

        public void GetImageByIdFace(int idFace)
        {
            
            Image imageDb = database.GetImageByUser(idFace);
            if (imageDb != null)
            {
                ImageBase64 = imageDb.data_64;
            }
                        
        }

        public string Connection {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
                database.Connection = connection;
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
                database.NameDatabase = nameDatabase;
            }
            
        }

        public string ImageBase64 {
            get
            {
                return imageBase64;
            }

            set
            {
                imageBase64 = value;
                OnImage(imageBase64);
            }
           
        }


        #endregion


    }
}
