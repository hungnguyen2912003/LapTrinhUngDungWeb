﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KT0720NguyenKhacDuyHung_63132095.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KT0720_63132095Entities : DbContext
    {
        public KT0720_63132095Entities()
            : base("name=KT0720_63132095Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LOP> LOP { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIEN { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
