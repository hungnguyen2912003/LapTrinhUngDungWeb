﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo_PTTKHTTT.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Demo_QLBHEntities : DbContext
    {
        public Demo_QLBHEntities()
            : base("name=Demo_QLBHEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CHITIETHOADON> CHITIETHOADON { get; set; }
        public virtual DbSet<DONNHAPHANG> DONNHAPHANG { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<LOAIMATHANG> LOAIMATHANG { get; set; }
        public virtual DbSet<MATHANG> MATHANG { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAP { get; set; }
        public virtual DbSet<TRONG1> TRONG1 { get; set; }
    }
}