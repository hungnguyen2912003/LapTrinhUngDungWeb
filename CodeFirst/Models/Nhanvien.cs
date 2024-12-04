using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Nhanvien
    {
        [Key]
        public int manhanvien { get; set; }
        public string tennhanvien { get; set; }
        public DateTime ngaysinh { get; set; }
        public decimal luong { get; set; }
        public string hinhanh { get; set; }
        public int maphong { get; set; }
        public virtual Phongban Phongban { get; set; }
    }
}