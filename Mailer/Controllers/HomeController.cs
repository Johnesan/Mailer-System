using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Web.Hosting;
using Mailer.Models;
using System.Globalization;

namespace Mailer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SendMail(Receiver receiver)
        {
            var message = await GetEmailTemplate("WelcomeTemplate");
            message = message.Replace("@ViewBag.FirstName", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(receiver.FirstName));
            MessageService.SendEmailAsync(receiver.EmailAddress, "Welcome", message);
            return View("EmailSent");
        }

   
        public async Task<ActionResult> SendToAll()
        {
            MailerContext db = new MailerContext();
            var Receivers = db.Receivers.ToList();
            

            foreach (var receiver in Receivers)
            {
                var message = await GetEmailTemplate("WelcomeTemplate");
                message = message.Replace("@ViewBag.FirstName", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(receiver.FirstName));
                MessageService.SendEmailAsync(receiver.EmailAddress, "Welcome", message);
                return View("EmailSent");
            }
            return new HttpNotFoundResult("Couldn't send Messages");

        }


        [HttpGet]
        public ActionResult EmailSent()
        {
            return View();
        }

        public static async Task<string> GetEmailTemplate(string template)
        {
            var TemplateFilePath = HostingEnvironment.MapPath("~/EmailTemplates/") + template + ".cshtml";
            StreamReader objstreamreaderfile = new StreamReader(TemplateFilePath);
            var body = await objstreamreaderfile.ReadToEndAsync();
            objstreamreaderfile.Close();
            return body;
        }
    }
}