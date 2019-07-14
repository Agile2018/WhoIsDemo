using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.presenter;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmToolDatabase : Form
    {
        #region variables
        public string strNameMenu;
        ManagerControlView managerControlView = new ManagerControlView();
        DropDatabasePresenter dropDatabasePresenter = new DropDatabasePresenter();
        DiskPresenter diskPresenter = new DiskPresenter();
        private StatusStrip status;
        #endregion

        public frmToolDatabase()
        {
            InitializeComponent();
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
        }

        private void frmToolDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
        }
       
        private void frmToolDatabase_Load(object sender, EventArgs e)
        {
            dropDatabasePresenter.Connect();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            if (dropDatabasePresenter.DropCurrentDatabase())
            {
                diskPresenter.FileDelete("iengine.db");
                managerControlView.SetValueTextStatusStrip(StringResource.complete,
                    0, this.status);
            }
            else
            {
                managerControlView.SetValueTextStatusStrip(StringResource.error,
                    0, this.status);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
