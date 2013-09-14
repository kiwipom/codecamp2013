using System.Collections.Generic;
using Funcy.Domain;

namespace Funcy.Services
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetByCustomer(int customerId);
    }
}