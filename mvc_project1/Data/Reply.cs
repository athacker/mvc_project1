using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvc_project1.Data
{
    public class Reply
    {
        public int Id{ get; set; }
        public string ReplyComment { get; set; }
        public DateTime ReplyDate { get; set; }


        public int FeedbackId { get; set; }


    }
}
