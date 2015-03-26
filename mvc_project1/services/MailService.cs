using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace mvc_project1.Services
{
    public class MailService : mvc_project1.Services.IMailService
    {
        //sends developer comments from page...  
        public bool SendMail(string from, string to, string subject, string body) {
            bool isSuccess = true;
            try{ 
                var msg = new MailMessage(from, to, subject, body);
                var client = new SmtpClient();
                client.Send(msg);
            }catch(Exception e){
                isSuccess = false;
                
            }

            return isSuccess;
        }
    }
}