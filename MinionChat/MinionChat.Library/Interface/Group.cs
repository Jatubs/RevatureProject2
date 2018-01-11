using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionChat.Library.Interface
{
    interface Group
    {
        string Name { get; set; }
        string Message { get; set; }
        List<User> UserList { get; set; }
        List<Room> RoomList { get; set; }

        void CreateRoom();
        void DeleteRoom();
        void SetMessage();
        void UpdateRank();
    }
}
