using System;
using System.Collections.Generic;
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
    /// Interaction logic for editBooking.xaml
    /// </summary>
    public partial class editBooking : Window
    {
        private HotelEntities dx;
        private booking b;
        public editBooking()
        {
            InitializeComponent();
        }

        public editBooking(booking b, HotelEntities dx) : this()
        {
            this.b = b;
            this.dx = dx;

            roomNrBox.Text = b.roomNr.ToString();
            phoneNrBox.Text = b.phoneNr;
            startDateBox.SelectedDate = b.startTime;
            endDateBox.SelectedDate = b.endTime;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if(dx.bookings.Find(b.ID) == null)
            {
                responsBox.Content = "Booking does not exist.";
                return;
            }
            else if (!validator.phoneNrValidator(phoneNrBox.Text))
            {
                responsBox.Content = "Invalid phoneNr";
                return;
            }else if (!validator.roomNrValidator(roomNrBox.Text, dx))
            {
                responsBox.Content = "Invalid roomNr";
                return;
            }else if(!validator.start_end_dateValidator(startDateBox, endDateBox, int.Parse(roomNrBox.Text), dx))
            {
                responsBox.Content = "Room busy for some of those days or\ninvalid dates.";
                return;
            }
            else
            {
                try
                {
                    dx.bookings.Remove(dx.bookings.Find(b.ID));

                    booking b2 = new booking();
                    b2.ID = b.ID;
                    b2.phoneNr = phoneNrBox.Text;
                    b2.roomNr = int.Parse(roomNrBox.Text);
                    b2.startTime = startDateBox.SelectedDate.GetValueOrDefault();
                    b2.endTime = endDateBox.SelectedDate.GetValueOrDefault();

                    dx.bookings.Add(b2);
                    dx.SaveChanges();

                    responsBox.Content = "Reservation altered.";
                    this.Close();

                }
                catch
                {
                    responsBox.Content = "Error altering database.";
                }


            }
        }
    }
}
