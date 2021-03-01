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
        private DbSet<Desktop_App.cleanRequest> cleanRequest;

        public Cleaner(HotelEntities x) 
        {
            InitializeComponent();
            dx = x;
            cleanRequest = dx.cleanRequests;
            cleanRequest.Load();
            cleanList.DataContext = cleanRequest.Local;

        }

        private void ChangeStat(object sender, RoutedEventArgs e)
        {
            new ChangeStatus(dx).ShowDialog();
        }


        //private void buttonSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    //roomList.DataContext = validator.roomNrValidator(search.Text, dx);
        //}

        //private void editor_Click(object sender, RoutedEventArgs e)
        //{
        //    //new CleanerEditor(dx).ShowDialog();
        //    new ChangeStatus(dx).ShowDialog();
        //}
    }
}
