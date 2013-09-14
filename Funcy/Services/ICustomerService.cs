using System.Collections.Generic;
using Funcy.Domain;

namespace Funcy.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerDetails(int customerId);
        IEnumerable<Order> GetOrdersForCustomer(int customerId);
    }
}