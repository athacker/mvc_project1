using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_project1.Data
{
    public class Feedback
    {
        public int Id { get; set; }
        public DateTime CommentDate { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }


        public ICollection<Reply> Replies { get; set; }
    }
}