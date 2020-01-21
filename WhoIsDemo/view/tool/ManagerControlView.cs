using System;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;


namespace WhoIsDemo.view.tool
{
    class ManagerControlView
    {
        #region variables

        #endregion

        #region methods
        public ManagerControlView()
        {

        }

        public Label GetControlLabelThisForm(Form thisForm, string nameControl)
        {
            Label label = null;
            foreach (Control control in thisForm.Controls)
            {
                if (control is Label && control.Name == nameControl)
                {
                    label = (Label)control;
                    break;

                }
            }

            return label;
        }

        public TextBox GetControlTextThisForm(Form thisForm, string nameControl)
        {
            TextBox textBox = null;
            foreach (Control control in thisForm.Controls)
            {
                if (control is TextBox && control.Name == nameControl)
                {
                    textBox = (TextBox)control;
                    break;

                }
            }

            return textBox;
        }

        public PictureBox GetControlPictureBoxThisForm(Form thisForm, string nameControl)
        {
            PictureBox picBox = null;
            foreach (Control control in thisForm.Controls)
            {
                if (control is PictureBox && control.Name == nameControl)
                {
                    picBox = (PictureBox)control;
                    break;

                }
            }

            return picBox;
        }

        public Button GetControlButtonThisForm(Form thisForm, string nameControl)
        {
            Button btn = null;
            foreach (Control control in thisForm.Controls)
            {
                if (control is Button && control.Name == nameControl)
                {
                    btn = (Button)control;
                    break;

                }
            }

            return btn;
        }

        public void CreateStatusBar(Form frmWork, StatusStrip statusStrip)
        {

            ToolStripStatusLabel panel1 = new ToolStripStatusLabel();
            ToolStripProgressBar panel2 = new ToolStripProgressBar();
            ToolStripStatusLabel panel3 = new ToolStripStatusLabel();
            System.Drawing.Size size = new System.Drawing.Size();

            size.Width = Convert.ToInt32(frmWork.Width * 0.2);
            panel1.Text = "";
            panel1.Size = size;
            panel1.ForeColor = System.Drawing.Color.Blue;
            panel2.Minimum = 1;
            panel2.Maximum = 10;
            panel2.Step = 1;
            panel2.Size = size;
            panel3.Text = SetDateLocale();
            panel3.BackColor = System.Drawing.Color.Black;
            panel3.ForeColor = System.Drawing.Color.White;
            panel3.Alignment = ToolStripItemAlignment.Right;
            statusStrip.Show();
            statusStrip.Items.Add(panel1);
            statusStrip.Items.Add(panel2);
            statusStrip.Items.Add(panel3);

        }

        public string SetDateLocale()
        {
            string dateLocale;
            System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES");
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            dateLocale = string.Format("{0:D}", DateTime.Now);
            cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("en-EN");
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;

            return dateLocale;
        }

        public void SetValueTextStatusStrip(string strMessage,
           int index, StatusStrip statusStrip)
        {
            
            statusStrip.Items[index].Text = strMessage;
        }

        public PictureBox GetControlPictureBoxThisSplitContainer(
            SplitContainer thisSplitContainer, string nameControl)
        {
            PictureBox picture = null;


            foreach (Control control in thisSplitContainer.Panel2.Controls)
            {
                if (control is PictureBox && control.Name == nameControl)
                {
                    picture = (PictureBox)control;
                    break;

                }
            }

            return picture;
        }

        public Emgu.CV.UI.ImageBox GetControlImageBoxThisSplitContainer(
            SplitContainer thisSplitContainer, string nameControl)
        {
            Emgu.CV.UI.ImageBox picture = null;


            foreach (Control control in thisSplitContainer.Panel2.Controls)
            {
                if (control is Emgu.CV.UI.ImageBox && control.Name == nameControl)
                {
                    picture = (Emgu.CV.UI.ImageBox)control;
                    break;

                }
            }

            return picture;
        }

        public DataGridView GetControlDataGridViewThisSplitContainer(
            SplitContainer thisSplitContainer, string nameControl)
        {
            DataGridView dataGrid = null;


            foreach (Control control in thisSplitContainer.Panel1.Controls)
            {
                if (control is DataGridView && control.Name == nameControl)
                {
                    dataGrid = (DataGridView)control;
                    break;

                }
            }

            return dataGrid;
        }

        public DataGridView GetControlDataGridViewThisSplitContainerPanel2(
            SplitContainer thisSplitContainer, string nameControl)
        {
            DataGridView dataGrid = null;


            foreach (Control control in thisSplitContainer.Panel2.Controls)
            {
                if (control is DataGridView && control.Name == nameControl)
                {
                    dataGrid = (DataGridView)control;
                    break;

                }
            }

            return dataGrid;
        }
        public Button GetControlButtonThisSplitContainer(
            SplitContainer thisSplitContainer, string nameControl)
        {
            Button button = null;


            foreach (Control control in thisSplitContainer.Panel2.Controls)
            {
                if (control is Button && control.Name == nameControl)
                {
                    button = (Button)control;
                    break;

                }
            }

            return button;
        }
        public SplitContainer GetControlSplitContainerThisForm(Form thisForm, string nameControl)
        {
            SplitContainer split = null;
            foreach (Control control in thisForm.Controls)
            {
                if (control is SplitContainer && control.Name == nameControl)
                {
                    split = (SplitContainer)control;
                    break;

                }
            }

            return split;
        }

        public ToolStripComboBox GetToolStripComboBoxMain(string nameMDI)
        {
            ToolStripComboBox cbo = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == nameMDI)
                {
                    mdiMain md = (mdiMain)f;

                    foreach (Control c in f.Controls)
                    {
                        if (c is ToolStrip)
                        {
                            ToolStrip tool = (ToolStrip)c;

                            foreach(ToolStripItem tt in tool.Items)
                            {
                                if (tt is ToolStripComboBox)
                                {
                                    cbo = (ToolStripComboBox)tt;
                                    break;
                                }
                            }

                        }
                    }
                }
            }

            return cbo;
        }
        public StatusStrip GetStatusStripMain(string nameMDI)
        {
            StatusStrip status = null;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == nameMDI)
                {
                    mdiMain md = (mdiMain)f;

                    foreach (Control c in f.Controls)
                    {
                        if (c is StatusStrip)
                        {
                            status = (StatusStrip)c;
                            break;

                        }
                    }
                }
            }

            return status;
        }

        public void StartProgressStatusStrip(int index, StatusStrip ssCtrl)
        {
            try
            {
               
                ToolStripProgressBar tsProgressBar = ssCtrl.Items[index] as ToolStripProgressBar;
                tsProgressBar.Style = ProgressBarStyle.Marquee;
                tsProgressBar.MarqueeAnimationSpeed = 30;
                
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }


        }

        public void StopProgressStatusStrip(int index, StatusStrip ssCtrl)
        {
            

            ToolStripProgressBar tsProgressBar = ssCtrl.Items[index] as ToolStripProgressBar;
            tsProgressBar.Style = ProgressBarStyle.Continuous;
            tsProgressBar.MarqueeAnimationSpeed = 0;

        }

        public void EnabledOptionMenu(string nameMenu, string nameMDI)
        {
            Form frm = new Form();
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == nameMDI)
                    frm = f;
            }


            foreach (ToolStripMenuItem mnu in frm.MainMenuStrip.Items)
            {
                foreach (ToolStripDropDownItem smnu in mnu.DropDownItems)
                {

                    if (smnu.Name == nameMenu)
                    {
                        smnu.Enabled = true;
                        smnu.Visible = true;
                    }


                }
            }
        }

        public void EnabledOptionSubMenu(string nameOption, string nameMDI)
        {
            Form frm = new Form();
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == nameMDI)
                    frm = f;

            }

            foreach (ToolStripMenuItem mnu in frm.MainMenuStrip.Items)
            {
                foreach (ToolStripDropDownItem smnu in mnu.DropDownItems)
                {
                    foreach (ToolStripDropDownItem semnu in smnu.DropDownItems)
                    {
                        if (semnu.Name == nameOption)
                        {
                            semnu.Enabled = true;
                            semnu.Visible = true;
                        }
                    }
                }
            }
        }

        public void OnlyInteger(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (char.IsControl(e.KeyChar)))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        public void OnlyDecimal(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) ||
                (char.IsControl(e.KeyChar)) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void SetValueToComboBox(ComboBox cbo, string value)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                cbo.SelectedIndex = i;
                if (cbo.Text == value || Convert.ToString(cbo.SelectedValue) == value)
                {
                    return;
                }
            }
        }

        [ReflectionPermission(SecurityAction.Demand, MemberAccess = true)]
        public void ResetExceptionState(Control control)
        {
            typeof(Control).InvokeMember("SetState", BindingFlags.NonPublic |
              BindingFlags.InvokeMethod | BindingFlags.Instance, null,
              control, new object[] { 0x400000, false });
        }

        #endregion
    }
}
