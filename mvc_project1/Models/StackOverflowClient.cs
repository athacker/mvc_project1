using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_project1.Models
{
    public class StackOverflowClient : DotNetOpenAuth.AspNet.Clients.OAuth2Client 
    {


        private const string AuthorizationEP = "https://stackexchange.com/oauth";
        private const string TokenEP = "https://stackexchange.com/oauth/access_token";
        private readonly string _appId;
        private readonly string _appSecret;
        

        public StackOverflowClient(string appId, string appSecret) : base("stackoverflow")
        {
            this._appId = appId;
            this._appSecret = appSecret;
            
        }


        protected override Uri GetServiceLoginUrl(Uri returnUrl)
        {
            return new Uri(
                        AuthorizationEP
                        + "?client_id=" + this._appId
                        + "&redirect_uri=" + HttpUtility.UrlEncode(returnUrl.ToString())
                        + "&scope=email,user_about_me"
                        + "&display=page"
                    );
        }





        protected override IDictionary<string, string> GetUserData(string accessToken)
        {
            throw new NotImplementedException();
        }

        protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
        {
            throw new NotImplementedException();
        }
    }
}