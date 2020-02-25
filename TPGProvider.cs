using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using System.Web;
using TPG.Model;

namespace TPG
{
    class TPGProvider
    {
        public static async Task<RootObject> CallArretsAsync()
        {
            var client = new RestClient("http://prod.ivtr.tpg.ch/");
            var request = new RestRequest("GetTousArrets.json?transporteur=tpg", Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<RootObject>(response.Content);

        }

        public static async Task<DepartsModel> DesparturesAsync(String codeArret)
        {
            var client = new RestClient("http://prod.ivtr.tpg.ch/");
            var request = new RestRequest("GetProchainsDepartsTriHeure.json?transporteur=tpg&codeArret=" + codeArret, Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<DepartsModel>(response.Content);

        }
        public static async Task<TimetableModel> TimetableAsync(ProchainDepart proDep)
        {
            var client = new RestClient("http://prod.ivtr.tpg.ch/");
            var destination = proDep.destinationMajuscule.Replace("+", "%2B");

            var request = new RestRequest("GetTousProchainsDeparts.json?codeArret=" + proDep.codeArret + "&ligne=" + proDep.ligne + "&transporteur=tpg&destination=" + HttpUtility.HtmlEncode(destination), Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<TimetableModel>(response.Content);
        }



    }
}
