using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Mới đặt")]
        NewOrdered = 1,
        [Display(Name = "Đang giao")]
        Delivering = 2,
        [Display(Name = "Đã giao")]
        Delivered = 3
    }
    public class Order
    {
        /*
         a. Mã số
        b. Ngày đặt
        c. Trạng thái: mới đặt, đang giao, đã giao
        d. Tổng số tiền
        e. Ghi chú
        f. Mã khách hàng
         */

        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Vui lòng chọn ngày."), Display(Name = "Ngày đặt")]
        public DateTime OrderDate { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "Vui lòng nhập giá!")]
        [Display(Name = "Tổng tiền")]
        public double TotalMoney { get; set; }

        [Display(Name = "Trạng thái")]
        public OrderStatus Status { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
