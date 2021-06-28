using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class OrderDetail
    {
        /*
        a.Mã số
        b. Mã đơn hàng
        c. Số lượng
        d.Mã món ăn*/

        [Key]
        public int DetailID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        //[ForeignKey("Customer")]
        //public int CustomerID { get; set; }

        [ForeignKey("Food")]
        public int FoodID { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số lượng!")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "Vui lòng nhập thành tiền!")]
        [Display(Name = "Thành tiền")]
        public double IntoMoney { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        public Order Order { get; set; }
        public Food Food { get; set; }
    }
}
