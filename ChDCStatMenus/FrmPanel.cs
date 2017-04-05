using System;
using System.Windows.Forms;
using System.Drawing;

namespace ChDCStatMenus
{
    public partial class FrmPanel : Form
    {
        public FrmPanel MyParent
        {
            get;
            set;
        }

        public FrmPanel MyChild
        {
            get;
            set;
        }

        public FrmPanel()
        {
            InitializeComponent();

            this.Deactivate += FrmPanel_Deactivate;
            this.FormClosed += FrmPanel_FormClosed;

            timerCloseAll.Enabled = true;
        }

        private void FrmPanel_Deactivate(object sender, EventArgs e)
        {
            if (MyChild == null)
            {
                this.Close();
            }
        }

        private void CloseAll()
        {
            FrmPanel parent = this;
            for (; parent.MyParent != null; parent = parent.MyParent)
            {

            }
            parent.Close();
        }

        private void FrmPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyParent != null)
                MyParent.MyChild = null;
        }

        public void ShowChild(FrmPanel frmChild, Control sender=null)
        {
            frmChild.MyParent = this;

            MyChild?.Close();
            MyChild = frmChild;

            frmChild.Show(this);

            if(sender != null)
                frmChild.Location = new Point(this.Left - frmChild.Width, sender.Top + this.Top);
        }

        private void timerCloseAll_Tick(object sender, EventArgs e)
        {
            bool allDeactivated = true;
            for(FrmPanel frm = this.MyParent; frm != null; frm = frm.MyParent)
            {
                if (frm.Focused || frm.ContainsFocus)
                {
                    allDeactivated = false;
                    break;
                }
            }

            for (FrmPanel frm = this; frm != null; frm = frm.MyChild)
            {
                if (frm.Focused || frm.ContainsFocus)
                {
                    allDeactivated = false;
                    break;
                }
            }

            if (allDeactivated)
            {
                CloseAll();
            }
        }
    }
}
