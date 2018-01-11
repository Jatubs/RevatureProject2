using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionChat.Library.Interface
{
    interface Room
    { 
        string RoomName { get; set; }
        string Type { get; set; }

        void InsertText();
        void Leave();
    }
}
