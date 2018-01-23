using MinionChat.DataServer.DatabaseConnections;
using MinionChat.DataServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace MinionChat.DataServer.Controllers
{

    //[Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async Task<ListofFriendandGroup> Login(UserInfo user)
        {
            var x = new Usercontrol();

            List<string> ListofGroup = new List<string>();
            List<string> listoffriend = new List<string>();

            bool login = await x.Login(user);
            if (login)
            {
                ListofGroup = await x.getGroup();
                List<UserInfo> ListofUserInfo = await x.getFriend(user.Username);
                foreach (var userinfo in ListofUserInfo)
                {
                    listoffriend.Add(userinfo.Username);
                }

            }

            int id = x.findUsersID(user.Username);
            ListofFriendandGroup result = new ListofFriendandGroup() { Friend = listoffriend, Group = ListofGroup };
            result.IsTheUserValid = login;

            HttpCookie cookie = new HttpCookie(user.Username.ToString(), ""+id);
            cookie.Expires = DateTime.Now.AddHours(1);

            HttpContext.Current.Response.AppendCookie(cookie);


            return result;


        }

    }
}
