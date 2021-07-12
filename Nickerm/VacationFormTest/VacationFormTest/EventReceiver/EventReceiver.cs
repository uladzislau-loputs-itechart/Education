using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace VacationFormTest.EventReceiver
{

    public class AddEventReceiver : SPItemEventReceiver
    {
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);
            string Siteurl = properties.ListItem.Web.Url;
            using (SPSite site = new SPSite(Siteurl))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    web.AllowUnsafeUpdates = true;
                    SPListItem currentItem = properties.ListItem;
                    currentItem["User_x0020_email"] = "email";
                    var success = SPUtility.SendEmail(web, true, true, "nick.ermolenkov@gmail.com", "Subject Line", "HTML Body Text");
                }
            }


        }


    }


}