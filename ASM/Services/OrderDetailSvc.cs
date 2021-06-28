using ASM.Interfaces;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Services
{
    public class OrderDetailSvc : IOrderDetailSvc
    {
        protected DataContext _dataContext;
        public OrderDetailSvc(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int AddOrderDetail(OrderDetail orderDetail)
        {
            int ret = 0;
            try
            {
                _dataContext.OrderDetails.Add(orderDetail);
                _dataContext.SaveChanges();
                ret = orderDetail.DetailID;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = 0;
            }
            return ret;
        }
    }
}
