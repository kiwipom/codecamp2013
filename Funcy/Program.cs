using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funcy.Services;

namespace Funcy
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CustomerService(null, null, null);


            var customerDetails = service.GetCustomerDetails(123);
        }
    }
}
