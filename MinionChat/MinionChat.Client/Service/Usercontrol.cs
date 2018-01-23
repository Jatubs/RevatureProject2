using MinionChat.Client.Models;
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
        public static async Task<bool> AddUsers(UserInfo user) //http://minionchatserver.azurewebsites.net/
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/AddUser", httpContent);
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

        public static async Task<ListofFriendandGroup> Login(UserInfo user)
        {
            var client = new HttpClient();
            
            var content = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/Login", httpContent);
            string test = responds.Headers.ElementAt(2).Value.ElementAt(0).ToString();
            string testname = test.Split('=')[0];
            string testid = test.Split('=')[1];
            testid = testid.Split(';')[0];
            var result = await responds.Content.ReadAsStringAsync();
            var returnval = JsonConvert.DeserializeObject<ListofFriendandGroup>(responds.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            returnval.cookieval = testname;
            returnval.cookieIDval = testid;
           return returnval;
        }

        public static async Task<List<UserInfo>> Addfriend(FriendModel param)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/AddFriend", httpContent);
            
            var result = await responds.Content.ReadAsStringAsync();
         //   List<string> returnval = new List<string>();

            return JsonConvert.DeserializeObject<List<UserInfo>>(responds.Content.ReadAsStringAsync().GetAwaiter().GetResult());

            
        }
        public static async Task<List<string>> RemoveFriend(FriendModel param)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/RemoveFriend", httpContent);
            var result = await responds.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<string>>(responds.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }
        public static async Task<List<string>> AddGroup(NameModel param)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/addGroup", httpContent);
            var result = await responds.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<string>>(responds.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }
        public static async Task<List<string>> RemoveGroup(NameModel param)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/RemoveGroup", httpContent);
            var result = await responds.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<string>>(responds.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }
        public static async Task<List<MessageInfo>> GetGroupChat(NameModel param)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/getGroupChat", httpContent);
            var result = await responds.Content.ReadAsStringAsync();
            List<MessageInfo> returnval = new List<MessageInfo>();
            returnval = JsonConvert.DeserializeObject<List<MessageInfo>>(result);
            return returnval;
        }
        public static async Task<bool> AddChatToGroup(MessageInfo param)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/AddChatToGroup", httpContent);
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

        public static async Task<bool> AddChatToFriend(MessageInfo param)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/AddChatToFriend", httpContent);
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
        public static async Task<List<MessageInfo>> GetFriendChat(FriendModel param)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responds = await client.PostAsync("http://minionchatserver.azurewebsites.net/api/getFriendChat", httpContent);
            var result = await responds.Content.ReadAsStringAsync();
            List<MessageInfo> returnval = new List<MessageInfo>();
            returnval = JsonConvert.DeserializeObject<List<MessageInfo>>(result);
            return returnval;
        }
    }
}