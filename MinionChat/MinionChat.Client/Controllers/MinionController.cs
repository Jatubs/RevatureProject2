using Minion.Client.Models;
using MinionChat.Client.Models;
using MinionChat.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<ActionResult> CreateAccount()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount(UserInfo userinfo)
        {
            
            try
            {
                // TODO: Add insert logic here

               bool x = await Usercontrol.AddUsers(userinfo);
                if (x == false)
                {
                    throw new Exception();
                }
                return RedirectToAction("UserHome");
            }
            catch (Exception ex)
            {
                return View();
            }

        }


        public ActionResult AddUse()
        {
            return RedirectToAction("UserHome");
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