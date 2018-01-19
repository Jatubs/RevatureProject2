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
    [Route("api/RemoveFriend")]
    public class RemoveFriendController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async Task<List<string>> RemoveFriend(UsernameandFriendname friendtoremove)
        {
            var uc = new Usercontrol();
            List<string> listoffriend = new List<string>();
            List<UserInfo> ListofUserInfo = await uc.AddFriend(friendtoremove.Username, friendtoremove.Friendname);
            foreach (var userinfo in ListofUserInfo)
            {
                listoffriend.Add(userinfo.Username);
            }
            return listoffriend;
        }

    }
}
