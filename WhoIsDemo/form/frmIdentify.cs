using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.presenter;
using WhoIsDemo.view;

namespace WhoIsDemo.form
{
    public partial class frmIdentify : Form
    {
        #region variables
        IdentifyView identifyView;        
        public string strNameMenu;
        public string ipVideo;
        //public int indexDispositive;
        #endregion
        public frmIdentify()
        {
            InitializeComponent();
            //IdentifyView.indexLink = indexDispositive;
        }
       

        private void frmIdentify_Load(object sender, EventArgs e)
        {
            
            identifyView = new IdentifyView(this);
            identifyView.IpVideo = ipVideo;

        }
        
    }

}
