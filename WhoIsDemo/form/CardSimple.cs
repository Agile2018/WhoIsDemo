using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoIsDemo.form
{
    public partial class CardSimple : UserControl
    {
        #region variables
        private string namePerson;
        private Image photo;
        private int idFace;
        #endregion
        public CardSimple()
        {
            InitializeComponent();
        }

        public string NamePerson
        {
            get
            {
                return namePerson;
            }

            set
            {
                namePerson = value;
                txtName.Text = value;
            }
        }

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
        public int IdFace { get => idFace; set => idFace = value; }
    }
}
