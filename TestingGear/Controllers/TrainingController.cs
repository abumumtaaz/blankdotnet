using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TestingGear.Controllers
{
    public class TrainingController : Controller
    {
        //
        // GET: /Training/

        [HttpGet]
        public ActionResult Lau2015()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Lau2015(string name, string mail, string phone, string address,
            string courses)
        {
            try
            {
                var from = ConfigurationManager.AppSettings.Get("UserID");
                using (var email = new MailMessage(from, "yusuf.oguntola@gmail.com"))
                {
                    email.Subject = "Training Reg";
                    const string extra = "An application for the training has been submitted from Highcontech.com. \nRegistration Details: \n\n";
                    email.Body =
                        string.Format(
                            "{0}Full Name: {1}\nPhone: {2}\nEmail: {3}\nAddress: {4}\nCourses: {5}",
                            extra, name, phone, mail, address, courses);
                    email.IsBodyHtml = false;
                    var smtp = new SmtpClient();
                    smtp.SendMailAsync(email);
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

        

    }
}
