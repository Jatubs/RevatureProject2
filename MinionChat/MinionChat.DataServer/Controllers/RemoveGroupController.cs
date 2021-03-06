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
    [Route("api/RemoveGroup")]
    public class RemoveGroupController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async Task<List<string>> RemoveGroup(GroupInfo GroupName)
        {
            var x = new Usercontrol();
            List<string> ListofGroup = await x.RemoveGroup(GroupName.Name);
            return ListofGroup;
        }

    }
}
