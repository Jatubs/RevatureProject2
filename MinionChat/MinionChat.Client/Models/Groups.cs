using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinionChat.Client.Models
{
    public class Groups
    {
        public string UserName { get; set; }
        public string Minion { get; set; }
        public List<string> Minions = new List<string>();
        public string Group { get; set; }
        public string NewGroup { get; set; }
        public List<string> MyGroups = new List<string>();
        public string Message { get; set; }
        public List<string> Messages = new List<string>();
    }
}