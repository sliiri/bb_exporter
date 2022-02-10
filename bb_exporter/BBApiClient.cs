using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bb_exporter
{
    public static class BBApiClient
    {
        private static CookieContainer _cookies = new CookieContainer();
        private static HttpClientHandler _handler = new HttpClientHandler();
        private static string _password = string.Empty;
        private static string _api_domain = string.Empty;

        public static string password { get => _password; set => _password = value; }
        public static string api_domain { get => _api_domain; set => _api_domain = value; }

        public static void Init()
        {
            _handler.CookieContainer = _cookies;
        }

        public static void Login(string route)
        {
            StringContent auth = new StringContent(string.Format("password={0}", _password));
            Uri uri = new Uri(string.Format("{0}{1}", _api_domain, route));
            HttpClient client = new HttpClient(_handler);
            var response = client.PostAsync(uri, auth);
            if (!response.Result.IsSuccessStatusCode)
            { 
                throw new Exception(string.Format("An error occurs during the login : http errorcode = {0} - {1}",
                    (int)response.Result.StatusCode,
                    response.Result.StatusCode.ToString()));
            }
        }

        public static void Logout(string route)
        {
            StringContent auth = new StringContent(string.Empty);
            Uri uri = new Uri(string.Format("{0}{1}", _api_domain, route));
            HttpClient client = new HttpClient(_handler);
            var response = client.PostAsync(uri, auth);
        }

        public static T GetMetrics<T>(string route)
        {
            HttpClient client = new HttpClient(_handler);
            var response = client.GetAsync(string.Format("{0}{1}", _api_domain, route));
            string res = response.Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<T>>(res).FirstOrDefault();
        }
    }
}
