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
    /// <summary>
    /// Interaction logic for roomEditorWidnow.xaml
    /// </summary>
    public partial class roomEditorWidnow : Window
    {
        private room r;
        private HotelEntities dx;
        public roomEditorWidnow()
        {
            InitializeComponent();
        }

        public roomEditorWidnow(room r, HotelEntities dx) : this()
        {
            this.r = r;
            this.dx = dx;
        }
    }
}
