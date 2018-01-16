using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minion.Client.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Friend { get; set; }
        public string Group { get; set; }
        public string Message { get; set; }
        public List<string> Friends = new List<string>() { "Greg", "Cindy", "Bobby", "Jan", "Marsha", "Peter" };
        public List<string> Groups = new List<string>() { "This", "That", "The Other" };
        public string Minion { get; set; }
        public List<string> Minions = new List<string>() { "Me", "You", "We", "Us" };
    }
}