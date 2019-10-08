using System;
using NUnit.Framework;
using CarWebApi;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;

namespace CarWebApi.Test
{
    [TestFixture]
    public class CarWebApiTest
    {
        SingleCarApiRequest carApiRequest;
        JObject result;
        IRestResponse response;
        IList<RestSharp.Parameter> headers;
        public CarWebApiTest()
        {
            carApiRequest = new SingleCarApiRequest();
            carApiRequest.RequestVehicleTypesForMake("mercedes");
            headers = carApiRequest.Response.Headers;
            result = carApiRequest.SingleResponseObject;
        }

        [Test]
        public void Valid_Brand_Test()
        {
            Assert.AreEqual("Response returned successfully", result["Message"].ToString());
            //Number on the right greter than zero; With a valid request, count should be greater than zero;
            Assert.LessOrEqual(0, Int32.Parse(result["Count"].ToString()));
        }

        [Test]
        public void Search_Criteria_Test()
        {
            Assert.AreEqual("Make: mercedes", result["SearchCriteria"].ToString());
        }

        [Test]
        public void Results_Make_Id_Test()
        {
            Assert.AreEqual("449", result["Results"][0]["MakeId"].ToString());
        }

        [Test]
        public void Results_Make_Name_Test()
        {
            Assert.AreEqual("Mercedes-Benz", result["Results"][1]["MakeName"].ToString());
        }

        [Test]
        public void Results_Vehicle_Type_Id_Test()
        {
            Assert.AreEqual("5", result["Results"][2]["VehicleTypeId"].ToString());
        }

        [Test]
        public void Results_Vehicle_Type_Name_Test()
        {
            Assert.AreEqual("Multipurpose Passenger Vehicle (MPV)", result["Results"][3]["VehicleTypeName"].ToString());
        }

        [Test]
        public void Header_Pragma_Test()
        {
            Assert.AreEqual("Pragma=no-cache", headers[0].ToString());
        }

        [Test]
        public void Header_Access_Controll_Allow_Origin_Test()
        {
            Assert.AreEqual("Access-Control-Allow-Origin=*", headers[1].ToString());
        }

        [Test]
        public void Header_SSL_TLS_Test()
        {
            Assert.AreEqual("SSL-TLS=TLSv1.2", headers[2].ToString());
        }

        [Test]
        public void Header_Strict_Transport_Security_Test()
        {
            Assert.AreEqual("Strict-Transport-Security=max-age=31536000", headers[3].ToString());
        }

        [Test]
        public void Header_Content_Length_Test()
        {
            Assert.AreEqual("Content-Length=582", headers[4].ToString());
        }

        [Test]
        public void Header_Cache_Control_Test()
        {
            Assert.AreEqual("Cache-Control=no-cache", headers[5].ToString());
        }

        [Test]
        public void Header_Content_Type_Test()
        {
            Assert.AreEqual("Content-Type=application/json", headers[6].ToString());
        }

        //[Test]
        //public void Header_Date_Test()
        //{
        //    Assert.AreEqual(String.Format("Date={0}", DateTime.Now.ToString()), headers[7].ToString());
        //}

        [Test]
        public void Header_Expires_Test()
        {
            Assert.AreEqual("Expires=-1", headers[8].ToString());
        }

        [Test]
        public void Header_Server_Test()
        {
            Assert.AreEqual("Server=Microsoft-IIS/8.5", headers[9].ToString());
        }

        [Test]
        public void Header_X_AspNet_Verson_Test()
        {
            Assert.AreEqual("X-AspNet-Version=4.0.30319", headers[10].ToString());
        }

        [Test]
        public void Header_X_Powered_By_Test()
        {
            Assert.AreEqual("X-Powered-By=ASP.NET", headers[11].ToString());
        }
    }
}
