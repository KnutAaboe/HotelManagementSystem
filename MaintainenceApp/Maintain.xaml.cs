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
    /// Interaction logic for Maintain.xaml
    /// </summary>
    public partial class Maintain : Window
    {
        private HotelEntities dx = new HotelEntities();
        private DbSet<Desktop_App.maintainenceRequest> maintainenceRequest;

        public Maintain(HotelEntities x)
        {
            InitializeComponent();
            dx = x;
            maintainenceRequest = dx.maintainenceRequests;
            maintainenceRequest.Load();
            MaintainList.DataContext = maintainenceRequest.Local;
            //maintainenceL.DataContext = maintainenceRequest.Local;
        }

        private void ChangeStat(object sender, RoutedEventArgs e)
        {
            new ChangeStatus(dx).ShowDialog();
        }
    }
}
