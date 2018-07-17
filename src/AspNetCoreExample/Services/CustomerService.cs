using AspNetCoreExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreExample.Services
{
    public class CustomerService
    {
        public IList<Customer> GetCustomers()
        {
            // TODO: very complex logic that fetch data from database
            return new Customer[] {
                new Customer{ FirstName = "Jan", LastName="Kowalski"},
                new Customer{ FirstName = "Zbigniew", LastName="Kowalski"},
                new Customer{ FirstName = "Jan", LastName="Nowak"},
                new Customer{ FirstName = "Grażyna", LastName="Nowak"}

            };
        }
    }
}
