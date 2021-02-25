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
    /// <summary>
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : Window
    {
        private HotelEntities dx = new HotelEntities();

        //private Boolean sortNr = false;

        //private DbSet<room> rooms;
        //private DbSet<booking> bookings;
        //private DbSet<cleanRequest> cleanRequests;
        //private DbSet<maintainenceRequest> maintainenceRequests;
        private DbSet<roomService> service;


        public Service(HotelEntities x)
        {
            InitializeComponent();
            dx =x;
            service = dx.roomServices;
            service.Load();
            serviceList.DataContext = service.Local;

        }

        private void ChangeStat(object sender, RoutedEventArgs e)
        {
            new ChangeStatus(dx).ShowDialog();
        }

        //private void sortRoomNr(object sender, RoutedEventArgs e)
        //{
        //    //service.Local.
        //}
    }
}
