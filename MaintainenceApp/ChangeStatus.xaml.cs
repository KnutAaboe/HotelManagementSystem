using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Desktop_App;

namespace MaintainenceApp
{
    /// <summary>
    /// Interaction logic for ChangeStatus.xaml
    /// </summary>
    public partial class ChangeStatus : Window
    {
        private HotelEntities dx = new HotelEntities();
        public ChangeStatus()
        {
            InitializeComponent();
        }

        public ChangeStatus(HotelEntities x) : this()
        {
            dx = x;
        }

        private void UpdateInfo(object sender, RoutedEventArgs e)
        {
            //validator.roomNrValidator(roomNr.Text, dx);
            if (
                int.TryParse(roomNr.Text, out int roomNr2) &&
                Status.Text != null &&
                Date.DisplayDate != null

                )
            {
                Console.WriteLine(sender + "  " + e);
                roomService rs = dx.roomServices.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == Date.DisplayDate));
                roomService rs2 = new roomService();
                rs2.roomNr = roomNr2;
                rs2.reqStatus = Status.Text;
                rs2.requestTime = Date.DisplayDate;
                rs2.note = Note.Text;
                if (rs != null)
                {
                    dx.roomServices.Remove(rs);
                }
                dx.roomServices.Add(rs2);
                dx.SaveChanges();
            }
            else
            {

            }


        }

        private void addRequest(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (
               int.TryParse(roomNr.Text, out int roomNr2) &&
               Status.Text != null &&
               Date.DisplayDate != null

               )
            {

                switch (btn.Content)
                {

                    case "Add service":
                        roomService rs = dx.roomServices.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == Date.DisplayDate));
                        roomService rs2 = new roomService();
                        rs2.roomNr = roomNr2;
                        rs2.reqStatus = Status.Text;
                        rs2.requestTime = Date.DisplayDate;
                        rs2.note = Note.Text;
                        if (rs == null)
                        {
                            dx.roomServices.Add(rs2);
                        }
                        //dx.SaveChanges();

                        break;

                    case "Add clean":
                        cleanRequest cr = dx.cleanRequests.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == Date.DisplayDate));
                        cleanRequest cr2 = new cleanRequest();
                        cr2.roomNr = roomNr2;
                        cr2.reqStatus = Status.Text;
                        cr2.requestTime = Date.DisplayDate;
                        cr2.note = Note.Text;
                        if (cr== null)
                        {
                            dx.cleanRequests.Add(cr2);
                        }

                        break;
                }

                dx.SaveChanges();



                //roomService rs = dx.roomServices.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == Date.DisplayDate));
                //roomService rs2 = new roomService();
                //rs2.roomNr = roomNr2;
                //rs2.reqStatus = Status.Text;
                //rs2.requestTime = Date.DisplayDate;
                //rs2.note = Note.Text;
                //if (rs == null)
                //{
                //    dx.roomServices.Add(rs2);
                //}
                //dx.SaveChanges();

            }
            
        }

        private void deleteRequest(object sender, RoutedEventArgs e)
        {
            if (
              int.TryParse(roomNr.Text, out int roomNr2) &&
              Status.Text != null &&
              Date.DisplayDate != null

              )
            {
                roomService rs = dx.roomServices.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == Date.DisplayDate));
                if (rs != null)
                {
                    dx.roomServices.Remove(rs);
                }
                dx.SaveChanges();

            }
            else
            {

            }
        }
    }
}
