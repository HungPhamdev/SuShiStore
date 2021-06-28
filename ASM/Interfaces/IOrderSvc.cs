using ASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interfaces
{
    public interface IOrderSvc
    {
        List<Order> GetOrderAll();
        List<Order> GetOrderbyCustomer(int customerId);        
        Order GetOrder(int id);
        List<Order> FindOrderAll(double totalMoney);
        int AddOrder(Order order);
        int EditOrder(int id, Order order);
    }
}
