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
    [Route("api/AddChatToGroup")]
    public class AddChatToGroupController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async void AddChatGroup(MessageInfo message)
        {
            var x = new Usercontrol();
            x.addChatToGroup(message.NameofSender,message.NameofGroup,message.Message);
            
        }

    }
}
