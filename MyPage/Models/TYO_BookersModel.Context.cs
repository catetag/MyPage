﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPage.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TYO_BookersEntities : DbContext
    {
        public TYO_BookersEntities()
            : base("name=TYO_BookersEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Bookers> Bookers { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<HotelRooms> HotelRooms { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<ReservationRooms> ReservationRooms { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Kullanıcı_Giris> Kullanıcı_Giris { get; set; }
    }
}
