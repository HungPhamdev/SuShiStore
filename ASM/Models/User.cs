using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Vui lòng nhập tài khoản!")]
        public string UserName { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên!")]
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không hợp lệ!")]
        public string Email { get; set; }

        [Display(Name = "Chức danh")]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Quản trị")]
        public bool Admin { get; set; }

        [Display(Name = "Sử dụng")]
        public bool Locked { get; set; }

        [Display(Name = "Hình Ảnh")]
        [StringLength(150)]
        public string Image { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Vui lòng chọn hình!")]
        [Display(Name = "Chọn hình")]
        public IFormFile ImageFile { get; set; }

        //[Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Mật khẩu không khớp!")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
