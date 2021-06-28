using ASM.Models;
using System;
using ASM.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interfaces
{
    public interface ICustomerSvc
    {
        List<Customer> GetCustomerAll();
        Customer GetCustomer(int id);
        List<Customer> FindCustomerAll(string fullName);
        bool CheckEmail(string email);
        int AddCustomer(Customer customer);
        int EditCustomer(int id, Customer customer);

        Customer Login(ViewWebLogin viewWebLogin);
    }
}
