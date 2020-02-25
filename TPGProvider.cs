using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Tizen.Network.Connection;
using TPG.Model;

namespace TPG
{
    class TPGProvider
    {
        public static async Task<RootObject> CallArretsAsync()
        {
            ConnectionItem connection = ConnectionManager.CurrentConnection;

            var client = new RestClient("http://prod.ivtr.tpg.ch/");
            var request = new RestRequest("GetTousArrets.json?transporteur=tpg", Method.GET);
            request.RequestFormat = DataFormat.Json;
            if (connection.Type == ConnectionType.Ethernet)
            {
                // Get the current proxy information
                var proxyAddress = ConnectionManager.GetProxy(AddressFamily.IPv4);
                WebProxy webproxy = new WebProxy(proxyAddress, true);
                // Set proxy information to the HttpWebRequest
                client.Proxy = webproxy;
            }
            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<RootObject>(response.Content);

        }

        public static async Task<DepartsModel> DesparturesAsync(String codeArret)
        {
            ConnectionItem connection = ConnectionManager.CurrentConnection;

            var client = new RestClient("http://prod.ivtr.tpg.ch/");
            var request = new RestRequest("GetProchainsDepartsTriHeure.json?transporteur=tpg&codeArret=" + codeArret, Method.GET);
            request.RequestFormat = DataFormat.Json;
            if (connection.Type == ConnectionType.Ethernet)
            {
                // Get the current proxy information
                var proxyAddress = ConnectionManager.GetProxy(AddressFamily.IPv4);
                WebProxy webproxy = new WebProxy(proxyAddress, true);
                // Set proxy information to the HttpWebRequest
                client.Proxy = webproxy;
            }
            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<DepartsModel>(response.Content);

        }
        public static async Task<TimetableModel> TimetableAsync(ProchainDepart proDep)
        {
            ConnectionItem connection = ConnectionManager.CurrentConnection;

            var client = new RestClient("http://prod.ivtr.tpg.ch/");
            var destination = proDep.destinationMajuscule.Replace("+", "%2B");

            var request = new RestRequest("GetTousProchainsDeparts.json?codeArret=" + proDep.codeArret + "&ligne=" + proDep.ligne + "&transporteur=tpg&destination=" + HttpUtility.HtmlEncode(destination), Method.GET);
            request.RequestFormat = DataFormat.Json;
            if (connection.Type == ConnectionType.Ethernet)
            {
                // Get the current proxy information
                var proxyAddress = ConnectionManager.GetProxy(AddressFamily.IPv4);
                WebProxy webproxy = new WebProxy(proxyAddress, true);
                // Set proxy information to the HttpWebRequest
                client.Proxy = webproxy;
            }
            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<TimetableModel>(response.Content);
        }



    }
}
