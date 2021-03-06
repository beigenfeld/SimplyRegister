﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEmail.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SimplyRegister.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Let your customers register. Simply.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us:";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("beigenfeld@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("umabob2017@gmail.com");  // replace with valid value
                message.Subject = "Please Send Invoice";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "umabob2017@gmail.com",  // replace with valid value
                        Password = "UmaBob123!"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }


    }
}





