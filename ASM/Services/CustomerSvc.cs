using ASM.Interfaces;
using ASM.Models;
using System;
using ASM.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Services
{
    public class CustomerSvc : ICustomerSvc
    {
        protected DataContext _dataContext;
        protected IEncodeHelper _encodeHelper;
        public CustomerSvc(DataContext dataContext, IEncodeHelper encodeHelper)
        {
            _dataContext = dataContext;
            _encodeHelper = encodeHelper;
        }
        public List<Customer> GetCustomerAll()
        {
            List<Customer> customerList = new List<Customer>();
            customerList = _dataContext.Customers.ToList();
            return customerList;
        }
        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            customer = _dataContext.Customers.Find(id);
            //customer = _dataContext.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            return customer;
            //or return _dataContext.Customers.Find(id);
        }

        public List<Customer> FindCustomerAll(string fullName)
        {
            return _dataContext.Customers.Where(f => f.FullName.Contains(fullName)).ToList();
        }

        public bool CheckEmail(string email)
        {
            Customer customer = new Customer();
            customer = _dataContext.Customers.Where(x => x.Email == email).FirstOrDefault();
            if (customer.Email == email)
            {
                return true;
            }
            return false;
        }

        public int AddCustomer(Customer customer)
        {
            int ret = 0;
            try
            {
                customer.Password = _encodeHelper.Encode(customer.Password);
                customer.ConfirmPassword = customer.Password;

                _dataContext.Customers.Add(customer);
                _dataContext.SaveChanges();
                ret = customer.CustomerID;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = 0;
            }
            return ret;
        }
        public int EditCustomer(int id, Customer customer)
        {
            int ret = 0;
            try
            {
                Customer _customer = null;
                _customer = _dataContext.Customers.Find(id);

                _customer.FullName = customer.FullName;
                _customer.Birthday = customer.Birthday;
                _customer.PhoneNumber = customer.PhoneNumber;
                _customer.Email = customer.Email;
                _customer.Address = customer.Address;
                if (_customer.Password != null)
                {
                    //customer.Password = _encodeHelper.Encode(customer.Password);
                    if (customer.Password != null)
                    {
                        customer.Password = _encodeHelper.Encode(customer.Password);
                        _customer.Password = customer.Password;
                        _customer.ConfirmPassword = customer.Password;
                    }
                    _customer.Password = _customer.Password;
                    _customer.ConfirmPassword = _customer.Password;
                }
                _customer.Des = customer.Des;

                _dataContext.Customers.Update(_customer);
                _dataContext.SaveChanges();
                ret = customer.CustomerID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = 0;
            }
            return ret;
        }
        public Customer Login(ViewWebLogin viewWebLogin)
        {
            var u = _dataContext.Customers.Where(
                p => p.Email.Equals(viewWebLogin.Email)
                && p.Password.Equals(_encodeHelper.Encode(viewWebLogin.Password))
                ).FirstOrDefault();
            return u;
        }
    }
}
