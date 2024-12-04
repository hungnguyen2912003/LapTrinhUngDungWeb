using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTT6_Nhom9_63CNTT4.Models
{
    public class Nhanvien
    {
        [Key]
        [Required(ErrorMessage = "Mã nhân viên không được để trống!")]
        public int Manv { get; set; }
        [Required(ErrorMessage = "Họ tên nhân viên không được để trống!")]
        public string Hotennv { get; set; }
        [Required(ErrorMessage = "Ngày sinh nhân viên không được để trống!")]
        public DateTime Ngsinh { get; set; }
        [Required(ErrorMessage = "Mức lương nhân viên không được để trống!")]
        public decimal Luong { get; set; }
        public string Hinhanh { get; set; }
        public int Maphong { get; set; }
        public string MaCV { get; set; }
        public virtual Chucvu Chucvu { get; set; }
        public virtual Phongban Phongban { get; set; }
    }
}