﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinionChat.DataServer.Models
{
    public class ListofFriendandGroup
    {
        public List<string> Friend { get; set; }
        public List<string> Group { get; set; }
        public bool IsTheUserValid { get; set; }
    }
}