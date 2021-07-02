using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace VacationForm.EventReceiver
{

    public class AddEventReceiver : SPItemEventReceiver
    {

        public override void ItemAdded(SPItemEventProperties properties)
        {
            try
            {
                //MailMessage mail = new MailMessage();
                //mail.From = new MailAddress("YourEmailID@gmail.com");
                //mail.Bcc.Add("bccEmail@gmail.com");
                //mail.CC.Add("sampleEmail@ymail.com");
                //mail.To.Add("nick.ermolenkov@gmail.com");
                //mail.Subject = "Test Mail";
                //mail.Body = "Hi...!!! This is a test mail.";
                //mail.IsBodyHtml = true;
                //SmtpClient smtpClient = new SmtpClient();
                //smtpClient.Host = properties.Web.Site.WebApplication.OutboundMailServiceInstance.Server.Address; 
                //smtpClient.Port = 25;
                //smtpClient.UseDefaultCredentials = false;
                ////smtpClient.Credentials = new System.Net.NetworkCredential("YourEmailID@gmail.com", "YourPassword");
                //smtpClient.EnableSsl = true;
                //ServicePointManager.ServerCertificateValidationCallback = delegate
                //{
                //    return true;
                //};
                //smtpClient.Send(mail);
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = properties.Web.Site.WebApplication.OutboundMailServiceInstance.Server.Address;
                MailMessage mailMessage = new MailMessage("sharavik1992@gmail.com", "nick.ermolenkov@gmail.com");
                mailMessage.Subject = "Test Mail";

                mailMessage.Body = "Hi...!!! This is a test mail.";
                mailMessage.IsBodyHtml = true;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        //public override void ItemAdded(SPItemEventProperties properties)
        //{
        //    base.ItemAdded(properties);
        //    string Siteurl = properties.ListItem.Web.Url;
        //    using (SPSite site = new SPSite(Siteurl))
        //    {
        //        using (SPWeb web = site.OpenWeb())
        //        {
        //            web.AllowUnsafeUpdates = true;
        //            SPListItem currentItem = properties.ListItem;
        //            currentItem["User_x0020_email"] = "email";
        //            var success = SPUtility.SendEmail(web, true, true, "nick.ermolenkov@gmail.com", "Subject Line", "HTML Body Text");
        //        }
        //    }


        //}
        //    public override void ItemAdded(SPItemEventProperties properties)
        //    {
        //        string url = properties.WebUrl;

        //        SPSecurity.RunWithElevatedPrivileges(delegate ()
        //        {
        //            using (SPSite site = new SPSite(url))
        //            {
        //                using (SPWeb web = site.OpenWeb())
        //                {
        //                    var success = SPUtility.SendEmail(web, true, true, "nick.ermolenkov@gmail.com", "Subject Line", "HTML Body Text");
        //                    Console.WriteLine(success);
        //                }
        //            }
        //        });
        //    }
        //}

        public class UpdateEventReceiver : SPItemEventReceiver
        {
            public override void ItemUpdated(SPItemEventProperties properties)
            {
                base.ItemUpdated(properties);
                //if (properties.ListItem["State"].ToString() == "Approved")
                //{
                //    string toField = "nick.ermolenkov@gmail.com";
                //    var success = SPUtility.SendEmail(properties.Web, true, true, toField, "Subject Line", "HTML Body Text");
                //}
            }
        }
    }
}