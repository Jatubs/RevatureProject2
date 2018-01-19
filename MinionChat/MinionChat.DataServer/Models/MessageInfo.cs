using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinionChat.DataServer.Models
{
    public class MessageInfo
    {

        public string NameofSender { get; set; }
        public string Message { get; set; }
        public DateTime TimeofMessage { get; set; }
        public string NameofGroup { get; set; }
    }
}