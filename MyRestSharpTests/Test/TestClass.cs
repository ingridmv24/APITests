using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;

namespace MyRestSharpTests.Test
{
    [TestClass]
    public class TestClass
    {
        string uri = "https://reqres.in";

        [TestMethod]
        public void Test_1_ListUsers()
        {
            RestClient client = new RestClient(uri);

            RestRequest request = new RestRequest("api/users?page=1", Method.Get);

            RestResponse response = client.ExecuteAsync(request).Result;

            Console.WriteLine(response.Content);

            Assert.AreEqual(200,(int)response.StatusCode);
        }

        [TestMethod]
        public void Test_2_SpecificUser()
        {
            RestClient client = new RestClient(uri);

            var apiUser = 2;

            RestRequest request = new RestRequest($"api/users/{apiUser}", Method.Get);

            RestResponse response = client.ExecuteAsync(request).Result;

            Console.WriteLine(response.Content);

            Assert.AreEqual(200,(int)response.StatusCode);
        }

        [TestMethod]
        public void Test_3_CreateUser()
        {
            RestClient client = new RestClient(uri);

            RestRequest request = new RestRequest("api/users",Method.Post);

            var body = new
            {
                name = "morpheus",
                job = "leader"
            };

            request.AddJsonBody(body);

            RestResponse response = client.ExecuteAsync(request).Result;

            Console.WriteLine(response.Content);
            Assert.AreEqual(201,(int)response.StatusCode);
            ;

        }

        [TestMethod]
        public void Test_4_DeleteUser()
        {
            RestClient client = new RestClient(uri);

            var aPiUserDelete = 2;

            RestRequest request = new RestRequest($"/api/users/{aPiUserDelete}", Method.Delete);

            RestResponse response = client.ExecuteAsync(request).Result;

            Console.WriteLine(response.Content);

            Assert.AreEqual(204,(int)response.StatusCode);
                 
        }

        [TestMethod]
        public void Test_5_RegisterService()
        {
            RestClient client = new RestClient(uri);

            RestRequest request = new RestRequest("api/register",Method.Post);

            var body = new
            {
                email = "sydney@fife"
            };

            request.AddJsonBody(body);

            RestResponse response = client.ExecuteAsync(request).Result;

            Console.WriteLine(response.Content);
            Assert.AreEqual(400, (int)response.StatusCode);
        }
    }   
}
