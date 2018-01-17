using Minion.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minion.Client.Controllers
{
    public class MinionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult AddUser(Users user)
        {
            MinionChat.Library.User muser = new MinionChat.Library.User();
            muser.SetUsername(user.UserName);
            return RedirectToAction("UserHome", user);
        }

        public ActionResult UserHome(Users user)
        {
            return View(user);
        }

        public ActionResult AddFriend()
        {
            return RedirectToAction("UserHome");
        }

        public ActionResult Groups(Users user)
        {
            return View(user);
        }

        public ActionResult AddGroup()
        {
            return RedirectToAction("UserHome");
        }

        public ActionResult MessageFriend(Users user)
        {
            return View(user);
        }

        public ActionResult MessageMinion(Users user)
        {
            return View(user);
        }

        public ActionResult AddMessage()
        {
            return RedirectToAction("Groups");
        }
    }
}