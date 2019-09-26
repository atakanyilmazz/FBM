using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBM.WebUI.Helper
{
    public class Message
    {
        public MessageType Type { get; set; }
        public string Text { get; set; }
        public int? Duration { get; set; }
        public bool Closeable { get; set; }
        public static string MESSAGE_NAME { get { return "MESAJ"; } }
    }
}