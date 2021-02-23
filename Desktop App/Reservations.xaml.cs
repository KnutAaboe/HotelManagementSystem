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
        private HotelEntities dx = new HotelEntities();
        private static booking selected;

        public Reservations()
        {
            InitializeComponent();


            dx.bookings.Load();

            reservationList.DataContext = dx.bookings.Local;

            
        }
        public Reservations(HotelEntities x) : this()
        {
            dx = x;
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
            dx.bookings.Load();
            reservationList.DataContext = dx.bookings.Local;
        }
    }
}
