using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.presenter;

namespace WhoIsDemo.form
{
    public partial class CardTwoImage : UserControl
    {
        #region variables
        private string id;
        private string firstName;
        private string lastName;
        private Image photo;
        private Image photoCamera;
        private string idFace;
        private string dateTime;
        #endregion
        public CardTwoImage()
        {
            InitializeComponent();
        }

        [Category("CardTwo Props")]
        public string Id
        {
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
        [Category("CardTwo Props")]
        public string FirstName
        {
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
        [Category("CardTwo Props")]
        public string LastName
        {
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
        [Category("CardTwo Props")]
        public Image Photo
        {
            get
            {
                return photo;
            }

            set
            {
                photo = value;
                picPhotoGallery.Image = value;
            }
        }

        public string IdFace { get => idFace; set => idFace = value; }

        [Category("CardTwo Props")]
        public Image PhotoCamera {
            get
            {
                return photoCamera;
            }

            set
            {
                photoCamera = value;
                picPhotoCamera.Image = value;
            }
            
        }

        [Category("CardTwo Props")]
        public string DateTime {
            get
            {
                return dateTime;
            }

            set
            {
                dateTime = value;
                txtDatetime.Text = value;
            }
            
        }

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
