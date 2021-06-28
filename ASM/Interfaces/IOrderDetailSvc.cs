using ASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interfaces
{
    public interface IOrderDetailSvc
    {
        int AddOrderDetail(OrderDetail orderDetail);
    }
}
