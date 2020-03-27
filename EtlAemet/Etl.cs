using EtlAemet.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EtlAemet
{
    public class Etl
    {
        private const string OBSERVACION_CONVENCIONAL_URL = "https://opendata.aemet.es/opendata/api/observacion/convencional/todas";
        private const string API_KEY = "yor api key";
        private const double MIN_LAT = 27.992597;
        private const double MAX_LAT = 28.613522;
        private const double MIN_LON = -16.930934;
        private const double MAX_LON = -16.101789;
        private const double MAX_ALT = 100;

        public List<StationData> GetTenerifeCoastalData()
        {
            //We get the data from all stations in Spain, the filter by coordinates and altitude. Then we group by station Id and from each group we get the more recent observation.
            return GetAllSpainData().Where(sd => 
                sd.lat > MIN_LAT && 
                sd.lat < MAX_LAT && 
                sd.lon > MIN_LON && 
                sd.lon < MAX_LON && 
                sd.alt < MAX_ALT
            ).GroupBy(sd => sd.idema).Select(g => g.OrderByDescending(sd => sd.fint).First()).ToList();
        }

        private List<StationData> GetAllSpainData()
        {
            Encoding encoding = Encoding.GetEncoding("windows-1252"); //AEMET JSON is not in UTF8
            string dataUrl = GenerateDataUrl();
            RestClient restClient = new RestClient(dataUrl);
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("cache-control", "no-cache");
            IRestResponse response = restClient.Execute(restRequest);
            return JsonConvert.DeserializeObject<List<StationData>>(encoding.GetString(response.RawBytes));
        }

        private string GenerateDataUrl()
        {
            string serviceUrl = GenerateServiceUrl();
            RestClient restClient = new RestClient(serviceUrl);
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("cache-control", "no-cache");
            IRestResponse response = restClient.Execute(restRequest);
            return JsonConvert.DeserializeObject<AemetApiResponseObject>(response.Content).datos;
        }

        private string GenerateServiceUrl()
        {
            UriBuilder uriBuilder = new UriBuilder(OBSERVACION_CONVENCIONAL_URL)
            {
                Port = -1
            };
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["api_key"] = API_KEY;
            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }

    }
}
