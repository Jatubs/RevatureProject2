﻿using Minion.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minion.Client.Controllers
{
    public class MinionController : Controller
    {
        // GET: Minion
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

        public ActionResult AddUser()
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

        public ActionResult Groups()
        {
            return View();
        }

        public ActionResult MessageFriend(Messages message)
        {
            return View();
        }
    }
}