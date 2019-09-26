using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity;
using FBM.WebUI.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace FBM.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public void CheckMobile() {
            if (Request.Browser.IsMobileDevice)
            {
                Response.Redirect("~/default_mobile.aspx");
            }
        }
        public void ShowMessage(MessageType type, string msg, int? duration = 3, bool closeable = true)
        {
            Message message = new Message();

            message.Type = type;
            message.Text = msg;
            message.Duration = duration;
            message.Closeable = closeable;

            List<Message> messages = null;

            if (TempData[Message.MESSAGE_NAME] != null)
            {
                messages = (List<Message>)TempData[Message.MESSAGE_NAME];
            }
            else
            {
                messages = new List<Message>();
            }
            messages.Add(message);

            TempData[Message.MESSAGE_NAME] = messages;
        }
    }
}