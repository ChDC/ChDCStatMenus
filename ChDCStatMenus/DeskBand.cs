using System;
using System.ComponentModel;
using System.Windows.Forms;

using BandObjectLib;
using System.Runtime.InteropServices;
using ChDCStatMenusLibrary;

namespace ChDCStatMenus
{
    [Guid("AE07101B-46D4-4a98-AF68-0333EA26E113")]
    [BandObject("ChDC Stat Meuns", BandObjectStyle.Horizontal | BandObjectStyle.ExplorerToolbar | BandObjectStyle.TaskbarToolBar, HelpText = "")]
    public class DeskBand : BandObject
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblDownloadSpeed;
        private Label lblUploadSpeed;
        private Label label1;
        private Label label2;
        private IContainer components;

        public DeskBand()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDownloadSpeed = new System.Windows.Forms.Label();
            this.lblUploadSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDownloadSpeed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUploadSpeed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(80, 30);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Wingdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "";
            // 
            // lblDownloadSpeed
            // 
            this.lblDownloadSpeed.BackColor = System.Drawing.Color.Black;
            this.lblDownloadSpeed.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDownloadSpeed.ForeColor = System.Drawing.Color.White;
            this.lblDownloadSpeed.Location = new System.Drawing.Point(23, 15);
            this.lblDownloadSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.lblDownloadSpeed.Name = "lblDownloadSpeed";
            this.lblDownloadSpeed.Size = new System.Drawing.Size(54, 15);
            this.lblDownloadSpeed.TabIndex = 3;
            this.lblDownloadSpeed.Text = "254KB/s";
            this.lblDownloadSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDownloadSpeed.Click += new System.EventHandler(this.info_click);
            this.lblDownloadSpeed.MouseHover += new System.EventHandler(this.info_hover);
            // 
            // lblUploadSpeed
            // 
            this.lblUploadSpeed.BackColor = System.Drawing.Color.Black;
            this.lblUploadSpeed.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUploadSpeed.ForeColor = System.Drawing.Color.White;
            this.lblUploadSpeed.Location = new System.Drawing.Point(23, 0);
            this.lblUploadSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.lblUploadSpeed.Name = "lblUploadSpeed";
            this.lblUploadSpeed.Size = new System.Drawing.Size(54, 15);
            this.lblUploadSpeed.TabIndex = 1;
            this.lblUploadSpeed.Text = "128KB/s";
            this.lblUploadSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUploadSpeed.Click += new System.EventHandler(this.info_click);
            this.lblUploadSpeed.MouseHover += new System.EventHandler(this.info_hover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Wingdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "";
            // 
            // DeskBand
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinSize = new System.Drawing.Size(80, 30);
            this.Name = "DeskBand";
            this.Size = new System.Drawing.Size(80, 30);
            this.Title = "";
            this.Load += new System.EventHandler(this.DeskBand_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
       

        private void DeskBand_Load(object sender, EventArgs e)
        {
            NetworkSpeed networkSpeed = new NetworkSpeed();
            networkSpeed.Start();
            networkSpeed.NotityInfoEvent += NetworkSpeed_NotityInfoEvent;
        }

        private void NetworkSpeed_NotityInfoEvent(object sender, NetworkSpeedInfo e)
        {
            this.BeginInvoke(new Action(() => {
                lblDownloadSpeed.Text = e.BytesReceivedSpeedString;
                lblUploadSpeed.Text = e.BytesSentSpeedString;
            }));
        }

        private void info_click(object sender, EventArgs e)
        {
            FrmInfo frm = new FrmInfo();
            frm.Show();
            //frm.Left = Control.MousePosition.X;
            //frm.Top = Control.MousePosition.Y;
            frm.Top = this.Top + this.Height + 10;
            frm.Left = this.Left;
        }

        FrmInfo frmInfo = null;

        private void info_hover(object sender, EventArgs e)
        {
            if(frmInfo == null || frmInfo.IsDisposed)
            {
                frmInfo = new FrmInfo();
                frmInfo.Show();
                frmInfo.Top = this.Top + this.Height + 10;
                frmInfo.Left = this.Left;
            }
        }
    }
}
