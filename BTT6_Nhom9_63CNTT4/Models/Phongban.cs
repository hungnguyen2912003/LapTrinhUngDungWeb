using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTT6_Nhom9_63CNTT4.Models
{
    public class Phongban
    {
        [Key]
        [Required(ErrorMessage = "Mã phòng không được để trống!")]
        public int Maphong { get; set; }
        [Required(ErrorMessage = "Tên phòng không được để trống!")]
        public string Tenphong { get; set; }
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}