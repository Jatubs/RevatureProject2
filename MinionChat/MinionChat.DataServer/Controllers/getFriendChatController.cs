using MinionChat.DataServer.DatabaseConnections;
using MinionChat.DataServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace MinionChat.DataServer.Controllers
{

    //[Produces("application/json")]
    [Route("api/getFriendChat")]
    public class getFriendChatController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async Task<List<MessageInfo>> GetFriendChat(UsernameandFriendname friendtochat)
        {
            var x = new Usercontrol();
            List<MessageInfo> ListofChat = await x.FriendChat(friendtochat.Username ,friendtochat.Friendname);
            return ListofChat;
        }

    }
}
