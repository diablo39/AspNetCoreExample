using AspNetCoreExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreExample.Services
{
    public class CustomerServiceStub: ICustomerService
    {
        private static List<Customer> _customers = new List<Customer> {
                new Customer{ FirstName = "Stub", LastName="Kowalski"},
                new Customer{ FirstName = "Stub", LastName="Pawlak"},
                new Customer{ FirstName = "Stub", LastName="Nowak"},
                new Customer{ FirstName = "Stub", LastName="Malinowski"}
            };

        public IList<Customer> GetCustomers()
        {
            // TODO: very complex logic that fetch data from database
            return _customers;
        }
    }
}
