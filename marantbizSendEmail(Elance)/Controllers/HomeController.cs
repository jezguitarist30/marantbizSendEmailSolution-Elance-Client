using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using marantbizSendEmail_Elance_.Models;


namespace marantbizSendEmail_Elance_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
 

        [HttpPost]
        public ActionResult Info(UserModel model)
        {

            return View(model);
        }


        [HttpPost]
        public ActionResult SendEmail(UserModel model)
        {
            StringBuilder sb = new StringBuilder();


            try
            {
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential basicCredential = new NetworkCredential("jmaghuyop@creativemindstechnology.com", "hgcJ15qC1p8Ys85");
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress("kunrii@marantbiz.com", "info@marantbiz.com");

                // setup up the host, increase the timeout to 5 minutes
                smtpClient.Host = "mail.creativemindstechnology.com";
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                smtpClient.Timeout = (60 * 5 * 1000);
                //smtpClient.Port = 465;

                message.From = fromAddress;
                message.Subject = "Inquire Mail";
                message.IsBodyHtml = true;

                sb.Append("<b>First Name:  </b>");
                sb.Append(model.FirstName);
                sb.Append("<br/>");
                sb.Append("<b>Last Name:  </b>");
                sb.Append(model.LastName);
                sb.Append("<br/>");
                sb.Append("<b>Email:  </b>");
                sb.Append(model.Email);
                sb.Append("<br/>");
                sb.Append("<b>Date Of Birth:  </b>");
                sb.Append(model.DateOfBirth);
                sb.Append("<br/>");
                sb.Append("<b>Country:  </b>");
                sb.Append(model.Country);
                sb.Append("<br/>");
                sb.Append("<b>State:  </b>");
                sb.Append(model.State);
                sb.Append("<br/>");
                sb.Append("<b>City:  </b>");
                sb.Append(model.City);
               
               
                sb.Append("<br/>");

                message.Body = sb.ToString();
                message.To.Add("kunrii@marantbiz.com");
                message.To.Add("jmaghuyop@creativemindstechnology.com");

                //Send Email
                smtpClient.Send(message);

                TempData["FirstName"] = model.FirstName;
            }
            catch (Exception ex)
            {                
               Console.WriteLine(ex.Message);
            }


            return RedirectPermanent("ThankYou");
        }


        public ActionResult ThankYou()
        {

            return View();
        }
    }
}