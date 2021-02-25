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

namespace Desktop_App
{
    public partial class serviceWindow : Window
    {
        private HotelEntities dx;
        private string windowType = "Service";
        private room r;

        public serviceWindow()
        {
            InitializeComponent();
            this.Title = "Whoop";
        }
        public serviceWindow(HotelEntities dx, string type, room r) :this()
        {
            this.dx = dx;
            this.windowType = type;
            this.r = r;

            headerText.Content = type + " for room " + this.r.roomNr;
        }

        private void noteBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(noteBox.Text.Length > 250)
            {
                noteBox.Text = noteBox.Text.Substring(0,250);
                messageBox.Content = "max number of characters is 250!";
            }
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (windowType)
                {
                    case "maintainence":
                        maintainenceRequest mr = new maintainenceRequest();
                        mr.note = noteBox.Text;
                        mr.reqStatus = "TODO";
                        mr.requestTime = DateTime.Now;
                        mr.roomNr = r.roomNr;

                        dx.maintainenceRequests.Add(mr);
                        dx.SaveChanges();
                        break;
                    case "service":
                        roomService rs = new roomService();
                        rs.note = noteBox.Text;
                        rs.reqStatus = "TODO";
                        rs.requestTime = DateTime.Now;
                        rs.roomNr = r.roomNr;

                        dx.roomServices.Add(rs);
                        dx.SaveChanges();
                        break;
                    case "clean":
                        cleanRequest cr = new cleanRequest();
                        cr.note = noteBox.Text;
                        cr.reqStatus = "TODO";
                        cr.requestTime = DateTime.Now;
                        cr.roomNr = r.roomNr;

                        dx.cleanRequests.Add(cr);
                        dx.SaveChanges();
                        break;
                    default:
                        throw new Exception();
                }
                Close();
            }
            catch
            {
                messageBox.Content = "Something went wrong. Try again later.";
            }
            
        }
    }
}
