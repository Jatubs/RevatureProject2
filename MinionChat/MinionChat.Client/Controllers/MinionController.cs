using Minion.Client.Models;
using MinionChat.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinionChat.Client.Controllers
{
    public class MinionController : Controller
    {
        static MinionChat.Library.User mluser = new MinionChat.Library.User();
        static MinionChat.Library.Group mlgroup = new MinionChat.Library.Group();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AddLogin(Users user)
        {
            mluser.SetUsername(user.UserName);
            mluser.SetPassword(user.Password);
            return RedirectToAction("UserHome");
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult AddUser(Users user)
        {
            mluser.SetUsername(user.UserName);
            mluser.SetPassword(user.Password);
            mluser.SetName(user.Name);
            return RedirectToAction("UserHome");
        }

        public ActionResult UserHome(Users user)
        {
            user.UserName = mluser.GetUsername();
            
            for (int i = 0; i < mluser.GetFriends().Count; i++)
            {
                user.Friends.Add(mluser.Friends[i].GetUsername());
            }
            for (int j = 0; j < mluser.GetGroups().Count; j++)
            {
                user.Groups.Add(mluser.Groups[j].GetName());
            }
            return View(user);
        }
        
        public ActionResult AddFriend(Users user)
        {
            mluser.AddToFriendsStr(user.Friend);
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
            return RedirectToAction("Groups");
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
    }
}