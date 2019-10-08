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
        public void TestValidBrand()
        {
            carApiRequest.RequestVehicleTypesForMake("mercedes");
            Assert.AreEqual("Response returned successfully", carApiRequest.SingleResponseObject["Message"].ToString());
            //Number on the right greter than zero; With a valid request, count should be greater than zero;
            Assert.LessOrEqual(0, Int32.Parse(carApiRequest.SingleResponseObject["Count"].ToString()));
        }

        [Test]
        public void TestInvliadBrand()
        {
            //Testing invalid brand, should return zero of row
            carApiRequest.RequestVehicleTypesForMake("asdasdkjdhsdjasj");
            Assert.AreEqual("0", carApiRequest.SingleResponseObject["Count"].ToString());
        }
    }
}
