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
                    throw new Exception();
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
            List<UserInfo> temp2 = new List<UserInfo>();
            temp2 = await Usercontrol.Addfriend(newfriend);
            for (int i = 0; i < temp2.Count; i++)
            {
                mluser.Friends.Add(new Library.User(temp2[i].Username));
            }
            return RedirectToAction("UserHome");
        }

        public ActionResult GotoGroup(Users user)
        {
            mlgroup.SetName(user.Group);
            mlgroup.SetUsername(mluser.Username);
            mlgroup.Groups = mluser.Groups;
          
            return RedirectToAction("AddMinion");
        }

        public ActionResult AddMinion()
        {
            mlgroup.MessageLog.RemoveRange(0, mlgroup.GetMessageLog().Count);
            mlgroup.AddMemberStr(mlgroup.GetUsername());
            return RedirectToAction("Groups");
        }

        public ActionResult Groups(Groups group)
        {
            group.Group = mlgroup.GetName();
            for (int j = 0; j < mluser.GetGroups().Count; j++)
            {
                group.MyGroups.Add(mluser.Groups[j].GetName());
            }
            group.UserName = mlgroup.GetUsername();
            for (int k = 0; k < mlgroup.GetMembers().Count; k++)
            {
                group.Minions.Add(mlgroup.Members[k].GetName());
            }
            for (int l = 0; l < mlgroup.GetMessageLog().Count; l++)
            {
                group.Messages.Add(mlgroup.MessageLog[l].GetMessageContents());
            }
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

        public async Task<ActionResult> DeleteFriend(Users user)
        {
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

        public ActionResult DeleteGroup(Users user)
        {
            mluser.RemoveGroupStr(user.Group);
            return RedirectToAction("UserHome");
        }
    }
}