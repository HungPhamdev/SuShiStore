using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class Customer
    {
        /*a. Mã số CustomerID int key
        b. Họ tên nvarchar 50 not null
        c. Ngày sinh Datetime not null
        d. Số đt varchar 15 not null
        f. Email varchar 50 not null
        g. FacebookLink varchar 50 null
        h. Password nvarchar 50 not null*/

        [Key]
        public int CustomerID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
        [Display(Name = "Họ & tên")]
        public string FullName { get; set; }

        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại."), Display(Name = "Số điện thoại")]
        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [RegularExpression(@"(\+84|0)+(3[2-9]|5[6|8|9]|9\d(?!5)|8[1-9]|7[0|6-9])+([0-9]{7})\b", ErrorMessage = "Số điện thoại không hợp lệ!")]
        //[RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$)", ErrorMessage = "Số điện thoại không hợp lệ!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không hợp lệ!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        [StringLength(150), Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp!")]
        //[NotMapped]
        public string ConfirmPassword { get; set; }

        [StringLength(250)]
        [Display(Name = "Mô tả")]
        public string Des { get; set; }
    }
}
