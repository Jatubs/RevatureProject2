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
    [Route("api/AddFriend")]
    public class AddFriendController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async Task<List<UserInfo>> AddFriend(UsernameandFriendname friendtoadd)
        {
            var uc = new Usercontrol();
            List<string> listoffriend = new List<string>();
            List<UserInfo> ListofUserInfo = await uc.AddFriend(friendtoadd.Username, friendtoadd.Friendname);
            //foreach (var userinfo in ListofUserInfo)
            //{
            //    listoffriend.Add(userinfo.Username);
            //}
            return ListofUserInfo;
          //  return await x.AddUser(user);
        }
        //[HttpGet]
        //public async Task<List<string>> getFriend(UsernameandFriendname friendtoadd)
        //{
        //    var uc = new Usercontrol();
        //    List<string> listoffriend = new List<string>();
        //    List<UserInfo> ListofUserInfo = await uc.getFriend(friendtoadd.Username);
        //    foreach (var userinfo in ListofUserInfo)
        //    {
        //        listoffriend.Add(userinfo.Username);
        //    }
        //    return listoffriend;
        //    //  return await x.AddUser(user);
        //}

    }
}
