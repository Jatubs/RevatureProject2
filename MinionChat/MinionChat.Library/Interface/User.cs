using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionChat.Library.Interface
{
    interface User
    {
        string Name { get; set; }
        string Password { get; set; }
        List<User> FriendsList { get; set; }
        List<Group> GroupsList { get; set; }
        bool Active { get; set; }

        void LogIn();
        void LogOut();
        void AddFriend();
        void DeleteFriend();
        void AddGroup();
        void DeleteGroup();
        void Chat();
        void UpdateInfo();
    }
}
