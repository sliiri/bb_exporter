using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb_exporter.model.lan
{
    public class lan_stats
    {
        public Lan lan { get; set; }
    }

    public class Rx
    {
        public long bytes { get; set; }
        public int packets { get; set; }
        public int packetserrors { get; set; }
        public int packetsdiscards { get; set; }
    }

    public class Tx
    {
        public long bytes { get; set; }
        public int packets { get; set; }
        public int packetserrors { get; set; }
        public int packetsdiscards { get; set; }
    }

    public class Stats
    {
        public Rx rx { get; set; }
        public Tx tx { get; set; }
    }

    public class Lan
    {
        public Stats stats { get; set; }
    }
}