using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CodeFirst.Models
{
    public partial class QLNhanvienDBContext : DbContext
    {
        public QLNhanvienDBContext(): base("QLNhanvienDBContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<CodeFirst.Models.Nhanvien> Nhanviens { get; set; }

        public System.Data.Entity.DbSet<CodeFirst.Models.Phongban> Phongbans { get; set; }
    }
}
