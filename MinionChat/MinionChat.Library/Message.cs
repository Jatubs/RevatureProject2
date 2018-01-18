using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionChat.Library
{
    public class Message
    {
        private string messagecontents;
        private string timeofmessage;
        private User messagesender;

        public string GetMessageContents()
        {
            return messagecontents;
        }
        public void SetMessageContents(string message)
        {
            messagecontents = message;
        }
        public string GetTimeOfMessage()
        {
            return timeofmessage;
        }
        //Automatically sets message time as the current time.
        public void SetTimeOfMessage()
        {
            timeofmessage = DateTime.Today.TimeOfDay.ToString();
        }
        public User GetMessageSender()
        {
            return messagesender;
        }
        public void SetMessageSender(User sender)
        {
            messagesender = sender;
        }
    }
}