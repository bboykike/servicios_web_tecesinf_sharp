using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using RestApi.Models.Email;

namespace RestApi.Controllers
{
    public class SendEmailController : Controller
    {
        // GET: SendEmail
        public ActionResult Index()
        {
            return View();
        }
        [Route("api/Email")]
        public ActionResult Index(SendEmail ec)
        {
            HttpClient hc = new HttpClient();
 
            var consume = hc.PostAsJsonAsync<SendEmail>("Email", ec);
            consume.Wait();

            var sendmail = consume.Result;
            if(sendmail.IsSuccessStatusCode)
            {
                ViewBag.message = "Se ha enviado" + ec.to.ToString();
            }
            return View();
        }
    }
}