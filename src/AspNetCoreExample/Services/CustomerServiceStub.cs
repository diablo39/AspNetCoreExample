using AspNetCoreExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreExample.Services
{
    public class CustomerServiceStub
    {
        public IList<Customer> GetCustomers()
        {
            return new Customer[0];    
        }
    }
}
