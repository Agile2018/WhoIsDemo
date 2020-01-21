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
        //private Database database = new Database();
        private List<String> listImage = new List<string>();
        public delegate void ImageDelegate(string imageBase64);
        public event ImageDelegate OnImage;
        public delegate void ListImageDelegate(List<String> list);
        public event ListImageDelegate OnListImage;
        #endregion

        #region methods
        public FindImage() { }

        //public void Connect()
        //{
        //    database.Connect();
        //    database.GetImages();
        //}

        public void GetImageByIdFace(int idFace)
        {

            //Image imageDb = database.GetImageByUser(idFace);
            Image imageDb = Database.Instance.GetImageByUser(idFace);
            if (imageDb != null)
            {
                ImageBase64 = imageDb.data_64;
            }
                        
        }

        public void ClearPlanCacheImages()
        {
            //database.ClearPlanCacheImages();
            Database.Instance.ClearPlanCacheImages();
        }

        public void GetListImageByIdFace(int idFace)
        {

            //Image imageDb = database.GetImageByUser(idFace);
            Image imageDb = Database.Instance.GetImageByUser(idFace);
            if (imageDb != null)
            {
                List<String> list = new List<string>();
                list.Add(imageDb.data_64);
                list.Add(imageDb.data_64_aux);
                this.ListImage = list;
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
                //database.Connection = connection;
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
                //database.NameDatabase = nameDatabase;
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

        public List<string> ListImage {
            get
            {
                return listImage;
            }

            set
            {
                listImage = value;
                OnListImage(listImage);
            }
            
        }


        #endregion


    }
}
