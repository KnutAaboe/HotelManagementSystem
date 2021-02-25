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
using Desktop_App;

namespace MaintainenceApp
{

    public partial class Cleaner : Window
    {
        private HotelEntities dx = new HotelEntities();

        private DbSet<room> rooms;
        private DbSet<booking> bookings;
        private DbSet<cleanRequest> cleanRequests;
        private DbSet<maintainenceRequest> maintainenceRequests;
        private DbSet<roomService> roomServices;

        //private DbSet<room> rooms;
        //private DbSet<booking> bookings;
        //private DbSet<cleanRequest> cleanRequests;
        //private DbSet<maintainenceRequest> maintainenceRequests;
        //private DbSet<roomService> roomServices;

        public Cleaner()
        {
            InitializeComponent();

            rooms = dx.rooms;
            bookings = dx.bookings;
            cleanRequests = dx.cleanRequests;
            maintainenceRequests = dx.maintainenceRequests;
            roomServices = dx.roomServices;

            rooms.Load();

            roomList.DataContext = rooms.Local;

        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}

        public Cleaner(HotelEntities x) : this()
        {

            dx = x;



        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            roomList.DataContext = rooms.Local.Where(room => room.roomNr == int.Parse(search.Text));
        }
    }
}
