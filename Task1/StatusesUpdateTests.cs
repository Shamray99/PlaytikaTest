using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using Twitterizer;
using System.Globalization;

namespace Task1
{
    [TestClass]
    public class StatusesUpdateTests
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
                string searchURL = "https://api.twitter.com/1.1/statuses/update.json?status=Maybe%20he%27ll%20finally%20find%20his%20keys.%20%23peterfalk";

                string formattedUri = String.Format(CultureInfo.InvariantCulture, searchURL, "");

                Uri url = new Uri(searchURL);
                Twitterizer.WebRequestBuilder wb = new Twitterizer.WebRequestBuilder(url, HTTPVerb.POST, auth.GetAuthentication());
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
    }
}
