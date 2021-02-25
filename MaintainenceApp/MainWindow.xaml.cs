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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private HotelEntities dx = new HotelEntities();
        private DbSet<room> room;
        private DbSet<booking> booking;
        private DbSet<cleanRequest> cleanRequest;
        private DbSet<maintainenceRequest> maintainenceRequest;
        private DbSet<roomService> roomService;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void getCleaner(object sender, RoutedEventArgs e)
        {
            new Cleaner(dx).ShowDialog();
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
