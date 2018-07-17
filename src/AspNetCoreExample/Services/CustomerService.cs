using AspNetCoreExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreExample.Services
{
    public class CustomerService : ICustomerService
    {
        private static List<Customer> _customers = new List<Customer> {
                new Customer{ FirstName = "Jan", LastName="Kowalski"},
                new Customer{ FirstName = "Zbigniew", LastName="Kowalski"},
                new Customer{ FirstName = "Jan", LastName="Nowak"},
                new Customer{ FirstName = "Grażyna", LastName="Nowak"}
            };

        public IList<Customer> GetCustomers()
        {
            // TODO: very complex logic that fetch data from database
            return _customers;
        }
    }
}
