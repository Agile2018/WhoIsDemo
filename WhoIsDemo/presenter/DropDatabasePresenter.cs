using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;

namespace WhoIsDemo.presenter
{
    class DropDatabasePresenter
    {
        #region variables
        private string connection;
        private string nameDatabase;
        DropDatabase dropDatabase = new DropDatabase();
        public string Connection
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
                dropDatabase.Connection = connection;
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
                dropDatabase.NameDatabase = nameDatabase;
            }
        }

        #endregion

        #region methods
        public DropDatabasePresenter() { }

        //public void Connect()
        //{            
        //    Connection = Configuration.Instance.ConnectDatabase; // "mongodb://localhost:27017";
        //    NameDatabase = Configuration.Instance.NameDatabase; //"dbass";
        //    dropDatabase.Connect();
        //}

        public bool DropCurrentDatabase()
        {
            return dropDatabase.DropCurrentDatabase();
        }

        #endregion

    }
}
