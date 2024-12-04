using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTT6_Nhom9_63CNTT4.Models
{
    public class Chucvu
    {
        [Key]
        [Required(ErrorMessage = "Mã chức vụ không được để trống!")]
        public string MaCV { get; set; }
        [Required(ErrorMessage = "Tên chức vụ không được để trống!")]
        public string TenCV { get; set; }
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}