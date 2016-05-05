using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Mail;
//using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Text;
using System.IO;
using Api.Models;

using SendGrid;

namespace Api.Services
{
    public static class EmailService
    {
        public static void SendRegistrationConfirmMail(string toEmail, string encodeUserID, string plainUserName)
        {
            try
            {
                var domain = HttpContext.Current.Request.Url.Authority;
                StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/EmailTemplate/ConfirmRegistration.html"));
                string readFile = reader.ReadToEnd();
                string myString = "";
                myString = readFile;
                myString = myString.Replace("{USERNAME}", plainUserName);
                myString = myString.Replace("{VERIFICATION_LINK}", "http://" + domain + "/api/account/ActivateUser?q=" + encodeUserID);


                var myMessage = new SendGrid.SendGridMessage();
                myMessage.AddTo(toEmail);
                myMessage.From = new MailAddress("jobsinaba@gmail.com", "JobsInABA");
                myMessage.Subject = "Email Verification";
                myMessage.Html = myString.ToString();

                var transportWeb = new SendGrid.Web("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");
                transportWeb.DeliverAsync(myMessage);

                //// MailMessage class is present is System.Net.Mail namespace 
                //MailMessage mailMessage = new MailMessage();
                //var _fromMailAddress = ConfigurationManager.AppSettings["FromMailAddress"].ToString();
                //var _fromMailPassword = ConfigurationManager.AppSettings["FromMailPassword"].ToString();
                //var _fromMailSMTP = ConfigurationManager.AppSettings["FromMailSMTP"].ToString();
                //int _formMailPort = Convert.ToInt32(ConfigurationManager.AppSettings["FromMailPort"]);

                //MailAddress fromMail = new MailAddress(_fromMailAddress);
                //mailMessage.From = fromMail;
                //mailMessage.To.Add(toEmail);
                //mailMessage.IsBodyHtml = true;
                //mailMessage.Body = myString.ToString();
                //mailMessage.Subject = "Email Verification";

                //SmtpClient smtpClient = new SmtpClient(_fromMailSMTP, _formMailPort);
                //smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["IsEnableSSl"].ToString());
                //smtpClient.Credentials = new System.Net.NetworkCredential()
                //{
                //    UserName = _fromMailAddress,
                //    Password = _fromMailPassword
                //};

                //smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void SendPasswordResetEmail(string toEmail, string encodeUserID, string plainUserName)
        {
            try
            {
                var domain = HttpContext.Current.Request.Url.Authority;
                StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/EmailTemplate/PasswordReset.html"));
                string readFile = reader.ReadToEnd();
                var redirectUrl = ConfigurationManager.AppSettings["CurruntURL"].ToString() + "/#/resetPassword/" + encodeUserID;
                string myString = "";
                myString = readFile;
                myString = myString.Replace("{USERNAME}", plainUserName);
                myString = myString.Replace("{VERIFICATION_LINK}", redirectUrl);

                var myMessage = new SendGrid.SendGridMessage();
                myMessage.AddTo(toEmail);
                myMessage.From = new MailAddress("jobsinaba@gmail.com", "JobsInABA");
                myMessage.Subject = "Forgot Password";
                myMessage.Html = myString.ToString();
                
                var transportWeb = new SendGrid.Web("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");
                transportWeb.DeliverAsync(myMessage);

                //// MailMessage class is present is System.Net.Mail namespace 
                //MailMessage mailMessage = new MailMessage();
                //var _fromMailAddress = ConfigurationManager.AppSettings["FromMailAddress"].ToString();
                //var _fromMailPassword = ConfigurationManager.AppSettings["FromMailPassword"].ToString();
                //var _fromMailSMTP = ConfigurationManager.AppSettings["FromMailSMTP"].ToString();
                //int _formMailPort = Convert.ToInt32(ConfigurationManager.AppSettings["FromMailPort"]);

                //MailAddress fromMail = new MailAddress(_fromMailAddress);
                //mailMessage.From = fromMail;
                //mailMessage.To.Add(toEmail);
                //mailMessage.IsBodyHtml = true;
                //mailMessage.Body = myString.ToString();
                //mailMessage.Subject = "Forgot Password";

                //SmtpClient smtpClient = new SmtpClient(_fromMailSMTP, _formMailPort);
                //smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["IsEnableSSl"].ToString());
                //smtpClient.Credentials = new System.Net.NetworkCredential()
                //{
                //    UserName = _fromMailAddress,
                //    Password = _fromMailPassword
                //};

                //smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}