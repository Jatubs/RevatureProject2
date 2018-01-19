﻿using MinionChat.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MinionChat.Client.Service
{
    public class Usercontrol
    {
        public static async Task<bool> AddUsers(UserInfo user)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://localhost/service/api/AddUser", httpContent);
            var result = await responds.Content.ReadAsStringAsync();
            if (result == "false")
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}