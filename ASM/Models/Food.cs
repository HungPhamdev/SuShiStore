using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public enum Classify
    {
        [Display(Name = "Món Ăn")]
        Food = 1,
        [Display(Name = "Combo")]
        Combo = 2,
        [Display(Name = "Nước uống")]
        Water = 3
    }
    public class Food
    {
        /*
         a. Mã số MonAnID int
         b. Tên món ăn Name nvarchar 250 not null
         c. Mô tả (ngắn gọn) Des nvarchar 250 not null
         d. Giá thành Price money not null
         e. Phân loại: Type món ăn hay combo
         Sử dụng enum
         f. Hình ảnh minh họa nvarchar 150 null
         g. Trạng thái Status
         */
        [Key]
        public int FoodID { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Vui lòng nhập tên món ăn!")]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá!")]
        [Range(0, double.MaxValue, ErrorMessage = "Vui lòng nhập giá!")]
        [Display(Name = "Giá")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phân loại!")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn phân loại!")]
        [Display(Name = "Phân Loại")]
        public Classify Classify { get; set; }


        [Display(Name = "Hình Ảnh")]
        [StringLength(150)]
        public string Image { get; set; }

        [NotMapped]
        [Display(Name = "Chọn hình")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Mô Tả")]
        [StringLength(250)]
        public string Des { get; set; }

        [Display(Name = "Đang phục vụ")]
        public bool Status { get; set; }
    }        
}
