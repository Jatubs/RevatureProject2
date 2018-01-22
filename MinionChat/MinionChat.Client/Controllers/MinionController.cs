using MinionChat.Client.Models;
using MinionChat.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MinionChat.Client.Controllers
{
    public class MinionController : Controller
    {
        static MinionChat.Library.User mluser = new MinionChat.Library.User();
        static MinionChat.Library.Group mlgroup = new MinionChat.Library.Group();
        static Users currentUser = new Users();
        static Groups Globalgroup = new Groups();
        public ActionResult Index()
        {
            return View();

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(UserInfo user)
        {
            ListofFriendandGroup lists = await Usercontrol.Login(user);
            if (lists.IsTheUserValid)
            {
                currentUser.Friends = lists.Friend;
                currentUser.Groups = lists.Group;
                currentUser.UserName = user.Username;
                Globalgroup.MyGroups = lists.Group;
                return RedirectToAction("UserHome", currentUser);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<ActionResult> CreateAccount()
        {
            //good
            return View();
        } 
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount(UserInfo userinfo)
        {
            //good
            try
            {
                // TODO: Add insert logic here
                bool x = await Usercontrol.AddUsers(userinfo);
                if (x == false)
                {
                    return View();
                }
                //currentUser.UserName = userinfo.Username;
                //currentUser.Name = userinfo.Name;
                //currentUser.Friends = new List<string>();
                ListofFriendandGroup lists = await Usercontrol.Login(userinfo);
                if (lists.IsTheUserValid)
                {
                    currentUser.Friends = lists.Friend;
                    currentUser.Groups = lists.Group;
                    currentUser.UserName = userinfo.Username;
                    Globalgroup.MyGroups = lists.Group;
                    return RedirectToAction("UserHome", currentUser);
                }
                else
                {
                    return View();
                }

                //return RedirectToAction("UserHome");
            }
            catch (Exception ex)
            {
                return View();
            }

        }


        public ActionResult AddUse(Users user)
        {
            mluser.SetUsername(user.UserName);
            mluser.SetPassword(user.Password);
            mluser.SetName(user.Name);
            return RedirectToAction("UserHome");
        }

        public ActionResult UserHome(Users userswithlist)
        {
        
            return View(currentUser);
        }
        
        public async Task<ActionResult> AddFriend(Users user)
        {

            FriendModel newfriend = new FriendModel();
            newfriend.Username = currentUser.UserName;
            if (newfriend.Username == null)
            {
                newfriend.Username = "we";
            }
            newfriend.Friendname = user.Friend;
            List<UserInfo> temp2 = new List<UserInfo>();

            if(user.Friend == null)
            {
                return RedirectToAction("UserHome");

            }
            temp2 = await Usercontrol.Addfriend(newfriend);
            for (int i = 0; i < temp2.Count; i++)
            {
                mluser.Friends.Add(new Library.User(temp2[i].Username));
            }
            return RedirectToAction("UserHome");
        }

        public async Task<ActionResult> GotoGroup(Users user) // join group
        {
            //mlgroup.SetName(user.Group);
            //mlgroup.SetUsername(mluser.Username);
            //mlgroup.Groups = mluser.Groups;
            bool groupexists = false;
            foreach (var group in Globalgroup.MyGroups)
            {
                if (group == user.Group)
                {
                    groupexists = true;
                }
            }


            if (groupexists == true)
            {
                currentUser.Group = user.Group;
                //       await Usercontrol.AddGroup()
                Globalgroup.UserName = currentUser.UserName;
                Globalgroup.MyGroups = currentUser.Groups;
                Globalgroup.Group = currentUser.Group;
                List<MessageInfo> message = await Usercontrol.GetGroupChat(new NameModel() { Name = currentUser.Group });
                Globalgroup.Messages = message;

                return RedirectToAction("Groups");
            }
            else return RedirectToAction("UserHome");
        }

        public ActionResult AddMinion()
        {
            mlgroup.MessageLog.RemoveRange(0, mlgroup.GetMessageLog().Count);
            mlgroup.AddMemberStr(mlgroup.GetUsername());
            return RedirectToAction("Groups");
        }

        public async Task<ActionResult> Groups(Groups group)
        {
            List<MessageInfo> message = await Usercontrol.GetGroupChat(new NameModel() { Name = currentUser.Group });
            Globalgroup.Messages = message;
            return View(Globalgroup);
        }

        

        public async Task<ActionResult> AddGroup(Users user)
        {
            if (user.Group == null)
            {
                return RedirectToAction("UserHome");

            }
            NameModel testmod = new NameModel();
            testmod.Name = user.Group;
            List<string> groups = await Usercontrol.AddGroup(testmod);
            currentUser.Groups = groups;
            Globalgroup.MyGroups = groups;


            return RedirectToAction("UserHome");
        }
        //______
        public async Task<ActionResult> MessageFriend(Users user, Groups group)
        {

            currentUser.Group = user.Group;
            currentUser.Friend = user.Friend;
            //       await Usercontrol.AddGroup()
            Globalgroup.UserName = currentUser.UserName;
            Globalgroup.MyGroups = currentUser.Groups;
            Globalgroup.Group = currentUser.Group = currentUser.UserName+user.Friend;
            List<MessageInfo> message = await Usercontrol.GetFriendChat(new FriendModel() { Friendname = user.Friend, Username = currentUser.UserName });
    
            Globalgroup.Messages = message;

            return RedirectToAction("GroupsFriend");

        }

        public async Task<ActionResult> GroupsFriend(Groups group)
        {
            List<MessageInfo> message = await Usercontrol.GetFriendChat(new FriendModel() { Friendname = currentUser.Friend, Username = currentUser.UserName });
            Globalgroup.Messages = message;
            return View(Globalgroup);
        }


        public async Task<ActionResult> AddMessageFriend(Groups group)
        {
                //mlgroup.AddMessageStr(group.Message);
                Globalgroup.Messages.Add(new MessageInfo()
                {
                    Message = group.Message,
                    NameofSender = currentUser.UserName,
                    NameofGroup = currentUser.Group,
                    TimeofMessage = DateTime.Now

                });
                await Usercontrol.AddChatToFriend(new MessageInfo()
                {
                    Message = group.Message,
                    NameofSender = currentUser.UserName,
                    NameofGroup = currentUser.Friend
                });
                return RedirectToAction("GroupsFriend");
        }
        
        //__________________________
            public ActionResult MessageMinion(Groups group)
        {
            
            mlgroup.SetName(group.Minion);
            return RedirectToAction("AddMinion");
        }

        public async Task<ActionResult> AddMessage(Groups group)
        {
            //mlgroup.AddMessageStr(group.Message);
            Globalgroup.Messages.Add(new MessageInfo()
            {
                Message = group.Message,
                NameofSender = currentUser.UserName,
                NameofGroup = currentUser.Group,
                TimeofMessage = DateTime.Now
                
            });
            await Usercontrol.AddChatToGroup(new MessageInfo()
            {
                Message = group.Message,
                NameofSender = currentUser.UserName,
                NameofGroup = currentUser.Group
            });
            return RedirectToAction("Groups");
        }

        public async Task<ActionResult> DeleteFriend(Users user)
        {
            if (user.Friend == null)
            {
                return RedirectToAction("UserHome");

            }
            //mluser.RemoveFriendStr(user.Friend);
            FriendModel newfriend = new FriendModel();
            newfriend.Username = currentUser.UserName;
            if (newfriend.Username == null)
            {
                newfriend.Username = "we";
            }
            newfriend.Friendname = user.Friend;
            List<string> temp2 = new List<string>();
            temp2 = await Usercontrol.RemoveFriend(newfriend);
            for (int i = 0; i < temp2.Count; i++)
            {
                mluser.Friends.Add(new Library.User(temp2[i]));
            }
            return RedirectToAction("UserHome");
        }

        public async Task<ActionResult> DeleteGroup(Users user)
        {
            if (user.Group == null)
            {
                return RedirectToAction("UserHome");

            }
            NameModel testmod = new NameModel();
            testmod.Name = user.Group;
            List<string> groups = await Usercontrol.RemoveGroup(testmod);
            currentUser.Groups = groups;
            Globalgroup.MyGroups = groups;
            return RedirectToAction("UserHome");
        }
    }
}