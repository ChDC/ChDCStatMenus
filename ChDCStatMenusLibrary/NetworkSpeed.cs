using System;
using System.Linq;
using System.Timers;
using System.Net.NetworkInformation;

namespace ChDCStatMenusLibrary
{
    public class NetworkSpeed
    {
        public class NetworkSpeedInfo
        {
            /// <summary>
            /// 发送的字节数
            /// </summary>
            public long BytesSent { get; set; }
            /// <summary>
            /// 接收的字节数
            /// </summary>
            public long BytesReceived { get; set; }
            /// <summary>
            /// 发送的速度（单位 B/s）
            /// </summary>
            public long BytesSentSpeed { get; set; }
            /// <summary>
            /// 接收的速度（单位 B/s）
            /// </summary>
            public long BytesReceivedSpeed { get; set; }

            public string BytesSentSpeedString
            {
                get
                {
                    return NetworkSpeedInfo.GetSpeedString(BytesSentSpeed);
                }
            }
            public string BytesReceivedSpeedString
            {
                get
                {
                    return NetworkSpeedInfo.GetSpeedString(BytesReceivedSpeed);
                }
            }

            NetworkInterface NIC;

            public NetworkSpeedInfo()
            {
                BytesSent = 0L;
                BytesReceived = 0L;
                BytesReceivedSpeed = 0;
                BytesSentSpeed = 0;
            }

            /// <summary>
            /// 获取指定网卡的网速信息
            /// </summary>
            /// <param name="nic"></param>
            /// <param name="oldNetworkSpeedInfo"></param>
            /// <param name="interval"></param>
            /// <returns></returns>
            public static NetworkSpeedInfo GetNetworkSpeedInfo(NetworkInterface nic, NetworkSpeedInfo oldNetworkSpeedInfo = null, double interval = 1000)
            {
                NetworkSpeedInfo info = new NetworkSpeedInfo();
                info.NIC = nic;

                IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();

                info.BytesSent = interfaceStats.BytesSent;
                info.BytesReceived = interfaceStats.BytesReceived;
                info.BytesSentSpeed = oldNetworkSpeedInfo == null ? 0 : (long)((info.BytesSent - oldNetworkSpeedInfo.BytesSent) / (interval / 1000));
                info.BytesReceivedSpeed = oldNetworkSpeedInfo == null ? 0 : (long)((info.BytesReceived - oldNetworkSpeedInfo.BytesReceived) / (interval / 1000));

                return info;
            }

            /// <summary>
            /// 获取所有网卡综合的网速信息
            /// </summary>
            /// <param name="nics"></param>
            /// <param name="oldNetworkSpeedInfo"></param>
            /// <param name="interval"></param>
            /// <returns></returns>
            public static NetworkSpeedInfo GetTotalNetworkSpeedInfo(NetworkInterface[] nics, NetworkSpeedInfo oldNetworkSpeedInfo = null, double interval = 1000)
            {
                NetworkSpeedInfo info = new NetworkSpeedInfo();

                info.NIC = null;

                foreach (NetworkInterface nic in nics)
                {
                    IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();
                    info.BytesSent += interfaceStats.BytesSent;
                    info.BytesReceived += interfaceStats.BytesReceived;
                }

                info.BytesSentSpeed += oldNetworkSpeedInfo == null ? 0 : (long)((info.BytesSent - oldNetworkSpeedInfo.BytesSent) / (interval / 1000));
                info.BytesReceivedSpeed += oldNetworkSpeedInfo == null ? 0 : (long)((info.BytesReceived - oldNetworkSpeedInfo.BytesReceived) / (interval / 1000));

                return info;
            }

            /// <summary>
            /// 将速度（单位 B/s）转换为字符串表示
            /// </summary>
            /// <param name="speed"></param>
            /// <returns></returns>
            public static string GetSpeedString(long speed)
            {
                string[] units = "K M G T P".Split(' ');
                string unit = " ";
                double s = speed;
                foreach(string u in units)
                {
                    if ((int)s / 1024 != 0)
                    {
                        unit = u;
                        s /= 1024;
                    }
                    else
                        break;
                }
                return String.Format("{0:G3}{1}B/s", s, unit.ToString());
            }
        }

        public event EventHandler<NetworkSpeedInfo> NotityInfoEvent;

        Timer timer;
        NetworkInterface[] nics;
        NetworkSpeedInfo networkSpeedInfo = null;

        public NetworkSpeed(double interval=1000) : this(new Timer(interval))
        {

        }

        public NetworkSpeed(Timer timer)
        {
            nics = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .ToArray();

            this.timer = timer;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // get network speed
            networkSpeedInfo = NetworkSpeedInfo.GetTotalNetworkSpeedInfo(nics, networkSpeedInfo, timer.Interval);
            Notify(networkSpeedInfo);
        }

        /// <summary>
        /// 开启获取
        /// </summary>
        public void Start()
        {
            timer.Start();
            Timer_Elapsed(null, null);
        }

        public void Notify(NetworkSpeedInfo info)
        {
            NotityInfoEvent?.Invoke(this, info);
        }

    }
}
