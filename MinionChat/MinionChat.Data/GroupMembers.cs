using System;
using System.Collections.Generic;

namespace MinionChat.Data
{
    public partial class GroupMembers
    {
        public int GroupMemberId { get; set; }
        public int UserId { get; set; }
        public int ChatGroupId { get; set; }

        public ChatGroups ChatGroup { get; set; }
        public Users User { get; set; }
    }
}
