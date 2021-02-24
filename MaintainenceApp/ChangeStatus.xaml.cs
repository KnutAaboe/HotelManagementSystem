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

namespace MaintainenceApp
{
    /// <summary>
    /// Interaction logic for ChangeStatus.xaml
    /// </summary>
    public partial class ChangeStatus : Window
    {
        private Hotel_ManagerEntities dx = new Hotel_ManagerEntities();
        public ChangeStatus()
        {
            InitializeComponent();
        }

        public ChangeStatus(Hotel_ManagerEntities x) : this()
        {
            dx = x;
        }

        private void UpdateInfo(object sender, RoutedEventArgs e)
        {
            roomService rs = new roomService();
            int.TryParse(roomNr.Text, out int roomNr2) {

            }
            rs.roomNr=roomNr2;
            rs.reqStatus = Status.Text;
            rs.requestTime = Date.DisplayDate;
            rs.note = Note.Text;
            dx.roomService.Add(rs);
            dx.SaveChanges();
        }
    }
}
