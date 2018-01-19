using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionChat.Library
{
    public class Group
    {
        private string Name;
        private string Username;
        public List<User> Members = new List<User>();
        public List<Group> Groups { get; set; }
        public List<Message> MessageLog = new List<Message>();

        public string GetName()
        {
            return Name;
        }
        public void SetName(string newname)
        {
            Name = newname;
        }
        public List<User> GetMembers()
        {
            return Members;
        }
        public void AddMember(User member)
        {
            if (!Members.Contains(member))
            {
                Members.Add(member);
            }
            if (!member.GetGroups().Contains(this))
            {
                member.AddGroup(this);
            }
        }
        public void AddMemberStr(string grouptoadd)
        {
            bool found = false;
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].GetName() == grouptoadd)
                {
                    //This means it contains it, do nothing
                    found = true;
                }
            }
            if (!found)
            {
                User testmember = new User();
                testmember.SetName(grouptoadd);
                Members.Add(testmember);
            }
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].GetName() == grouptoadd)
                {
                    if (!Members[i].GetGroups().Contains(this))
                    {
                        Members[i].GetGroups().Add(this);
                    }
                }
            }
        }
        public void RemoveMember(User member)
        {
            if (Members.Contains(member))
            {
                Members.Remove(member);
            }
            if (member.GetGroups().Contains(this))
            {
                member.RemoveGroup(this);
            }
        }
        public void RemoveMemberStr(string grouptoremove)
        {
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].GetName() == grouptoremove)
                {
                    if (Members[i].GetGroups().Contains(this))
                    {
                        Members[i].GetGroups().RemoveAt(i);
                    }
                    Members.RemoveAt(i);
                }
            }
        }
        public List<Message> GetMessageLog()
        {
            return MessageLog;
        }
        public void AddMessage(Message Message)
        {
            MessageLog.Add(Message);
        }
        public void RemoveMessage(Message Message)
        {
            MessageLog.Remove(Message);
        }
        public void AddMessageStr(string Message)
        {
            Message testmess = new Message();
            testmess.SetMessageContents(Message);
            MessageLog.Add(testmess);
        }
        public void RemoveMessageStr(string Message)
        {
            Message testmess = new Message();
            testmess.SetMessageContents(Message);

            MessageLog.Remove(testmess);
        }

        public void SetUsername(string UserName)
        {
            Username = UserName;
        }

        public string GetUsername()
        {
            return Username;
        }

    }
}