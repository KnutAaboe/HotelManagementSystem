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

namespace MaintainenceApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Hotel_ManagerEntities dx = new Hotel_ManagerEntities();

        private DbSet<room> rooms;
        private DbSet<booking> bookings;
        private DbSet<cleanRequest> cleanRequests;
        private DbSet<maintainenceRequest> maintainenceRequests;
        private DbSet<roomService> roomServices;
        public MainWindow()
        {
            InitializeComponent();

            rooms = dx.room;
            bookings = dx.booking;
            cleanRequests = dx.cleanRequest;
            maintainenceRequests = dx.maintainenceRequest;
            roomServices = dx.roomService;

            rooms.Load();

            
        }

        private void getCleaner(object sender, RoutedEventArgs e)
        {
            //new Cleaner();
        }

        private void getMaintain(object sender, RoutedEventArgs e)
        {
            //new Maintain();
        }

        private void getService(object sender, RoutedEventArgs e)
        {
            new Service(dx).ShowDialog();
        }
    }
}
