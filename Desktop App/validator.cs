using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop_App
{
    static class validator
    {
        public static bool phoneNrValidator(string nr)
        {
            return nr.Length == 8 && int.TryParse(nr, out _);
        }

        public static bool roomNrValidator(string nr, HotelEntities dx)
        {
            return int.TryParse(nr, out int roomnr) 
                && roomnr != 0 
                && dx.rooms.Where(r => r.roomNr == roomnr).Count() != 0;
        }

        public static bool start_end_dateValidator(DatePicker start, DatePicker end, int roomnr, HotelEntities dx)
        {
            bool basic = start != null && end != null && 0 >= DateTime.Compare(start.DisplayDate, end.DisplayDate);

            if (basic)
            {
                DbSet<booking> bookings = dx.bookings;
                bookings.Load();
                int overlappers = bookings.Local.Where(b => b.roomNr == roomnr && 
                                            (  (DateTime.Compare(b.startTime, start.SelectedDate.GetValueOrDefault()) >= 0 && DateTime.Compare(b.endTime, start.SelectedDate.GetValueOrDefault()) < 0)
                                            || (DateTime.Compare(b.startTime, end.SelectedDate.GetValueOrDefault()) >= 0 && DateTime.Compare(b.endTime, end.SelectedDate.GetValueOrDefault()) < 0)
                                            || (DateTime.Compare(b.startTime, start.SelectedDate.GetValueOrDefault()) < 0 && DateTime.Compare(b.endTime, end.SelectedDate.GetValueOrDefault()) >= 0))
                                            ).Count();
                return overlappers == 0;
            }
            else
                return false;
        }

        public static int makeReservationID(HotelEntities dx)
        {
            int id = dx.bookings.Local.Count;
            while (dx.bookings.Local.Where(book => book.ID == id).Count() != 0) id++;
            return id;
        }
    }
}
