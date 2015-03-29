using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project1.Authentication;
using mvc_project1.Services;
using mvc_project1.Data;


namespace mvc_project1.Controllers
{
    public class HomeController : Controller
    {
        //inject via NinjectwebCommon -- RegisterServices Method
        public HomeController(IMailService mailService, IMvc_Project1Repository repository)
        {
            _mail = mailService;
            _repo = repository;
        }

        private IMailService _mail;
        private static string DEVELOPER_EMAIL = "grthacker@comcast.net";
        private IMvc_Project1Repository _repo;
        

        public ActionResult Index()
        {
            ViewBag.Message = "";
             return View();
        }




        //Methods below are Not Used... 

        public ActionResult About()
        {
            ViewBag.Message = "";
            return View();
        }



         
        public ActionResult Contact()
        {
            ViewBag.Title = "Developer Contact Information";
            ViewBag.Message = "Andrea Thacker";
            return View();
        }



        [Authorize]
        public ActionResult Feedback() {

            var feedback = _repo.GetFeedback().OrderByDescending(t => t.CommentDate ).Take(25).ToList();
             return View(feedback);
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
