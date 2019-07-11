using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class UpdatePerson
    {
        #region variables
        private string connection;
        private string nameDatabase;
        private Database database = new Database();
        #endregion

        #region methods
        public UpdatePerson() { }

        public void Connect()
        {
            database.Connect();
            database.GetUsers();
        }

        public void UpdateUser(int idFace, string namePerson, string address)
        {
            Task task = database.UpdateUser(idFace, namePerson, address);
            if (task.IsCompleted)
            {
                task.Dispose();

            }
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
                database.Connection = connection;
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
                database.NameDatabase = nameDatabase;
            }

        }
        #endregion
    }
}
