using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Utilities
{
    class RestApiClient
    {


    public IRestResponse postAPI(string url, RestRequest request )
        {
            var client = new RestClient(url);
           return client.Post(request);
        }

        public string getAccessToekn()
        {
            var request = new RestRequest();
            request.AddHeader("x-api-key", "cma9l9DKGU50XQ1NKGmw1a1s0YObxaum8lov8dCL");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", "serviceaccount_LfFVdVeN");
            request.AddParameter("client_secret", "85cbZ87vyOMk");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", "SERVICE_ACCOUNTS");
            IRestResponse response = postAPI(ConfigurationManager.AppSettings.Get("ApiOauthUrl"), request);
            Assert.IsTrue(((int)response.StatusCode == 200));
            JObject obs = JObject.Parse(response.Content);
            return obs.GetValue("access_token").ToString();
        }

        

    }

   
}
