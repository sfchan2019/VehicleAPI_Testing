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
        public JObject SingleResponseObject { get; set; }
        public IRestResponse Response { get; set; }

        public SingleCarApiRequest()
        {
            Client = new RestClient();
            Client.BaseUrl = new Uri("https://vpic.nhtsa.dot.gov/api/vehicles");
        }

        //Handle No internet Exception?
        public void RequestVehicleTypesForMake(string brand)
        {
            brand = brand.ToLower();
            RestRequest request = new RestRequest();
            request.Resource = $"/GetVehicleTypesForMake/{brand}?format=json";
            //IRestResponse response = Client.Execute(request);
            Response = Client.Execute(request);
            SingleResponseObject = JObject.Parse(Response.Content);

            foreach (RestSharp.Parameter s in Response.Headers)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }
}
