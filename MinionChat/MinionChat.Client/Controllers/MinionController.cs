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
                currentUser.UserName = userinfo.Username;
                currentUser.Name = userinfo.Name;
                return RedirectToAction("UserHome");
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
            List<string> temp = new List<string>();
            List<UserInfo> temp2 = new List<UserInfo>();
            temp2 = await Usercontrol.Addfriend(newfriend);
            for (int i = 0; i < temp.Count; i++)
            {
                mluser.Friends.Add(new Library.User(currentUser.Friends[i]));
            }
            return RedirectToAction("UserHome");
        }

        public ActionResult GotoGroup(Users user) // join group
        {
            //mlgroup.SetName(user.Group);
            //mlgroup.SetUsername(mluser.Username);
            //mlgroup.Groups = mluser.Groups;

            currentUser.Group = user.Group;
     //       await Usercontrol.AddGroup()
            return RedirectToAction("Groups");
        }

        //public ActionResult AddMinion()
        //{
        //    mlgroup.MessageLog.RemoveRange(0, mlgroup.GetMessageLog().Count);
        //    mlgroup.AddMemberStr(mlgroup.GetUsername());
        //    return RedirectToAction("Groups");
        //}

        public async Task<ActionResult> Groups(Groups group)
        {
            //group.Group = mlgroup.GetName();
            //for (int j = 0; j < mluser.GetGroups().Count; j++)
            //{
            //    group.MyGroups.Add(mluser.Groups[j].GetName());
            //}
            //group.UserName = mlgroup.GetUsername();
            //for (int k = 0; k < mlgroup.GetMembers().Count; k++)
            //{
            //    group.Minions.Add(mlgroup.Members[k].GetName());
            //}
            //for (int l = 0; l < mlgroup.GetMessageLog().Count; l++)
            //{
            //    group.Messages.Add(mlgroup.MessageLog[l].GetMessageContents());
            //}
            group.UserName = currentUser.UserName;
            group.MyGroups = currentUser.Groups;
            group.Group = currentUser.Group;
            List<MessageInfo> message = await Usercontrol.GetGroupChat(new NameModel() { Name = currentUser.Group });
            group.Messages = message;
            return View(group);
        }

        public ActionResult ChangeGroups(Groups group)
        {
            mlgroup.SetName(group.NewGroup);
            return RedirectToAction("AddMinion");
        }

        public ActionResult AddGroup(Users user)
        {
            mluser.AddGroupStr(user.Group);
            return RedirectToAction("UserHome");
        }

        public ActionResult MessageFriend(Users user, Groups group)
        {
            mlgroup.SetUsername(user.UserName);
            mlgroup.SetName(user.Friend);
            return RedirectToAction("AddMinion");
        }

        public ActionResult MessageMinion(Groups group)
        {
            
            mlgroup.SetName(group.Minion);
            return RedirectToAction("AddMinion");
        }

        public ActionResult AddMessage(Groups group)
        {
            mlgroup.AddMessageStr(group.Message);
            return RedirectToAction("Groups");
        }

        public ActionResult DeleteFriend(Users user)
        {
            mluser.RemoveFriendStr(user.Friend);
            return RedirectToAction("UserHome");
        }

        public ActionResult DeleteGroup(Users user)
        {
            mluser.RemoveGroupStr(user.Group);
            return RedirectToAction("UserHome");
        }
    }
}