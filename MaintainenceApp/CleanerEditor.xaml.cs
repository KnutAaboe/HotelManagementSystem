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
    /// Interaction logic for CleanerEditor.xaml
    /// </summary>
    public partial class CleanerEditor : Window
    {

        private HotelEntities dx;
        private room r;
        private DbSet<room> rooms;

        public CleanerEditor()
        {
            InitializeComponent();
        }

        public CleanerEditor(HotelEntities x) : this() 
        {
            dx = x;
        }

        private void taskPlacement_Click(object sender, RoutedEventArgs e)
        {
            cleanRequest cr = new cleanRequest();

            //Check if submittet room matches one in roomsList && find the right room property
            int roomNr = rooms.Where(room => room.roomNr == int.Parse(task.Text)).Count();
            room bestRoom = (room)rooms.Where(room => room.roomNr == int.Parse(task.Text));

            //Place roomnr to right list
            String status;



            switch (taskPlace.SelectedItem.ToString())
            {
                case "doing":
                    status = "DOING";
                    break;

                case "done":
                    status = "DONE";
                    break;

                default:
                    status = "";
                    break;
                   
            }

            if (!(status == ""))
            {
                bestRoom.roomState = status;
            }

            dx.SaveChanges();

            //TODO DOING DONE




        }

        private void taskNote_Click(object sender, RoutedEventArgs e)
        {
            //Check if submittet room matches one in roomsList


            //Add note to task


        }
    }
}
