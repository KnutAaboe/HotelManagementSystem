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
        private HotelEntities dx;
        private room r;

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
                if (validator.phoneNrValidator(phoneNr.Text) &&
                    validator.roomNrValidator(roomNrBox.Text, dx) &&
                    validator.start_end_dateValidator(startDate, endDate, roomnr, dx))
                {

                    responseBox.Content = "Reservation made for room: " + roomnr;
                    roomNrBox.Text = "";

                    dx.bookings.Load();

                    int id = validator.makeReservationID(dx);

                    responseBox.Content += "\nReservation ID: " + id;
                    b.ID = id;
                    b.phoneNr = phoneNr.Text;
                    b.roomNr = roomnr;
                    b.startTime = startDate.SelectedDate.GetValueOrDefault();
                    b.endTime = endDate.SelectedDate.GetValueOrDefault();

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
