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
    [Route("api/getGroupChat")]
    public class getGroupChatController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async Task<List<MessageInfo>> GetGroupChat(GroupInfo GroupName)
        {
            var x = new Usercontrol();
            List<MessageInfo> ListofChat = await x.GroupChat(GroupName.Name);
            return ListofChat;
        }

    }
}
