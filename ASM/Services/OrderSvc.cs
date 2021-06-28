using ASM.Interfaces;
using ASM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Services
{
    public class OrderSvc : IOrderSvc
    {
        protected DataContext _dataContext;
        public OrderSvc(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Order> GetOrderAll()
        {
            List<Order> orderList = new List<Order>();
            // Dùng kỹ thuật loading Eager // từ khóa Include
            orderList = _dataContext.Orders.OrderByDescending(x => x.OrderDate)
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .ToList();
            return orderList;
        }
        public List<Order> GetOrderbyCustomer(int customerId)
        {
            List<Order> orderList = new List<Order>();
            // Dùng kỹ thuật loading Eager // từ khóa Include
            orderList = _dataContext.Orders.Where(x=>x.CustomerID==customerId).OrderByDescending(x => x.OrderDate)
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .ToList();
            return orderList;
        }
        public Order GetOrder(int id)
        {
            Order order = null;
            order = _dataContext.Orders.Where(x => x.OrderID == id)
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails).ThenInclude(y=>y.Food)
                .FirstOrDefault();
            //order = _dataContext.Orders.Where(x => x.OrderID == id).FirstOrDefault(); // Cách tổng quát
            return order;
        }

        public List<Order> FindOrderAll(double totalMoney)
        {
            return _dataContext.Orders.Where(x => x.TotalMoney == totalMoney).ToList();
        }

        public int AddOrder(Order order)
        {
            int ret = 0;
            try
            {
                _dataContext.Orders.Add(order);
                _dataContext.SaveChanges();
                ret = order.OrderID;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = 0;
            }
            return ret;
        }
        public int EditOrder(int id, Order order)
        {
            int ret = 0;
            try
            {
                _dataContext.Orders.Update(order);
                _dataContext.SaveChanges();
                ret = order.OrderID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = 0;
            }
            return ret;
        }
    }
}
