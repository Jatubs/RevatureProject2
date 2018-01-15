using System;
using System.Collections.Generic;

namespace MinionChat.Data
{
    public partial class ChatGroups
    {
        public ChatGroups()
        {
            ChatLog = new HashSet<ChatLog>();
            GroupMembers = new HashSet<GroupMembers>();
        }

        public int ChatGroupId { get; set; }
        public string Name { get; set; }

        public ICollection<ChatLog> ChatLog { get; set; }
        public ICollection<GroupMembers> GroupMembers { get; set; }
    }
}
