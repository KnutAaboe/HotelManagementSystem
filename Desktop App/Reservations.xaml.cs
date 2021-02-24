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
    /// Interaction logic for Reservations.xaml
    /// </summary>
    public partial class Reservations : Window
    {
        private HotelEntities dx;
        private static booking selected;
        private room r;
        private bool isSingleRoom = false;

        public Reservations()
        {
            InitializeComponent();
        }
        public Reservations(HotelEntities x) : this()
        {
            dx = x;
            loadRooms();

            grid.Children.Remove(service);
            grid.Children.Remove(maintainence);
            grid.Children.Remove(clean);
            grid.Children.Remove(roomSelected);
        }
        public Reservations(room r, HotelEntities dx) : this()
        {
            this.r = r;
            this.dx = dx;
            isSingleRoom = true;
            loadRooms();
            roomSelected.Content = "You are now looking at reservations for room: " + this.r.roomNr;
        }

        private void reservationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected = ((booking)reservationList.SelectedItem);
            if(selected != null)
                selectedBox.Content = "phoneNr of selected reservation: " + selected.phoneNr;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(((Button)sender) == deleteButton)
            {
                if(selected != null)
                {
                    try
                    {
                        dx.bookings.Remove(dx.bookings.Find(selected.ID));
                        dx.SaveChanges();
                        selected = null;
                        dx.bookings.Load();
                        reservationList.DataContext = dx.bookings.Local;

                        selectedBox.Content = "Reservation deleted.";
                    }
                    catch
                    {
                        selectedBox.Content = "Problem occured while removing element.";
                    }
                }
            }
            else
            {
                selectedBox.Content = "Select an element plz";
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (selected != null)
                new editBooking(selected,dx).ShowDialog();
            else
                selectedBox.Content = "Select an element plz";
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            loadRooms();
        }

        private void loadRooms()
        {
            if (isSingleRoom && r != null)
            {
                dx.bookings.Load();
                if (dx.bookings.Local.Where(b => b.roomNr == this.r.roomNr).Count() == 0)
                {
                    selectedBox.Content = "No elements to show. Add a reservation with this room number to change that.";
                }
                else
                {
                    reservationList.DataContext = dx.bookings.Local.Where(b => b.roomNr == this.r.roomNr);
                }
            }
            else
            {
                dx.bookings.Load();
                reservationList.DataContext = dx.bookings.Local;
            }
        }

        private void ServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if(r != null)
            {
                new serviceWindow(dx, ((Button)sender).Name, r).ShowDialog();
            }else roomSelected.Content = "r is null";

        }
    }
}
