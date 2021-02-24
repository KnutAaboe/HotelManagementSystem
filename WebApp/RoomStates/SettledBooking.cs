using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.RoomStates
{
    public class SettledBooking : BookingState
    {
        public override string ToString()
        {
            return "Settled";
        }
    }       
}

