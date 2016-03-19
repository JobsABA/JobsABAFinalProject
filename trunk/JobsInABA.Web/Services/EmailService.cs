using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Text;

namespace JobsInABA.Web.Services
{
    public static class EmailService
    {
        public static void SendPasswordResetEmail(string toEmail, string link)
        {
            DataTable table = new DataTable();

            // MailMessage class is present is System.Net.Mail namespace 
            MailMessage mailMessage = new MailMessage();
            MailAddress fromMail = new MailAddress("info@jobsinaba.com");
            mailMessage.From = fromMail;
            mailMessage.To.Add(toEmail);
            // StringBuilder class is present in System.Text namespace 
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Hi,<br/><br/>");
            sbEmailBody.Append("Thanks for registering in JobsInABA.com!<br/><br/>");
            sbEmailBody.Append("Kindly verify your email by clicking on below link:<br/>");
            sbEmailBody.Append("'<a href='/Main/ActivateAccount/UserName='");
            sbEmailBody.Append(link);
            sbEmailBody.Append("'>click Me</a>");
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<i>Thanks,</i><br/>");
            sbEmailBody.Append("<b>JobsInABA</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Email Verification";
            SmtpClient smtpClient = new SmtpClient("smtp.emailsrvr.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "gauravkumar.rajendrabhai@nuware.com",//input your username 
                Password = "ladani#171191"
            };
            smtpClient.Send(mailMessage);
        }
    }
}