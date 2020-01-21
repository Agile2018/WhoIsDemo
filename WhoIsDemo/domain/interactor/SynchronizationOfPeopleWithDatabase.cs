using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class SynchronizationOfPeopleWithDatabase
    {
        #region variables             
        //private Database database = new Database();
        private List<People> listPeople = new List<People>();  
        private List<People> syncUpPeople = new List<People>();

        public List<People> SyncUpPeople {
            get
            {
                return syncUpPeople;
            }

            set
            {
                syncUpPeople = value;
                OnListPeople(syncUpPeople);
            }
            
        }

        public delegate void ListPeopleDelegate(List<People> list);
        public event ListPeopleDelegate OnListPeople;
        #endregion

        #region methods
        public SynchronizationOfPeopleWithDatabase()
        {
            //this.database.Connection = Configuration.Instance.ConnectDatabase;
            //this.database.NameDatabase = Configuration.Instance.NameDatabase;
            //database.Connect();
            //database.GetImages();
            //database.GetUsers();
        }

        public void SyncUpDatabase(int indexSkip)
        {
            //database.IndexSkip = indexSkip;
            Database.Instance.IndexSkip = indexSkip;
            GetAllPeople();
            GetImagesOfPeople();
            SyncUpPeople = this.listPeople;
        }

        private void GetAllPeople()
        {
            this.listPeople.Clear();
            //List<PersonDb> list = database.GetAllPeople();
            List<PersonDb> list = Database.Instance.GetAllPeople();
            if (list.Count != 0)
            {
                listPeople = list.Select(l => new People {Id_face = l.Id_face,
                Name = l.Name, Lastname = l.Lastname,
                    Identification = l.Identification}).ToList();

            }
        }

        private void GetImagesOfPeople()
        {
            //List<Image> list = database.GetImagesOfPepople();
            List<Image> list = Database.Instance.GetImagesOfPepople();
            if (list.Count != 0)
            {
                for(int i = 0; i < listPeople.Count; i++)
                {
                    Image img = list.Find(e => e.id_face == listPeople[i].Id_face);
                    if (img != null)
                    {
                        listPeople[i].Image = img.data_64;
                    }
                }
            }
        }

        public int GetMaxLimit()
        {
            return Database.LIMIT_RECORDS;
        }

        public long GetNumberOfUsers()
        {
            //return database.GetNumberOfUsers();
            return Database.Instance.GetNumberOfUsers();
        }

        #endregion
    }
}
