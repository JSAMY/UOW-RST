using Restaurant.Core.CommonModel;
using Restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Common
{
    public class EmailService : IEmail
    {
        public void Send(EmailDetails details)
        {
            try
            {
                var fromAddress = new MailAddress(details.emailFromAddress, details.emailFromName);
                var toAddress = new MailAddress(details.emailToAddress, details.emailToName);
                const string fromPassword = "fromPassword"; // read it from config

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = details.Subject,
                    Body = details.Body
                })
                {
                    smtp.Send(message);
                }

            }
            catch(Exception ex)
            {

            }
        }



        //public  void Send(EmailDetails details)
        //{
        //    System.Net.Mail.MailMessage oMailMsg = new System.Net.Mail.MailMessage();
        //    oMailMsg.To.Add(details.emailToAddress)   ;
        //    oMailMsg.Subject = details.Subject;

        //    oMailMsg.IsBodyHtml = true;
        //    oMailMsg.Body = "details shold go here.....";

        //    System.Net.Mail.SmtpClient oSMTPClient = new System.Net.Mail.SmtpClient();
        //    oSMTPClient.Send(oMailMsg);
        //}

        
    }
}
