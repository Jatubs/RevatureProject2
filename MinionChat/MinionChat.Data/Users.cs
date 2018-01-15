using System;
using System.Collections.Generic;

namespace MinionChat.Data
{
    public partial class Users
    {
        public Users()
        {
            ChatLog = new HashSet<ChatLog>();
            FriendListFriend = new HashSet<FriendList>();
            FriendListUser = new HashSet<FriendList>();
            GroupMembers = new HashSet<GroupMembers>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public ICollection<ChatLog> ChatLog { get; set; }
        public ICollection<FriendList> FriendListFriend { get; set; }
        public ICollection<FriendList> FriendListUser { get; set; }
        public ICollection<GroupMembers> GroupMembers { get; set; }
    }
}
