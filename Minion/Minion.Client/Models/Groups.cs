using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minion.Client.Models
{
    public class Groups
    {
        public string GroupName { get; set; }
        public List<string> Group = new List<string>() { "This", "That", "The Other" };
    }
}