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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        private Hotel_ManagerEntities dx = new Hotel_ManagerEntities();

        private DbSet<room> rooms;
        private DbSet<booking> bookings;
        private DbSet<cleanRequest> cleanRequests;
        private DbSet<maintainenceRequest> maintainenceRequests;
        private DbSet<roomService> roomServices;
        private maintainenceRequest selected;

        public Window2()

        {
            InitializeComponent();

            rooms = dx.room;
            bookings = dx.booking;
            cleanRequests = dx.cleanRequest;
            maintainenceRequests = dx.maintainenceRequest;
            roomServices = dx.roomService;

            maintainenceRequests.Load();

            roomMaintananceList.DataContext = maintainenceRequests.Local;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            roomMaintananceList.DataContext = maintainenceRequests.Local.Where(r => r.roomNr.ToString() == search.Text);
        }


        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (search.Text == "")
            {
                roomMaintananceList.DataContext = this.maintainenceRequests.Local;
            }
        }


        private void buttonNeedMaintanace_click(object sender, RoutedEventArgs e)
        {
            roomMaintananceList.DataContext = maintainenceRequests.Local.Where(r => r.reqStatus.ToString() == "Need maintanance");
        }


        private void maintananceList_Selector(object sender, SelectionChangedEventArgs e)
        {
            selected = ((maintainenceRequest)roomMaintananceList.SelectedItem);
            messages.Content = "You have selected room " + selected.roomNr + ". The notes for this request is " + selected.note + ".";
        }


        private void buttonMaintainted_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content == "Maintained")
            {
                if (selected != null)
                {
                    try
                    {
                        dx.maintainenceRequest.Find(selected);
                        dx.maintainenceRequest.Remove(selected);
                        dx.SaveChanges();
                        selected = null;
                        dx.maintainenceRequest.Load();
                        roomMaintananceList.DataContext = dx.maintainenceRequest.Local;

                        messages.Content = "Maintanance request deleted";
                    }
                    catch
                    {
                        messages.Content = "A problem while you where removing a maintanance request";
                    }
                }
            }
        }
    }
}
