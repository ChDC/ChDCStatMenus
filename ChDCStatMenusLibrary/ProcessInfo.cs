using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ChDCStatMenusLibrary
{
    public class ProcessInfo
    {
        public struct SimpleMemoryUsage
        {
            public string ProcessName;
            public long Usage;

            public SimpleMemoryUsage(string ProcessName, long Usage)
            {
                this.ProcessName = ProcessName;
                this.Usage = Usage;
            }
        }

        /// <summary>
        /// 获取所有进程内存的使用情况
        /// 结果按使用大小排序
        /// </summary>
        /// <param name="gatherSameNameProcess">是否把同名进程的内存大小加在一起</param>
        public static SimpleMemoryUsage[] GetMemeoryUsage(bool gatherSameNameProcess=true)
        {
            List<SimpleMemoryUsage> infos = new List<SimpleMemoryUsage>();
            foreach (Process pro in Process.GetProcesses())
            {
                SimpleMemoryUsage item = new SimpleMemoryUsage();

                item.ProcessName = pro.ProcessName;
                item.Usage = pro.WorkingSet64;
                // item.Usage = pro.PrivateMemorySize64;
                infos.Add(item);
            }

            SimpleMemoryUsage[] result;
            if (gatherSameNameProcess)
            {
                var r = from n in infos
                        group n by n.ProcessName into ng
                        select new SimpleMemoryUsage(ng.Key, ng.Sum(i => i.Usage)) into mm
                        orderby -mm.Usage
                        select mm;
                result = r.ToArray();
            }
            else
            {
                result = infos.OrderByDescending(e => e.Usage).ToArray();
            }
            return result;
        }

        public static string GetStorageSizeString(long storageSize)
        {
            const int MAX_LENTH = 3;

            string[] units = { "K", "M", "G", "T", "P" };
            string unit = " ";
            double s = storageSize;
            foreach (string u in units)
            {
                if ((int)s / 1000 != 0)
                {
                    unit = u;
                    s /= 1024;
                }
                else
                    break;
            }
            
            String ss = s.ToString();
            int i = ss.IndexOf('.');
            if(i >= MAX_LENTH - 1)
            {
                ss = ss.Substring(0, i);
            }
            else if(i >= 0)
            {
                ss = ss.Substring(0, MAX_LENTH);
                if(ss.Substring(i + 1).All(c => c == '0'))
                    ss = ss.Substring(0, i);
            }
            return String.Format("{0}{1}B", ss, unit.ToString());
        }
    }
}
