using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Net.NetworkInformation;

namespace ChDCStatMenusLibrary
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

        public NetworkInterface NIC;

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
            return ProcessInfo.GetStorageSizeString(speed) + "/s";
        }
    }

    public class TotalNetworkSpeed
    {

        public event EventHandler<NetworkSpeedInfo> NotityInfoEvent;

        Timer timer;
        NetworkSpeedInfo networkSpeedInfo = null;

        public TotalNetworkSpeed(double interval=1000) : this(new Timer(interval))
        {

        }

        public TotalNetworkSpeed(Timer timer)
        {
            this.timer = timer;
            timer.Elapsed += Timer_Elapsed;
        }

        ~TotalNetworkSpeed()
        {
            this.timer?.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // get network speed
            if (NotityInfoEvent != null)
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up)
                    .ToArray();
                networkSpeedInfo = NetworkSpeedInfo.GetTotalNetworkSpeedInfo(nics, networkSpeedInfo, timer.Interval);
                Notify(networkSpeedInfo);
            }
        }

        /// <summary>
        /// 开启获取
        /// </summary>
        public void Start()
        {
            timer.Start();
            Timer_Elapsed(null, null);
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Notify(NetworkSpeedInfo info)
        {
            NotityInfoEvent?.Invoke(this, info);
        }

    }

    public class NetworkSpeed
    {

        public event EventHandler<NetworkSpeedInfo[]> NotityInfoEvent;

        Timer timer;
        Dictionary<string, NetworkSpeedInfo> networkSpeedInfos = new Dictionary<string, NetworkSpeedInfo>();

        public NetworkSpeed(double interval = 1000) : this(new Timer(interval))
        {

        }

        public NetworkSpeed(Timer timer)
        {
            this.timer = timer;
            timer.Elapsed += Timer_Elapsed;
        }

        ~NetworkSpeed()
        {
            this.timer?.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // get network speed
            if (NotityInfoEvent != null)
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up &&
                    (n.GetIPStatistics().BytesReceived != 0 ||
                    n.GetIPStatistics().BytesSent != 0))
                    .ToArray();
                foreach(NetworkInterface nic in nics)
                {
                    NetworkSpeedInfo ni = null;
                    if(networkSpeedInfos.ContainsKey(nic.Id))
                        ni = networkSpeedInfos[nic.Id];
                    ni = NetworkSpeedInfo.GetNetworkSpeedInfo(nic, ni, timer.Interval);
                    networkSpeedInfos[nic.Id] = ni;
                }
                Notify(networkSpeedInfos.Values.OrderByDescending(n => n.BytesReceivedSpeed).ToArray());
            }
        }

        /// <summary>
        /// 开启获取
        /// </summary>
        public void Start()
        {
            timer.Start();
            Timer_Elapsed(null, null);
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Notify(NetworkSpeedInfo[] infos)
        {
            NotityInfoEvent?.Invoke(this, infos);
        }

    }
}
