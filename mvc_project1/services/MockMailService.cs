﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace mvc_project1.Services
{
    public class MockMailService : IMailService
    {

        public bool SendMail(string from, string to, string subject, string body)
        {
            Debug.WriteLine(string.Concat("Send Mail: " + subject));
            return true;
        }
    }
}