using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Phongban
    {
        [Key]
        public int maphong { get; set; }
        public string tenphong { get; set; }
        public virtual ICollection<Nhanvien> Nhanvien { get; set; }
    }
}