﻿using System;
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
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : Window
    {
        private Hotel_ManagerEntities dx = new Hotel_ManagerEntities();

        //private DbSet<room> rooms;
        //private DbSet<booking> bookings;
        //private DbSet<cleanRequest> cleanRequests;
        //private DbSet<maintainenceRequest> maintainenceRequests;
        //private DbSet<roomService> roomServices;

        public Service()
        {
            InitializeComponent();
        }

        public Service(Hotel_ManagerEntities x) : this()
        {

            dx =x;

               

        }
    }
}