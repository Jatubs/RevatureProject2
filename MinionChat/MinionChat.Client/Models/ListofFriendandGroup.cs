using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinionChat.Client.Models
{
    public class ListofFriendandGroup
    {
        public List<string> Friend { get; set; }
        public List<string> Group { get; set; }
        public bool IsTheUserValid { get; set; }
        public string cookieval { get; set; }
        public string cookieIDval { get; set; }
    }
}