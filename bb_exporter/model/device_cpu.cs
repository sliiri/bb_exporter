using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb_exporter.model.cpu
{
    public class device_cpu
    {
        public Device device { get; set; }
    }

    public class Device
    {
        public Time time { get; set; }
        public Process process { get; set; }
    }

    public class Time
    {
        public int total { get; set; }
        public int user { get; set; }
        public int nice { get; set; }
        public int system { get; set; }
        public int io { get; set; }
        public int idle { get; set; }
        public int irq { get; set; }
    }

    public class Process
    {
        public int created { get; set; }
        public int running { get; set; }
        public int blocked { get; set; }
    }

}
