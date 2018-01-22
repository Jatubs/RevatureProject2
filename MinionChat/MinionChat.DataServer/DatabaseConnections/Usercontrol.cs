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

        private static Project2Context db = new Project2Context();

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
        public async Task<List<UserInfo>> RemoveFriend(string Username, string FriendUsername)
        {
            bool alreadyhasthatfriend = false;
            int UserId = 0;
            int FriendId = 0;
            List<UserInfo> FriendList = new List<UserInfo>();
            List<int> FriendIds = new List<int>();
            //Get the ID's for both the User and their Friend
            foreach (var i in db.Users.ToList())
            {
                if (i.Username == Username)
                {
                    UserId = i.UserId;
                }
                if (i.Username == FriendUsername)
                {
                    FriendId = i.UserId;
                }
            }
            //Make sure the User has that friend
            foreach (var i in db.FriendList.ToList())
            {
                if (i.UserId == UserId)
                {
                    if (i.FriendId == FriendId)
                    {
                        alreadyhasthatfriend = true;
                    }
                }
            }
            //Find the user in the list again, and if they have that friend, go ahead and remove them from both lists.
            foreach (var i in db.Users.ToList())
            {
                if (i.Username == Username)
                {
                    if (alreadyhasthatfriend)
                    {
                        foreach (var j in db.FriendList)
                        {
                            if (j.UserId == UserId)
                            {
                                if (j.FriendId == FriendId)
                                {
                                    db.FriendList.Remove(j);
                                }
                            }
                            if (j.UserId == FriendId)
                            {
                                if (j.FriendId == UserId)
                                {
                                    db.FriendList.Remove(j);
                                }
                            }
                        }
                        await db.SaveChangesAsync();
                    }
                }
            }
            foreach (var i in db.FriendList.ToList())
            {
                if (i.UserId == UserId)
                {
                    foreach (var j in db.Users.ToList())
                    {
                        if (i.FriendId == j.UserId)
                        {
                            UserInfo friend = new UserInfo();
                            friend.UserId = FriendId;
                            friend.Username = j.Username;
                            friend.Password = j.Password;
                            friend.Name = j.Name;
                            FriendList.Add(friend);
                        }
                    }
                }
            }
           
            return FriendList;
        }
        public async Task<List<UserInfo>> AddFriend(string Username, string FriendUsername)
        {
            bool alreadyhasthatfriend = false;
            int UserId = 0;
            int FriendId = 0;
            List<UserInfo> FriendList = new List<UserInfo>();
            if (Username == FriendUsername)
            {
                alreadyhasthatfriend = true;
            }
            foreach (var i in db.Users.ToList())
            {
                if (i.Username == Username)
                {
                    UserId = i.UserId;
                }
                if (i.Username == FriendUsername)
                {
                    FriendId = i.UserId;
                }
            }
            foreach (var i in db.FriendList.ToList())
            {
                if (i.UserId == UserId)
                {
                    if (i.FriendId == FriendId)
                    {
                        alreadyhasthatfriend = true;
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
                        db.FriendList.Add(newfl);
                        db.FriendList.Add(newfl2);

                        await db.SaveChangesAsync();
                    }
                }
            }
            foreach (var i in db.FriendList.ToList())
            {
                if (i.UserId == UserId)
                {
                    foreach (var j in db.Users.ToList())
                    {
                        if (i.FriendId == j.UserId)
                        {
                            UserInfo friend = new UserInfo();
                            friend.UserId = FriendId;
                            friend.Username = j.Username;
                            friend.Password = j.Password;
                            friend.Name = j.Name;
                            FriendList.Add(friend);
                        }
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
                if (group.Name == NameofGroup)
                {
                    alreadyexsits = true;
                }
                ListofGroup.Add(group.Name);
            }
            if (alreadyexsits == false)
            {
                ListofGroup.Add(NameofGroup);

                ChatGroups newChatgroup = new ChatGroups() { FriendChat = false, Name = NameofGroup };
                await db.ChatGroups.AddAsync((newChatgroup));
                await db.SaveChangesAsync();
            }



            return ListofGroup;
        }

        public async Task<List<string>> RemoveGroup(string NameofGroup)
        {
            List<string> ListofGroup = new List<string>();

            ChatGroups ChatGrouptoRemove = new ChatGroups();
            
            foreach (var group in db.ChatGroups)// find group to remove
            {
                if (group.Name != NameofGroup)
                {
                    ListofGroup.Add(group.Name);
                }
                else
                {
                    ChatGrouptoRemove = group;
                }
            }

            foreach (var chatlog in db.ChatLog)
            {
                if (chatlog.ChatGroupId == ChatGrouptoRemove.ChatGroupId && ChatGrouptoRemove.Name != null)
                {
                    db.ChatLog.Remove(chatlog);
                }
            }

            foreach (var groupmember in db.GroupMembers)
            {
                if(groupmember.ChatGroupId == ChatGrouptoRemove.ChatGroupId && ChatGrouptoRemove.Name != null)
                {
                    db.GroupMembers.Remove(groupmember);
                }
            }
            if (ChatGrouptoRemove.Name != null)
            {
                db.ChatGroups.Remove(ChatGrouptoRemove);
            }
            await db.SaveChangesAsync();


            return ListofGroup;
        }

        public async Task<List<MessageInfo>> GroupChat(string NameofGroup) 
        {
            List<MessageInfo> message = new List<MessageInfo>();
            int idofgroup = -1;
            foreach (var group in db.ChatGroups)
            {
                if(group.Name == NameofGroup)
                {
                    idofgroup = group.ChatGroupId;
                    break;
                }
            }
            foreach (var chatlog in db.ChatLog)
            {
                if(chatlog.ChatGroupId == idofgroup)
                {
                    message.Add(new MessageInfo()
                    {
                        NameofSender = findUser(chatlog.UserIdofSender),
                        Message = chatlog.Message,
                        TimeofMessage = chatlog.TimeofMessage,
                        NameofGroup = NameofGroup
                    });
                }
            }
            return message;

            
        }

        public async Task<bool> addChatToGroup(string NameofSender, string NameofGroup, string message)
        {
            int idofgroup = -1;
            foreach (var group in db.ChatGroups)
            {
                if (group.Name == NameofGroup)
                {
                    idofgroup = group.ChatGroupId;
                    break;
                }
            }
            int IDofSender = findUsersID(NameofSender);

            ChatLog newchatmessage = new ChatLog()
            {
                ChatGroupId = idofgroup,
                Message = message,
                UserIdofSender = IDofSender,
                TimeofMessage = DateTime.UtcNow        
            };

            await db.ChatLog.AddAsync(newchatmessage);
            await db.SaveChangesAsync();
            return true;
        }

        public string findUser(int id)
        {
            foreach (var user in db.Users)
            {
                if(user.UserId == id)
                {
                    return user.Username;
                }
                
            }
            return "UserDoesNotExistAnymore";
        }

        public int findUsersID(string UserName)
        {
            foreach (var user in db.Users)
            {
                if(user.Username == UserName)
                {
                    
                    return user.UserId;
                }
            }
            return -1;
        }

    }
}