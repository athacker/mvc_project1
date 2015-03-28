using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mvc_project1.Data;

namespace mvc_project1.Controllers
{


    /// <summary>
    /// Restfull Calls to support Feedback Pages... 
    /// </summary>
    public class FeedbackController : ApiController
    {
        private IMvc_Project1Repository _repo;
        public FeedbackController( IMvc_Project1Repository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Supports Get restful call for Feedback
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Feedback> Get() {
            return _repo.GetFeedback().OrderByDescending(t => t.CommentDate ).Take(50) ;
       }

    }
}
