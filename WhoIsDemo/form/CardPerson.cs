using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WhoIsDemo.presenter;

namespace WhoIsDemo.form
{
    public partial class CardPerson : UserControl
    {
        #region variables
        private string id;
        private string firstName;
        private string lastName;
        private Image photo;
        private string idFace;
        #endregion
        public CardPerson()
        {
            InitializeComponent();
        }
        [Category("Card Props")]
        public string Id {
            get
            {
                return id;
            }

            set
            {
                id = value;
                txtId.Text = value;
            }
        }
        [Category("Card Props")]
        public string FirstName {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                txtFirstName.Text = value;
            }
        }
        [Category("Card Props")]
        public string LastName {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
                txtLastName.Text = value;
            }
        }
        [Category("Card Props")]
        public Image Photo {
            get
            {
                return photo;
            }

            set
            {
                photo = value;
                picPhoto.Image = value;
            }
        }

        public string IdFace { get => idFace; set => idFace = value; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirstName.Text) 
                && !string.IsNullOrEmpty(txtLastName.Text) 
                && !string.IsNullOrEmpty(txtId.Text))
            {
                UpdatePersonPresenter.Instance
                .UpdateUser(Convert.ToInt32(IdFace),
                    txtFirstName.Text, txtLastName.Text, txtId.Text);
                btnSave.BackColor = Color.DeepSkyBlue;
            }
            else
            {
                btnSave.BackColor = Color.Red;
            }
            
        }
    }
}
