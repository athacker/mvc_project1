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

        
        /// RESTful GET feedback collection
        public IEnumerable<Feedback> Get() {
            return _repo.GetFeedback().OrderByDescending(t => t.CommentDate ).Take(50) ;
       }

        //  RESTful POST feedback
        public HttpResponseMessage Post([FromBody]string _comment) {

            Feedback newFeedback = new Feedback( );
            newFeedback.CommentDate = DateTime.UtcNow;
            newFeedback.Comment = _comment;
         //   newFeedback.User = User.Identity.Name;//set to logged on user.
            newFeedback.User = "grthacker@comcast.net";
       
          if (_repo.AddFeedback(newFeedback) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newFeedback);//201 -- success
            }
            else {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


















    }
}
