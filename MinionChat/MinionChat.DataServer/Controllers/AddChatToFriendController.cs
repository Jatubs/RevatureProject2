﻿using MinionChat.DataServer.DatabaseConnections;
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
    [Route("api/AddChatToFriend")]
    public class AddChatToFriendController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async Task<bool> AddChatFriend(MessageInfo message) /// makesure friend name gets through
        {
            var x = new Usercontrol();
            bool waiting = await x.addChatToFriend(message.NameofSender,message.NameofGroup,message.Message);
            return waiting;
        }

    }
}
