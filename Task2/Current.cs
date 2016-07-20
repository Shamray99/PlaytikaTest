using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task2
{
    [TestClass]
    public class Current
    {
        [TestMethod]
        public void TestMethod1()
        {
            //string sentURL = "http://api.openweathermap.org/data/2.5/forecast/city?id=524901&APPID=2f6055ee48bf01410fc7e59574791190";
            string sentURL = "http://api.openweathermap.org/data/2.5/weather?q=London&APPID=2f6055ee48bf01410fc7e59574791190";

            using (var client = new WebClient())
            {
                try
                {
                    var response = client.DownloadString(sentURL);

                    byte[] bytes = Encoding.Default.GetBytes(response);
                    response = Encoding.UTF8.GetString(bytes);
                    //var dict = new JsonConvert.Deserialize<Dictionary<string, object>>(json);

                    Whether jResult = JsonConvert.DeserializeObject<Whether>(response);

                }
                catch (Exception ex)
                {
                    Assert.Fail("Error!!! " + ex.ToString());
                }
            }
        }
    }

    public class Whether
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("dt")]
        public string Dt { get; set; }

        [JsonProperty("cod")]
        public string Code { get; set; }

        [JsonProperty("coord")]
        public JObject Coord { get; set; }

        [JsonProperty("wind")]
        public JObject Temp_max { get; set; }
    }
}
