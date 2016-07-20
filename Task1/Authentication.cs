using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
//using System.Web.Script.Serialization;
using System.Linq;
using System.Reflection;
using Twitterizer;

namespace Task1
{
    public class Authentication
    {
        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }
        public string RequestToken { get; private set; }
        public string RequestTokenSecret { get; private set; }

        OAuthTokens oAuthT;

        public Authentication( string consumerKey, string consumerSecret, string requestToken, string requestTokenSecret)
        {
            oAuthT = new OAuthTokens();
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            RequestToken = requestToken;
            RequestTokenSecret = requestTokenSecret;
        }

        public OAuthTokens GetAuthentication()
        {
            oAuthT.AccessToken = RequestToken;
            oAuthT.AccessTokenSecret = RequestTokenSecret;
            oAuthT.ConsumerKey = ConsumerKey;
            oAuthT.ConsumerSecret = ConsumerSecret;
            return oAuthT;
        }


    }
}
