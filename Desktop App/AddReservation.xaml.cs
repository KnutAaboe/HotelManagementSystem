using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop_App
{
    /// <summary>
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Window
    {
        private HotelEntities dx = new HotelEntities();

        public AddReservation()
        {
            InitializeComponent();
        }
        public AddReservation(HotelEntities x) : this()
        {
            dx = x;
        }

        private void addResBtn_Click(object sender, RoutedEventArgs e)
        {
            booking b = new booking();
            try
            {
                int.TryParse(roomNrBox.Text, out int roomnr);
                if (roomnr != 0 &&
                    phoneNr.Text.Length == 8 && 
                    int.TryParse(phoneNr.Text, out _) &&
                    startDate != null && 
                    endDate != null && 
                    0 >= DateTime.Compare(startDate.DisplayDate, endDate.DisplayDate) &&
                    dx.rooms.Where(r => r.roomNr == roomnr).Count() != 0)
                {
                    responseBox.Content = "Reservation made for room: " + roomnr;
                    roomNrBox.Text = "";

                    dx.bookings.Load();

                    int ID = dx.bookings.Local.Count;
                    while(dx.bookings.Local.Where(book => book.ID == ID).Count() != 0)
                    {
                        ID++;
                    }
                    responseBox.Content += "\nReservation ID: " + ID;
                    b.ID = ID;
                    b.phoneNr = phoneNr.Text;
                    b.roomNr = roomnr;
                    b.startTime = startDate.DisplayDate;
                    b.endTime = endDate.DisplayDate;

                    dx.bookings.Add(b);
                    dx.SaveChanges();

                    phoneNr.Text = roomNrBox.Text = "";
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                responseBox.Content = "Error making reservation.\nNo user with that phone number.";
            }
            catch
            {
                responseBox.Content = "Error making reservation.";
            }
        }
    }
}
