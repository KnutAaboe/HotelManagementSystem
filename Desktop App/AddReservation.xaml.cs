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
            if (int.TryParse(roomNrBox.Text, out int roomnr) && 0>=DateTime.Compare(startDate.SelectedDate.Value, endDate.SelectedDate.Value)){
                responseBox.Text = "Reservation made for room: " + roomnr;
                roomNrBox.Text = "";
            }
            else
            {
                responseBox.Text = "Error making reservation.";
            }
        }
    }
}
