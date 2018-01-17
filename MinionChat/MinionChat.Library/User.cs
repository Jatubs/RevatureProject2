using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionChat.Library
{
    public class User
    {
        private string Username;
        private string password;
        private string Name;
        private string Email;
        //Offline, Online, Away, Etc...
        private string Status;
        private bool active;
        private List<User> Friends = new List<User>();
        private List<Group> Groups = new List<Group>();
        #region Getters and Setters
        public string GetUsername()
        {
            return Username;
        }
        public void SetUsername(string newname)
        {
            Username = newname;
        }
        public bool GetActive()
        {
            return active;
        }
        public void SetActive(bool actval)
        {
            active = actval;
        }
        public string Getpassword()
        {
            return password;
        }
        public void SetPassword(string pass)
        {
            password = pass;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string newname)
        {
            Name = newname;
        }
        public string GetEmail()
        {
            return Email;
        }
        public void SetEmail(string newemail)
        {
            Email = newemail;
        }
        public string GetStatus()
        {
            return Status;
        }
        public void SetStatusAway()
        {
            Status = "Away";
        }
        public void SetStatusOffline()
        {
            Status = "Offline";
        }
        public void SetStatusOnline()
        {
            Status = "Online";
        }
        public List<User> GetFriends()
        {
            return Friends;
        }
        public void AddToFriends(User friendtoadd)
        {
            Friends.Add(friendtoadd);
        }
        public void RemoveFriend(User friendtoremove)
        {
            Friends.Remove(friendtoremove);
        }
        public List<Group> GetGroups()
        {
            return Groups;
        }
        public void AddGroup(Group grouptoadd)
        {
            if (!Groups.Contains(grouptoadd))
            {
                Groups.Add(grouptoadd);
            }
            if (!grouptoadd.GetMembers().Contains(this))
            {
                grouptoadd.AddMember(this);
            }
        }
        public void RemoveGroup(Group grouptoremove)
        {
            if (Groups.Contains(grouptoremove))
            {
                Groups.Remove(grouptoremove);
            }
            if (grouptoremove.GetMembers().Contains(this))
            {
                grouptoremove.RemoveMember(this);
            }
        }
        #endregion
        public bool Login()
        {
            //Do Logon things here
            return false;
        }
        //User Must Be a member of the group they're trying to message
        public bool SendMessage(Group grouptomessage, Message message)
        {
            try
            {
                if (Groups.Contains(grouptomessage))
                {
                    grouptomessage.AddMessage(message);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
