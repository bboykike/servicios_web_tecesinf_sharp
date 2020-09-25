using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApi.Models.Email;
using System.Net.Mail;

namespace RestApi.Controllers
{
    public class EmailController : ApiController
    {


        public IHttpActionResult sendEmail(SendEmail ec)
        {
            string subject = ec.subject;
            string body = ec.body;
            string to = ec.to;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("kikekc10@gmail.com");
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("kikekc10@gmail.com", "Bboykike1026@");
            smtp.Send(mm);
            return Ok(true);
        }
    }
}
