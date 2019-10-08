using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace CarWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleCarApiRequest carAPI = new SingleCarApiRequest();
            carAPI.RequestVehicleTypesForMake("mercedes");
            Console.WriteLine(carAPI.SingleResponseObject.ToString()); 
        }
    }

    public class SingleCarApiRequest
    {
        public RestClient Client { get; set; }
        private string base_url;
        public JObject SingleResponseObject { get; set; }

        public SingleCarApiRequest()
        {
            Client = new RestClient();
            Client.BaseUrl = new Uri("https://vpic.nhtsa.dot.gov/api/vehicles");
        }

        //mercedes
        public void RequestVehicleTypesForMake(string brand)
        {
            brand = brand.ToLower();
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"/GetVehicleTypesForMake/{brand}?format=json";
            IRestResponse response = Client.Execute(request);
            SingleResponseObject = JObject.Parse(response.Content);
        }
    }
}
