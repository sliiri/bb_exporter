using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb_exporter.model.services
{
    public class services_root
    {
        public Services services { get; set; }
    }

    public class Services
    {
        public DateTime now { get; set; }
        public Firewall firewall { get; set; }
        public Dyndns dyndns { get; set; }
        public Dhcp dhcp { get; set; }
        public Nat nat { get; set; }
        public Upnp upnp { get; set; }
        public Remote remote { get; set; }
        public Hotspot hotspot { get; set; }
        public Parentalcontrol parentalcontrol { get; set; }
        public Notification notification { get; set; }
        public Wifischeduler wifischeduler { get; set; }
        public Voipscheduler voipscheduler { get; set; }
        public Usb usb { get; set; }
    }

    public class Firewall
    {
        public int status { get; set; }
        public int enable { get; set; }
        public int nbrules { get; set; }
    }

    public class Dyndns
    {
        public int state { get; set; }
        public int enable { get; set; }
        public int nbrules { get; set; }
    }

    public class Dhcp
    {
        public int status { get; set; }
        public int enable { get; set; }
        public int nbrules { get; set; }
    }

    public class Nat
    {
        public int status { get; set; }
        public int enable { get; set; }
        public int nbrules { get; set; }
    }

    public class Upnp
    {
        public Igd igd { get; set; }
    }

    public class Igd
    {
        public int status { get; set; }
        public int enable { get; set; }
        public int nbrules { get; set; }
    }

    public class Remote
    {
        public Proxywol proxywol { get; set; }
        public Admin admin { get; set; }
    }

    public class Proxywol
    {
        public int status { get; set; }
        public int enable { get; set; }
        public string ip { get; set; }
    }

    public class Admin
    {
        public int status { get; set; }
        public int enable { get; set; }
        public int port { get; set; }
        public string ip { get; set; }
        public string duration { get; set; }
        public int activable { get; set; }
    }

    public class Hotspot
    {
        public int status { get; set; }
        public int enable { get; set; }
    }

    public class Parentalcontrol
    {
        public int enable { get; set; }
    }

    public class Notification
    {
        public int enable { get; set; }
    }

    public class Wifischeduler
    {
        public int enable { get; set; }
    }

    public class Voipscheduler
    {
        public int enable { get; set; }
    }

    public class Usb
    {
        public Samba samba { get; set; }
        public Printer printer { get; set; }
        public Dlna dlna { get; set; }
    }

    public class Samba
    {
        public int status { get; set; }
        public int enable { get; set; }
    }

    public class Printer
    {
        public int status { get; set; }
        public int enable { get; set; }
    }

    public class Dlna
    {
        public int status { get; set; }
        public int enable { get; set; }
    }
}
