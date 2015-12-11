using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace TestingGear.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }


        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name, string uEmail, string subject, string message)
        {
            try
            {
                var from = ConfigurationManager.AppSettings.Get("UserID");
                var password = ConfigurationManager.AppSettings.Get("Password");
                using (var email = new MailMessage(from, "yusuf.oguntola@gmail.com"))
                {
                    email.Subject = "Contact - " + subject;
                    email.Body = name + " sent a message from within the ganaf website. \nMessage Content: \n" + message + "\n\nEmail Address: " + uEmail;
                    email.IsBodyHtml = false;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        EnableSsl = true
                    };
                    var networkCredential = new NetworkCredential(from, password);
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(email);
                    ViewBag.Status = "SUCCESS";
                    ViewBag.StatusMessage = "Message successfully sent";

                }
            }
            catch (Exception)
            {
                ViewBag.Status = "ERROR";
                ViewBag.StatusMessage = "Something went wrong. Please retry.";
            }
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Training2015()
        {
            return View();
        }

        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}
