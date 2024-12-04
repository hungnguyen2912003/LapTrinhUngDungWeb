using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTT6_Nhom9_63CNTT4.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Phongban> Phongbans { get; set; }

        public System.Data.Entity.DbSet<BTT6_Nhom9_63CNTT4.Models.Chucvu> Chucvus { get; set; }
    }
}
