using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using QandA.Web.Models;

namespace QandA.Web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "7q6zOjDmP7NabIceLAzmJg",
                consumerSecret: "VUZHUm9Uz7zFn6rVx1jj6zMeiyJKXcjlAXZQ6lvSCJ4");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "518395634920956",
                appSecret: "d9073bfe0578e3266cbba2ce591ecba3");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
