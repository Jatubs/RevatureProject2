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
        private List<User> Members = new List<User>();
        private List<Message> MessageLog = new List<Message>();

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

    }
}
