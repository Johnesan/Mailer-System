using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Mailer
{
    public class MessageService
    {
        public  static void SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var _email = "jcoool40@gmail.com";

                //Password in Web.config
                //var _password = ConfigurationManager.AppSettings["EmailPassword"];
                var _dispName = "John";
                MailMessage myMessage = new MailMessage();
                myMessage.To.Add(email);
                myMessage.From = new MailAddress(_email, _dispName);
                myMessage.Subject = subject;
                myMessage.Body = message;
                myMessage.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("jcoool40@gmail.com", "donjohn39");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                     smtp.Send (myMessage);
                  
                    

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}