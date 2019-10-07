using System;
using NUnit.Framework;
using CarWebApi;
using Newtonsoft.Json.Linq;

namespace CarWebApi.Test
{
    [TestFixture]
    public class CarWebApiTest
    {
        SingleCarApiRequest carApiRequest;
        public CarWebApiTest()
        {
            carApiRequest = new SingleCarApiRequest();
        }

        [Test]
        public void TestMethod1()
        {
            carApiRequest.RequestVehicleTypesForMake("mercedes");
            Assert.AreEqual("Response returned successfully", carApiRequest.SingleResponseObject["Message"].ToString());

            carApiRequest.RequestVehicleTypesForMake("Honda");
            Assert.AreEqual("Response returned successfully", carApiRequest.SingleResponseObject["Message"].ToString());
        }
    }
}
