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
    [Route("api/AddFriend")]
    public class AddFriendController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async Task<List<Object>> AddFriend(UserInfo user)
        {
            var x = new Usercontrol();
            return null;
          //  return await x.AddUser(user);
        }

    }
}
