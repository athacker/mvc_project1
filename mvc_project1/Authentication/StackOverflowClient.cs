using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;

namespace mvc_project1.Authentication
{
    public class StackOverflowClient : DotNetOpenAuth.AspNet.Clients.OAuth2Client 
    {
        private const string AuthorizationEP = "https://stackexchange.com/oauth/";
 
        private const string TokenEndPoint = "https://stackexchange.com/oauth/access_token";
        private readonly string _appId ="4537";
        private readonly string _appSecret = "Npid*SCP3vyEQtBU3FOGA((";
        

        public StackOverflowClient(string appId, string appSecret) : base("stackoverflow")
        {
            this._appId = appId;
            this._appSecret = appSecret;
            
        }


        protected override Uri GetServiceLoginUrl(Uri returnUrl)
        {
            return new Uri(
                        AuthorizationEP
                        + "?client_id=" + _appId
                        + "&redirect_uri=" + HttpUtility.UrlEncode(returnUrl.ToString())
                        + "&no_expiry"
                       
                       
                    );
        }





        protected override IDictionary<string, string> GetUserData(string accessToken)
        {
            WebClient client = new WebClient();
            string content = client.DownloadString( TokenEndPoint + accessToken);

            dynamic data = Json.Decode(content);

            return new Dictionary<string, string> { 
             
                {
                    "repuation",
                     data.repuation
                },
                
                {
                    "badges",
                     data.badges
                }
            };

        }






        protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(TokenEndPoint);

            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write("grant_type=authorization_code");
                streamWriter.Write("&client_id=" + HttpUtility.UrlEncode(this._appId));
                streamWriter.Write("&client_secret=" + HttpUtility.UrlEncode(this._appSecret));
                streamWriter.Write("&redirect_uri=" + HttpUtility.UrlEncode(returnUrl.AbsoluteUri));
                streamWriter.Write("&code=" + HttpUtility.UrlEncode(authorizationCode));
                streamWriter.Flush();
            }



            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();


            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    String response = streamReader.ReadToEnd();
                    var queryString = HttpUtility.ParseQueryString(response);
                    return queryString["access_token"];
                }
            }
            return String.Empty;





       }

















          
        }
}