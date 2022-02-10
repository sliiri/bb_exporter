using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb_exporter.model.mem
{
    public class device_mem
    {
        public Device device { get; set; }
    }

    public class Device
    {
        public Mem mem { get; set; }
    }

    public class Mem
    {
        public int total { get; set; }
        public int free { get; set; }
        public int cached { get; set; }
        public int committedas { get; set; }
    }
}
