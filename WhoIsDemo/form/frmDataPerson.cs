using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.model;
using WhoIsDemo.presenter;

namespace WhoIsDemo.form
{
    public partial class frmDataPerson : Form
    {
        #region variables
        public Person person;
        UpdatePersonPresenter updatePersonPresenter = new UpdatePersonPresenter();
        
        #endregion

        #region methods


        public frmDataPerson()
        {
            InitializeComponent();
        }

        

        private void ConnectDatabase()
        {
            updatePersonPresenter.Connection = "mongodb://localhost:27017";
            updatePersonPresenter.NameDatabase = "dbass";
            updatePersonPresenter.Connect();
        }
        #endregion

        private void frmDataPerson_Load(object sender, EventArgs e)
        {

            txtName.Text = person.Params.Name;
            txtAddress.Text = person.Params.Address;
            ConnectDatabase();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAddress.Text) 
                && !string.IsNullOrEmpty(txtName.Text))
            {
                updatePersonPresenter.UpdateUser(Convert.ToInt32(person.Params.Id_face),
                    txtName.Text, txtAddress.Text);
                this.Close();
            }
        }
    }
}
