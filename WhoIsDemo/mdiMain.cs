using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WhoIsDemo.form;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.presenter;
using WhoIsDemo.repository;
using WhoIsDemo.view.tool;

//using ASSLibrary;

namespace WhoIsDemo
{
    public partial class mdiMain : Form
    {
        #region constants
        public const string NAME = "mdiMain";
        #endregion
        #region variables
        private ManagerControlView managerControlView = new ManagerControlView();
        private RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();
        public List<int> listDispositive = new List<int>();
        #endregion

        public mdiMain()
        {
            InitializeComponent();
            
        }

        private void mdiMain_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Top = 0;
            this.Left = (int)((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);
            managerControlView.CreateStatusBar(this, statusStrip);
            
            
        }
             
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void dispositivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            managerControlView.SetValueTextStatusStrip("", 0, statusStrip);            
            frmIdentify frmWork = new frmIdentify() { MdiParent = this };
            frmWork.ipVideo = registryValueDataReader
                .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                RegistryValueDataReader.IP_CAMERA_KEY);

            frmWork.strNameMenu = "dispositivoToolStripMenuItem";           
            dispositivoToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration frmWork = new frmConfiguration() { MdiParent = this };
            frmWork.strNameMenu = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmToolDatabase frmWork = new frmToolDatabase() { MdiParent = this };
            frmWork.strNameMenu = "baseDeDatosToolStripMenuItem";
            baseDeDatosToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }
    }
}
