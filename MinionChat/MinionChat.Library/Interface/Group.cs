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
        List<string> UserList { get; set; }
        List<String> RoomList { get; set; }

        void CreateRoom();
        void DeleteRoom();
        void SetMessage();
        void UpdateRank();
    }
}
