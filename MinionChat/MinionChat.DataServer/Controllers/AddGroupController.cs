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
    [Route("api/addGroup")]
    public class AddGroupController : ApiController
    {

        // POST api/values
        [HttpPost]
        public async Task<List<string>> AddGroup(GroupInfo GroupName)
        {
            var x = new Usercontrol();
            List<string> ListofGroup = await x.AddGroup(GroupName.Name);
            return ListofGroup;
        }

        [HttpGet]
        public async Task<List<string>> getGroup()
        {
            var x = new Usercontrol();
            List<string> ListofGroup = await x.getGroup();
            return ListofGroup;
        }

    }



}
