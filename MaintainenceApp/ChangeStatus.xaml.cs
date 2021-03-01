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
            ComboBox cb = choice;
            DatePicker dp = Date;

            //validator.roomNrValidator(roomNr.Text, dx);
            if (
                int.TryParse(roomNr.Text, out int roomNr2) &&
                Status.Text != null &&
                Date.DisplayDate != null

                )
            {


                switch (cb.Text)
                {
                    case "Service":
                        roomService rs = dx.roomServices.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == dp.SelectedDate));
                        roomService rs2 = new roomService();
                        rs2.roomNr = roomNr2;
                        rs2.reqStatus = Status.Text;
                        rs2.requestTime = dp.SelectedDate.Value;
                        rs2.note = Note.Text;
                        if (rs != null)
                        {
                            dx.roomServices.Remove(rs);
                        }
                        dx.roomServices.Add(rs2);
                        dx.SaveChanges();
                        break;

                    case "Cleaning":
                        cleanRequest cr = dx.cleanRequests.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == dp.SelectedDate));
                        cleanRequest cr2 = new cleanRequest();
                        cr2.roomNr = roomNr2;
                        cr2.reqStatus = Status.Text;
                        cr2.requestTime = dp.SelectedDate.Value;
                        cr2.note = Note.Text;
                        if (cr != null)
                        {
                            dx.cleanRequests.Remove(cr);
                        }
                        dx.cleanRequests.Add(cr2);
                        dx.SaveChanges();
                        break;

                    case "Maintain":
                        maintainenceRequest mr = dx.maintainenceRequests.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == dp.SelectedDate));
                        maintainenceRequest mr2 = new maintainenceRequest();
                        mr2.roomNr = roomNr2;
                        mr2.reqStatus = Status.Text;
                        mr2.requestTime = dp.SelectedDate.Value;
                        mr2.note = Note.Text;
                        if (mr != null)
                        {
                            dx.maintainenceRequests.Remove(mr);
                        }
                        dx.maintainenceRequests.Add(mr2);
                        dx.SaveChanges();
                        break;
                }
                
       
                
            }
           


        }

        private void addRequest(object sender, RoutedEventArgs e)
        {
            ComboBox cb = choice;
            DatePicker dp = Date;

            if (
               int.TryParse(roomNr.Text, out int roomNr2) &&
               Status.Text != null &&
               Date.DisplayDate != null

               )
            {

                switch (cb.Text)
                {

                    case "Service":
                        roomService rs = dx.roomServices.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == dp.SelectedDate));
                        roomService rs2 = new roomService();
                        rs2.roomNr = roomNr2;
                        rs2.reqStatus = Status.Text;
                        rs2.requestTime = dp.SelectedDate.Value;
                        rs2.note = Note.Text;
                        if (rs == null)
                        {
                            dx.roomServices.Add(rs2);
                        }
                        dx.SaveChanges();

                        break;

                    case "Cleaning":
                        cleanRequest cr = dx.cleanRequests.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == dp.SelectedDate));
                        cleanRequest cr2 = new cleanRequest();
                        cr2.roomNr = roomNr2;
                        cr2.reqStatus = Status.Text;
                        cr2.requestTime = dp.SelectedDate.Value;
                        cr2.note = Note.Text;
                        if (cr== null)
                        {
                            dx.cleanRequests.Add(cr2);
                        }
                        dx.SaveChanges();
                        break;

                    case "Maintain":
                        maintainenceRequest mr = dx.maintainenceRequests.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == dp.SelectedDate));
                        maintainenceRequest mr2 = new maintainenceRequest();
                        mr2.roomNr = roomNr2;
                        mr2.reqStatus = Status.Text;
                        mr2.requestTime = dp.SelectedDate.Value;
                        mr2.note = Note.Text;
                        if (mr == null)
                        {
                            dx.maintainenceRequests.Add(mr2);
                        }
                        dx.SaveChanges();
                        break;
                }

            }
            
        }

        private void deleteRequest(object sender, RoutedEventArgs e)
        {
            ComboBox cb = choice;
            DatePicker dp = Date;

            if (
              int.TryParse(roomNr.Text, out int roomNr2) &&
              Status.Text != null &&
              Date.DisplayDate != null

              )
            {

                switch (cb.Text)
                {

                    case "Service":
                        roomService rs = dx.roomServices.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == dp.SelectedDate));
                        if (rs != null)
                        {
                            dx.roomServices.Remove(rs);
                        }
                        dx.SaveChanges();
                        break;

                    case "Cleaning":
                        cleanRequest cr = dx.cleanRequests.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == dp.SelectedDate));
                        if (cr != null)
                        {
                            dx.cleanRequests.Remove(cr);
                        }
                        dx.SaveChanges();
                        break;

                    case "Maintain":
                        maintainenceRequest mr = dx.maintainenceRequests.SingleOrDefault(m => (m.roomNr == roomNr2) && (m.requestTime == dp.SelectedDate));
                        if (mr != null)
                        {
                            dx.maintainenceRequests.Remove(mr);
                        }
                        dx.SaveChanges();
                        break;
                }




                
                //dx.SaveChanges();

            }
        }
    }
}
