using Prometheus;
using System.Net;
using bb_exporter.model;
using Newtonsoft.Json;
using bb_exporter;
using Microsoft.Extensions.Configuration;
using System.Timers;

class Program
{
    private static System.Timers.Timer _refreshDataTimer;

    private static string APIURL;
    private static string APIPassword;
    private static int APIRefreshTime;
    private static int metricsServerPort;

    // Custom counters
    private static Gauge _bb_device_cpu_total = Metrics.CreateGauge("bb_device_cpu_total", "bb_device_cpu_total");
    private static Gauge _bb_device_cpu_user = Metrics.CreateGauge("bb_device_cpu_user", "bb_device_cpu_user");
    private static Gauge _bb_device_cpu_system = Metrics.CreateGauge("bb_device_cpu_system", "bb_device_cpu_system");
    private static Gauge _bb_device_cpu_idle = Metrics.CreateGauge("bb_device_cpu_idle", "bb_device_cpu_idle");
    private static Gauge _bb_device_mem_free = Metrics.CreateGauge("bb_device_mem_free", "bb_device_mem_free");
    private static Gauge _bb_device_mem_total = Metrics.CreateGauge("bb_device_mem_total", "bb_device_mem_total");
    //Gauge bb_device_temperature_current = Metrics.CreateGauge("bb_device_temperature_current", "bb_device_temperature_current");
    private static Gauge _bb_wan_ip_stats_rx_bytes = Metrics.CreateGauge("bb_wan_ip_stats_rx_bytes", "bb_wan_ip_stats_rx_bytes");
    private static Gauge _bb_wan_ip_stats_tx_bytes = Metrics.CreateGauge("bb_wan_ip_stats_tx_bytes", "bb_wan_ip_stats_tx_bytes");
    private static Gauge _bb_lan_stats_rx_bytes = Metrics.CreateGauge("bb_lan_stats_rx_bytes", "bb_lan_stats_rx_bytes");
    private static Gauge _bb_lan_stats_tx_bytes = Metrics.CreateGauge("bb_lan_stats_tx_bytes", "bb_lan_stats_tx_bytes");
    private static Gauge _bb_wireless_24_stats_rx_bytes = Metrics.CreateGauge("bb_wireless_24_stats_rx_bytes", "bb_wireless_24_stats_rx_bytes");
    private static Gauge _bb_wireless_24_stats_tx_bytes = Metrics.CreateGauge("bb_wireless_24_stats_tx_bytes", "bb_wireless_24_stats_tx_bytes");
    private static Gauge _bb_wireless_5_stats_rx_bytes = Metrics.CreateGauge("bb_wireless_5_stats_rx_bytes", "bb_wireless_5_stats_rx_bytes");
    private static Gauge _bb_wireless_5_stats_tx_bytes = Metrics.CreateGauge("bb_wireless_5_stats_tx_bytes", "bb_wireless_5_stats_tx_bytes");

    static void _RefreshDataFromAPI(object sender, ElapsedEventArgs e)
    {
        try
        {
            Console.WriteLine("Logging in BBox API...");

            // BB API calls
            BBApiClient.api_domain = APIURL;
            BBApiClient.password = APIPassword;
            BBApiClient.Login("/api/v1/login");

            Console.WriteLine("Calling API routes...");

            //bb_exporter.model.services.services_root services_root = BBApiClient.GetMetrics<bb_exporter.model.services.services_root>("/api/v1/services");
            bb_exporter.model.cpu.device_cpu device_cpu = BBApiClient.GetMetrics<bb_exporter.model.cpu.device_cpu>("/api/v1/device/cpu");
            bb_exporter.model.mem.device_mem device_mem = BBApiClient.GetMetrics<bb_exporter.model.mem.device_mem>("/api/v1/device/mem");
            //bb_exporter.model.mem.device_mem device = BBApiClient.GetMetrics<bb_exporter.model.mem.device_mem>("/api/v1/device");
            bb_exporter.model.wan.wan_ip_stats wan_ip_stats = BBApiClient.GetMetrics<bb_exporter.model.wan.wan_ip_stats>("/api/v1/wan/ip/stats");
            bb_exporter.model.lan.lan_stats lan_stats = BBApiClient.GetMetrics<bb_exporter.model.lan.lan_stats>("/api/v1/lan/stats");
            bb_exporter.model.wireless.wireless_stats wireless_24_stats = BBApiClient.GetMetrics<bb_exporter.model.wireless.wireless_stats>("/api/v1/wireless/24/stats");
            bb_exporter.model.wireless.wireless_stats wireless_5_stats = BBApiClient.GetMetrics<bb_exporter.model.wireless.wireless_stats>("/api/v1/wireless/5/stats");

            Console.WriteLine("Logging out BBox API...");

            BBApiClient.Logout("/api/v1/logout");

            // Services
            //Gauge bb_device_services_ = Metrics.CreateGauge("bb_device_cpu_total", "bb_device_cpu_total");
            //bb_device_cpu_total.Set(services_root.services.dhcp.enable);

            // Set gauges values

            Console.WriteLine("Setting custom counters values...");

            // CPU
            _bb_device_cpu_total.Set(device_cpu.device.time.total);
            _bb_device_cpu_user.Set(device_cpu.device.time.user);
            _bb_device_cpu_system.Set(device_cpu.device.time.system);
            _bb_device_cpu_idle.Set(device_cpu.device.time.idle);

            // Memory
            _bb_device_mem_total.Set(device_mem.device.mem.total);
            _bb_device_mem_free.Set(device_mem.device.mem.free);

            // Temperature


            // Wan
            _bb_wan_ip_stats_rx_bytes.Set(wan_ip_stats.wan.ip.stats.rx.bytes);
            _bb_wan_ip_stats_tx_bytes.Set(wan_ip_stats.wan.ip.stats.tx.bytes);

            // Lan
            _bb_lan_stats_rx_bytes.Set(lan_stats.lan.stats.rx.bytes);
            _bb_lan_stats_tx_bytes.Set(lan_stats.lan.stats.tx.bytes);

            // Wireless
            _bb_wireless_24_stats_rx_bytes.Set(wireless_24_stats.wireless.ssid.stats.rx.bytes);
            _bb_wireless_24_stats_tx_bytes.Set(wireless_24_stats.wireless.ssid.stats.tx.bytes);
            _bb_wireless_5_stats_rx_bytes.Set(wireless_5_stats.wireless.ssid.stats.rx.bytes);
            _bb_wireless_5_stats_tx_bytes.Set(wireless_5_stats.wireless.ssid.stats.tx.bytes);

            Console.WriteLine(string.Format("Sleeping {0} seconds...", APIRefreshTime));
        }
        catch (Exception iex)
        {
            Console.WriteLine(string.Format("An error occured : {0} - {1}", iex.Message, iex.StackTrace));
        }
    }
    
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Starting bb_exporter...");
            Console.WriteLine("Reading settings file...");

            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            APIURL = config["BBoxAPIURL"];
            APIPassword = config["BBoxPassword"];
            APIRefreshTime = int.Parse(config["BBoxAPIRefreshTime"]);
            metricsServerPort = int.Parse(config["MetricsServerListeningPort"]);

            Console.WriteLine("Starting metrics webserver...");

            // Create metrics webserver
            var metricServer = new MetricServer(metricsServerPort);
            metricServer.Start();

            Console.WriteLine("Creating custom counters...");

            // Init BB API Client
            BBApiClient.Init();

            // Configure Timer
            _refreshDataTimer = new System.Timers.Timer(APIRefreshTime * 1000);
            _refreshDataTimer.Elapsed += new ElapsedEventHandler(_RefreshDataFromAPI);
	        _refreshDataTimer.Enabled = true;
            // Execute en Start
            _RefreshDataFromAPI(null, null);

            Console.Read();
        }
        catch(Exception ex)
        {
            Console.WriteLine(string.Format("An error occured --> exit : {0} - {1}", ex.Message, ex.StackTrace));
        }
    }
}