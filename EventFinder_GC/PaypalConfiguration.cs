using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventFinder_GC
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AWdX4-8HwcNU8tTVgp7Wm-tWyAfhUoCpp5LBnHIQTUhLx1EW34hAgevJyWqi1gGURrsQknq0BMfeeSGp";
            clientSecret = "EDM2qBpmggSkxPkVCnEN5U4IV6ggllOLd9zlz69qF-xy8WhyoeQznogxbToSlGocS5IeOkLV3lCwZ5Ld";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}