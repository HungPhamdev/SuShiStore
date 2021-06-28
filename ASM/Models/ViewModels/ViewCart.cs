using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models.ViewModels
{
    public class ViewCart
    {
        [Key]
        public Food Food { get; set; }
        public int Quantity { get; set; }
    }
}
