using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;

namespace WhoIsDemo.presenter
{
    class UpdatePersonPresenter
    {
        #region variables
        private string connection;
        private string nameDatabase;
        UpdatePerson updatePerson = new UpdatePerson();
        public string Connection
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
                updatePerson.Connection = connection;
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
                updatePerson.NameDatabase = nameDatabase;
            }
        }
        private static readonly UpdatePersonPresenter instance = new UpdatePersonPresenter();
        public static UpdatePersonPresenter Instance => instance;
        #endregion

        #region methods
        public UpdatePersonPresenter()
        {
            //Connection = "mongodb://localhost:27017";
            //NameDatabase = "dbass";
            //Connect();
        }

        //private void Connect()
        //{
        //    updatePerson.Connect();
        //}

        public void UpdateUser(int idFace, string namePerson, 
            string lastName, string identification)
        {
            updatePerson.UpdateUser(idFace, namePerson, 
                lastName, identification);
        }
        #endregion



    }
}
