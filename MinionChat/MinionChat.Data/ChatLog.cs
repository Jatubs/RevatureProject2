using System;
using System.Collections.Generic;

namespace MinionChat.Data
{
    public partial class ChatLog
    {
        public long ChatLogId { get; set; }
        public int ChatGroupId { get; set; }
        public int UserIdofSender { get; set; }
        public string Message { get; set; }
        public DateTime TimeofMessage { get; set; }

        public ChatGroups ChatGroup { get; set; }
        public Users UserIdofSenderNavigation { get; set; }
    }
}
