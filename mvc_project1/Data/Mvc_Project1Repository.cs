using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_project1.Data
{
    public class Mvc_Project1Repository : IMvc_Project1Repository
    {
        Mvc_Project1Context _ctx;

        public Mvc_Project1Repository(Mvc_Project1Context ctx ) { 
            _ctx = ctx;
        }

        public IQueryable<Feedback> GetFeedback()
        {
            return _ctx.Feedback;
        }

        public IQueryable<Reply> GetRepliesByFeedback(int feedbackId)
        {
            return _ctx.Replies.Where(r => r.FeedbackId == feedbackId);
        }
    }
}