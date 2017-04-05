using ChDCStatMenusLibrary;
using System;
using System.Windows.Forms;

namespace ChDCStatMenus
{
    public partial class FrmMemory : FrmPanel
    {
        public FrmMemory()
        {
            InitializeComponent();

            timerProcesses_Tick(null, null);
        }

        private void timerProcesses_Tick(object sender, EventArgs e)
        {
            listProcessUsage.Items.Clear();
            ProcessInfo.SimpleMemoryUsage[] gu = ProcessInfo.GetMemeoryUsage();
            foreach(ProcessInfo.SimpleMemoryUsage item in gu)
            {
                ListViewItem li = listProcessUsage.Items.Add(item.ProcessName);
                li.SubItems.Add( ProcessInfo.GetStorageSizeString(item.Usage));
            }
        }

    }
}
