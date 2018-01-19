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
            foreach (var u in db.Users.ToList())
            {
                if (u.Username == user.Username)
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

        public async Task<List<UserInfo>> AddFriend(string Username, string FriendUsername)
        {
            bool alreadyhasthatfriend = false;
            int UserId = 0;
            int FriendId = 0;
            List<UserInfo> FriendList = new List<UserInfo>();
            foreach (var i in db.Users.ToList())
            {
                if (i.Username == Username)
                {
                    UserId = i.UserId;
                    foreach (var j in i.FriendListUser)
                    {
                        UserInfo friend = new UserInfo();
                        friend.UserId = j.UserId;
                        FriendList.Add(friend);
                    }
                }
                if (i.Username == FriendUsername)
                {
                    FriendId = i.UserId;
                }
            }
            foreach (var i in db.Users.ToList())
            {
                if (i.Username == Username)
                {
                    foreach (var j in i.FriendListUser)
                    {
                        if (FriendId == j.FriendId)
                        {
                            alreadyhasthatfriend = true;
                        }
                    }
                }
            }
                foreach (var i in db.Users.ToList())
            {
                if (i.Username == Username)
                {
                    if (!alreadyhasthatfriend)
                    {
                        FriendList newfl = new FriendList();
                        FriendList newfl2 = new FriendList();

                        newfl.UserId = UserId;
                        newfl.FriendId = FriendId;
                        newfl2.UserId = FriendId;
                        newfl2.FriendId = UserId;
                        i.FriendListUser.Add(newfl);
                        i.FriendListFriend.Add(newfl2);

                        await db.SaveChangesAsync();
                    }
                }
            }
            foreach (var i in db.Users.ToList())
            {
                for (int j = 0; j < FriendList.Count; j++)
                {
                    if (FriendList[j].UserId == i.UserId)
                    {
                        FriendList[j].Username = i.Username;
                        FriendList[j].Name = i.Name;
                        FriendList[j].Password = i.Password;
                    }
                }
            }
            return FriendList;
        }

        public async Task<List<string>> AddGroup(string NameofGroup)
        {
            List<string> ListofGroup = new List<string>();
            bool alreadyexsits = false;
            foreach (var group in db.ChatGroups)
            {
                if(group.Name == NameofGroup)
                {
                    alreadyexsits = true;
                }
                ListofGroup.Add(NameofGroup);
            }
            if(alreadyexsits == false)
            {
                ListofGroup.Add(NameofGroup);

                ChatGroups newChatgroup = new ChatGroups() { FriendChat = false, Name = NameofGroup };
                await db.ChatGroups.AddAsync((newChatgroup));
                await db.SaveChangesAsync();
            }
            


            return ListofGroup;
        }
    }
}