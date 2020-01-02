using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using UnitTestProject1.Utilities;

namespace UnitTestProject1.StepDefs
{
    [Binding]
    public class RestAPIOperationsSteps
    {
        RestApiClient restApiClient = new RestApiClient();
        RestRequest request;
        IRestResponse response;
        JObject responseJson;
        [Given(@"panda oath credentials are available")]
        public void GivenPandaOathCredentialsAreAvailable()
        {
            request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("RequestId", "c51315ea-dac9-4966-b995-01bed4012fe9");
            request.AddHeader("x-api-key", "cma9l9DKGU50XQ1NKGmw1a1s0YObxaum8lov8dCL");
            request.AddHeader("Authorization", "Bearer "+ restApiClient.getAccessToekn());
            JObject body = new JObject();
            body.Add("requesterId","test.user@retailer");
            body.Add("retailerCustomerId", "ZHG5ZKYJQ6UDZND4IVA2LAQSKE");
            request.AddJsonBody(body.ToString());  
        }
        
        [When(@"make a get call to Oauth token API")]
        public void WhenMakeAGetCallToOauthTokenAPI()
        {
            string url = ConfigurationManager.AppSettings.Get("ApiSuperUserUrl");
            response = restApiClient.postAPI(url, request);
            Console.WriteLine("post response body: "+response.Content);
        }

        [Then(@"access token is received")]
        public void ThenAccessTokenIsReceived()
        {
            Assert.IsTrue((int)response.StatusCode == 200);
            responseJson = JObject.Parse(response.Content);
            Console.WriteLine("redirectUrl is: "+responseJson.GetValue("redirectURL"));
        }
    }
}
