﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Hotel_ManagerEntities : DbContext
    {
        public Hotel_ManagerEntities()
            : base("name=Hotel_ManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<booking> Bookings { get; set; }
        public virtual DbSet<cleanRequest> CleanRequests { get; set; }
        public virtual DbSet<guest> Guests { get; set; }
        public virtual DbSet<maintainenceRequest> MaintainenceRequests { get; set; }
        public virtual DbSet<room> Rooms { get; set; }
        public virtual DbSet<roomService> RoomServices { get; set; }
    }
}
