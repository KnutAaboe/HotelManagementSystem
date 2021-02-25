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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        private HotelEntities dx = new HotelEntities();

        private DbSet<maintainenceRequest> maintainenceRequests;
        private maintainenceRequest selected;

        public Window2()

        {
            InitializeComponent();

            maintainenceRequests = dx.maintainenceRequests;
            
            maintainenceRequests.Load();
            roomMaintananceList.DataContext = maintainenceRequests.Local;
        }


        //TODO: Implementer en metode for å søke etter et gitt romnummer
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            roomMaintananceList.DataContext = maintainenceRequests.Local.Where(r => r.roomNr.ToString() == boxSearch.Text);
        }


        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (boxSearch.Text == "")
            {
                roomMaintananceList.DataContext = this.maintainenceRequests.Local;
            }
        }

        private void maintananceList_Selector(object sender, SelectionChangedEventArgs e)
        {
            selected = ((maintainenceRequest)roomMaintananceList.SelectedItem);
            lblMessages.Content = "You have selected room " + selected.roomNr + ". The notes for this request is " + selected.note + ".";
        }

        private void buttonUpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content == "Maintained")
            {
                if (selected != null)
                {
                    try
                    {
                        maintainenceRequests.Find(selected);
                        maintainenceRequests.Remove(selected);
                        //maintainenceRequests.saveChanges(); //Funker ikke av en eller annen grunn
                        selected = null;
                        maintainenceRequests.Load();
                        roomMaintananceList.DataContext = maintainenceRequests.Local;

                        lblMessages.Content = "Maintanance request deleted";
                    }
                    catch
                    {
                        lblMessages.Content = "A problem while you where removing a maintanance request";
                    }
                }
            }
        }
    }
}
