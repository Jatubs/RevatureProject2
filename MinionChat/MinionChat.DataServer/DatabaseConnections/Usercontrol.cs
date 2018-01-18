using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MinionChat.Data;
using MinionChat.DataServer.Models;

namespace MinionChat.DataServer.DatabaseConnections
{
    public class Usercontrol
    {

        private Project2Context db = new Project2Context();

        public async Task<bool> AddUser(UserInfo user)
        {
             foreach(var u in db.Users.ToList())
            {
                if(u.Username == user.Username)
                {
                    return false;
                }
            }

            Users newUser = new Users() { Name = user.Name, Username = user.Username, Password = user.Password };
            try
            {
                await db.Users.AddAsync(newUser);
                await db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}