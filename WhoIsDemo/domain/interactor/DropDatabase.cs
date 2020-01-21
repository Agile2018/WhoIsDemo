using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class DropDatabase
    {
        #region variables
        private string connection;
        private string nameDatabase;
        //private Database database = new Database();
        #endregion

        #region methods
        public DropDatabase() { }

        //public void Connect()
        //{
        //    database.Connect();
        //    database.GetUsers();
        //    database.GetImages();
        //}

        public bool DropCurrentDatabase()
        {
            //return database.DropDatabase();
            return Database.Instance.DropDatabase();
        }

        public string Connection
        {
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

        public string NameDatabase
        {
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
        #endregion
    }
}
