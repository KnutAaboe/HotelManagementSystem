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
    /// Interaction logic for CleanerEditor.xaml
    /// </summary>
    public partial class CleanerEditor : Window
    {

        private Hotel_ManagerEntities dx = new Hotel_ManagerEntities();

        private DbSet<room> rooms;
        private DbSet<booking> bookings;
        private DbSet<cleanRequest> cleanRequests;
        private DbSet<maintainenceRequest> maintainenceRequests;
        private DbSet<roomService> roomServices;

        public CleanerEditor()
        {
            InitializeComponent();

            //rooms = dx.room;
            //bookings = dx.booking;
            //cleanRequests = dx.cleanRequest;
            //maintainenceRequests = dx.maintainenceRequest;
            //roomServices = dx.roomService;

            //rooms.Load();

            //roomList.DataContext = rooms.Local;
        }

        public CleanerEditor(Hotel_ManagerEntities x) : this() 
        {
            dx = x;
        }

        private void taskPlacement_Click(object sender, RoutedEventArgs e)
        {
            Cleaner c = new Cleaner();

            //Call e function which checks if submittet room matches one in roomsList, and then check 

            c.roomList.

            
        }

        private void taskNot_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}