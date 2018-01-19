using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinionChat.DataServer.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public UserInfo() { }
    }
}