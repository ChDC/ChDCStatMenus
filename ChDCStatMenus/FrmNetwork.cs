using ChDCStatMenusLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChDCStatMenus
{

    public partial class FrmNetwork : FrmPanel
    {
        NetworkSpeed ns;

        public FrmNetwork()
        {
            InitializeComponent();
        }

        private void FrmNetwork_Load(object sender, EventArgs e)
        {
            ns = new NetworkSpeed();
            ns.NotityInfoEvent += Ns_NotityInfoEvent;
            ns.Start();
            
            lblPublicIP.Text = NetworkInfo.GetPublicIP();
        }

        private void Ns_NotityInfoEvent(object sender, NetworkSpeedInfo[] infos)
        {
            this.BeginInvoke(new Action(() => {
                listNICSpeed.Items.Clear();
                foreach(NetworkSpeedInfo info in infos)
                {
                    ListViewItem si = listNICSpeed.Items.Add(info.NIC.Name);
                    Console.WriteLine(info.NIC.GetIPProperties().GetType());
                    si.SubItems.Add(info.BytesSentSpeedString);
                    si.SubItems.Add(info.BytesReceivedSpeedString);
                }
            }));
        }

        private void FrmNetwork_FormClosed(object sender, FormClosedEventArgs e)
        {
            ns.Stop();
        }
    }
}
