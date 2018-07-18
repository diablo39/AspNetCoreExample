using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreExample.Model;
using AspNetCoreExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreExample.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _service.GetCustomers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return default(Customer);
        }
    }
}
