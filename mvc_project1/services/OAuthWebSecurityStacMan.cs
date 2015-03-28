using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.StacMan;


//OAUTH for StackMan
//Instructions
//Where to Register: http://stackapps.com/apps/oauth/register
//https://api.stackexchange.com/docs/authentication
namespace mvc_project1.Services
{
   // public   class OAuthWebSecurityStacMan :Microsoft.Web.WebPages.OAuth.OAuthWebSecurity
   //public class OAuthWebSecurityStacMan : OpenIdClient

    public static class OAuthWebSecurityStacMan  
    {
      
        public static Boolean RegisterStackManClient() {
            var client = new StacManClient(key: "STACKMAN_KEY", version: "2.1");


             var response = client.Questions.GetAll("stackoverflow",
             page: 1,
             pagesize: 10,
             sort: StackExchange.StacMan.Questions.AllSort.Creation,
             order: Order.Desc,
             filter: "!mDO35lQRaz").Result;

             if (null != response.Data.Items)
             { 
                 foreach (var question in response.Data.Items)
                 {
                     Console.WriteLine(question.Title);
                 }
             }

             return true;
        }



    }
}