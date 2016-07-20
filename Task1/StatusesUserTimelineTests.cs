using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using Twitterizer;

namespace Task1
{
    [TestClass]
    public class StatusesUserTimelineTests
    {
        public string screenName;
        public Authentication auth;

        [TestInitialize]
        public void Auth()
        {
            string consumerKey = "rZSQo6AibXu34ieERdOnT4n66";
            string consumerSecret = "Y2jQOKuXClVoZPSLXKcjWBLaXziOSWVhidR2JdgwQa4lwln6Te";
            string requestToken = "755097775520571392-mJ1eKIBSy5sqjt0hBecX7emLAXoBZYr";
            string requestTokenSecret = "IQoNv2mSxVyH9PLn6aigc3FpzPe0SI6OYaD9QwuP14oCZ";
            screenName = "testtesttest";

            auth = new Authentication(consumerKey, consumerSecret, requestToken, requestTokenSecret);
        }

        [TestMethod]
        public void ResponseVarificationTest()
        {
            try
            {
                string searchURL = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=" + screenName;

                string formattedUri = String.Format(CultureInfo.InvariantCulture, searchURL, "");

                Uri url = new Uri(searchURL);
                Twitterizer.WebRequestBuilder wb = new Twitterizer.WebRequestBuilder(url, HTTPVerb.GET, auth.GetAuthentication());
                HttpWebResponse wr = wb.ExecuteRequest();
                StreamReader sr = new StreamReader(wr.GetResponseStream());
                string result = sr.ReadToEnd();

                if (string.IsNullOrEmpty(result))
                {
                    Assert.Fail("No Response!!!");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("No Response!!! " + e.ToString());
            }
            

        }

        [TestMethod]
        public void Test99()
        {
            string searchURL = "";
           
            // "https://api.twitter.com/1.1/direct_messages/new.json?text=hello%2C%20tworld.%20welcome%20to%201.1.&screen_name=" + screenName;

            //"https://api.twitter.com/1.1/users/show.json?screen_name=" + screenName + "&include_entities=true";

            //"https://api.twitter.com/1.1/statuses/home_timeline.json";
            
            

            string formattedUri = String.Format(CultureInfo.InvariantCulture, searchURL, "");

            Uri url = new Uri(searchURL);
            Twitterizer.WebRequestBuilder wb = new Twitterizer.WebRequestBuilder(url, HTTPVerb.GET, auth.GetAuthentication());
            HttpWebResponse wr = wb.ExecuteRequest();
            StreamReader sr = new StreamReader(wr.GetResponseStream());
            string result = sr.ReadToEnd();

            Data jResult = JsonConvert.DeserializeObject<Data>(result);
            //List<Follower> jResult = JsonConvert.DeserializeObject<Follower[]>(result).ToList();
            //List<Follower> jResult = new List<Follower>(JsonConvert.DeserializeObject<Follower[]>(result));
            Type myType = jResult.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(jResult, null);
                Console.WriteLine(prop.Name + ": " + propValue);
            } 
        }
    }
       
    public class Data
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("id_str")]
        public string IdStr { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
