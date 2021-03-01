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
using WebApp;

namespace MaintainenceApp
{

    public partial class Cleaner : Window
    {
        private HotelEntities dx = new HotelEntities();
        private DbSet<Desktop_App.cleanRequest> cleanRequests;

        //public Cleaner()
        //{
        //    InitializeComponent();

        //    dx = x;

        //    rooms.Load();

        //    roomList.DataContext = rooms.Local;

        //}

        ////private void InitializeComponent()
        ////{
        ////    throw new NotImplementedException();
        ////}

        public Cleaner(HotelEntities x) 
        {
            InitializeComponent();
            dx = x;
            cleanRequests = dx.cleanRequests;
            cleanRequests.Load();
            cleanList.DataContext = cleanRequests.Local;

        }


        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            //roomList.DataContext = validator.roomNrValidator(search.Text, dx);
        }

        private void editor_Click(object sender, RoutedEventArgs e)
        {
            //new CleanerEditor(dx).ShowDialog();
            new ChangeStatus(dx).ShowDialog();
        }
    }
}
