using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc_project1.Data
{
    public class Mvc_Project1Context : DbContext
    {

        public Mvc_Project1Context() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        
          
        }


        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Reply>Replies { get; set; }





    }
}