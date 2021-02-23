using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Rooms
{
    public class AvailableState : RoomState
    {
        public override string ToString()
        {
            return "Available";
        }
    }
}