﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desktop_App
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelEntities : DbContext
    {
        public HotelEntities()
            : base("name=HotelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<booking> bookings { get; set; }
        public virtual DbSet<cleanRequest> cleanRequests { get; set; }
        public virtual DbSet<guest> guests { get; set; }
        public virtual DbSet<maintainenceRequest> maintainenceRequests { get; set; }
        public virtual DbSet<room> rooms { get; set; }
        public virtual DbSet<roomService> roomServices { get; set; }
    }
}
