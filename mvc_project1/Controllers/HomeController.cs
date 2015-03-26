using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project1.Models;
using mvc_project1.Services;

namespace mvc_project1.Controllers
{
    public class HomeController : Controller
    {
        //inject via NinjectwebCommon -- RegisterServices Method
        public HomeController(IMailService mailService)
        {
            _mail = mailService;
        }

        private IMailService _mail;
        private static string DEVELOPER_EMAIL = "grthacker@comcast.net";
       // private static string DEVELOPER_EMAIL = "andrea.thacker@outlook.com";

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Developer Contact Information";
            ViewBag.Message = "Andrea Thacker";
            return View();
        }





        [HttpPost]
        public ActionResult Contact(string comments, string email)
        {
            var msg = string.Format(comments);

            _mail.SendMail(email, DEVELOPER_EMAIL, "CODE CHALLENGE FEEDBACK", msg);

            ViewBag.Thanks = "Thank you for your feedback!";   
            return View();
        }

    }
}
