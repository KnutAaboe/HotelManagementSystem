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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window    {

        private HotelEntities dx = new HotelEntities();

        private DbSet<room> rooms;

        private room selectedRoom;

        public MainWindow()
        {
            InitializeComponent();

            rooms = dx.rooms;

            rooms.Load();

            roomList.DataContext = rooms.Local;

        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            roomList.DataContext = rooms.Local.Where(r => r.roomNr.ToString() == search.Text);
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {

            if(search.Text == "")
            {
                roomList.DataContext = this.rooms.Local;
            }
        }

        private void buttonReserve_Click(object sender, RoutedEventArgs e)
        {
            new AddReservation(dx).ShowDialog();
        }


        //private void roomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Reservations(dx).ShowDialog();
        }

        private void editRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRoom == null)
                return;
            new Reservations(selectedRoom, dx).ShowDialog();
        }

        private void roomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRoom = (room)roomList.SelectedItem;
            //responsBox.Content = "room selected: " + selectedRoom.roomNr;
            editRoomBtn.Content = "Options for room: " + selectedRoom.roomNr;
        }
    }
}
