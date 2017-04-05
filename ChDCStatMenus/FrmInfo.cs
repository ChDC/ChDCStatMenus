using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using ChDCStatMenusLibrary;
using Microsoft.VisualBasic.Devices;

namespace ChDCStatMenus
{
    public partial class FrmInfo : FrmPanel
    {
        System.Timers.Timer timer = new System.Timers.Timer();

        public FrmInfo()
        {
            InitializeComponent();
        }
        

        private void lblMemory_MouseHover(object sender, EventArgs e)
        {
            this.ShowChild(new FrmMemory(), sender as Control);
        }

        private void lblNetwork_MouseHover(object sender, EventArgs e)
        {
            this.ShowChild(new FrmNetwork(), (sender as Control).Parent);
        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Elapsed += (s, e1) => this.BeginInvoke(new Action(Timer_Elapsed));

            NetworkSpeed networkSpeed = new NetworkSpeed(timer);
            networkSpeed.Start();
            networkSpeed.NotityInfoEvent += NetworkSpeed_NotityInfoEvent;


            Timer_Elapsed();
            lblTime.Text = DateTime.Now.ToString("D") + " " + DateTime.Now.ToString("dddd");
            lblLunisolar.Text = TimeInfo.GetChineseDateTime(DateTime.Now);
        }

        //PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        //float cpuUsage = 0;


        private void Timer_Elapsed()
        {
            ComputerInfo ci = new ComputerInfo();
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            // 内存使用比例
            float totalMB = ci.TotalPhysicalMemory / 1024 / 1024;
            float usedMB = totalMB - ramCounter.NextValue();
            float memoryUsage = usedMB / totalMB;

            //picMemory.dr

            //cpuUsage = cpuCounter.NextValue() - cpuUsage;
            //MessageBox.Show(cpuUsage + "%");
            drawMemoryUsage(memoryUsage);
            lblMemory.Text = String.Format("{0:G2}GB/{1:G2}GB", usedMB / 1024, totalMB/1024);
        }

        private void drawMemoryUsage(float value)
        {
            
            Control control = lblMemory;
            Bitmap b = new Bitmap(control.Width, control.Height);
            Graphics g = Graphics.FromImage(b);

            //draw background
            g.FillRectangle(new SolidBrush(Color.FromArgb(28, 28, 29)), 0, 0, control.Width, control.Height);

            // draw usage rect
            int width = (int)(control.Width * value);
            Rectangle rect = new Rectangle(0, 0, width, control.Height);

            //LinearGradientBrush brush = new LinearGradientBrush(control.ClientRectangle, Color.FromArgb(17, 160, 255), Color.FromArgb(23,174,254), LinearGradientMode.Vertical);
            //brush.SetSigmaBellShape(0.5f);
            //g.FillRectangle(brush, rect);
            g.FillRectangle(new SolidBrush(Color.FromArgb(0, 186, 255)), rect);

            // border
            g.DrawRectangle(new Pen(Color.FromArgb(28, 28, 29), 3), 0, 0, control.Width-2, control.Height-2);

            g.Dispose();
            control.BackgroundImage = b;
        }

        private void NetworkSpeed_NotityInfoEvent(object sender, NetworkSpeed.NetworkSpeedInfo e)
        {
            this.BeginInvoke(new Action(() => {
                lblDownloadSpeed.Text = e.BytesReceivedSpeedString;
                lblUploadSpeed.Text = e.BytesSentSpeedString;
            }));
        }

    }
}
