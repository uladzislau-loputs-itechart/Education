using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace VacationFormTest.EventReceiver1
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class UpdateEventReceiver : SPItemEventReceiver
    {
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);
            if (properties.ListItem["State"].ToString() == "Approved")
            {
                string toField = "nick.ermolenkov@gmail.com";
                var success = SPUtility.SendEmail(properties.Web, true, true, toField, "Subject Line", "HTML Body Text");
            }
        }
    }
}