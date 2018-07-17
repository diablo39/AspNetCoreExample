using System.Collections.Generic;
using AspNetCoreExample.Model;

namespace AspNetCoreExample.Services
{
    public interface ICustomerService
    {
        IList<Customer> GetCustomers();
    }
}