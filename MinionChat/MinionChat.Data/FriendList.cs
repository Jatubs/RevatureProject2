using System;
using System.Collections.Generic;

namespace MinionChat.Data
{
    public partial class FriendList
    {
        public int FriendListId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public Users Friend { get; set; }
        public Users User { get; set; }
    }
}
