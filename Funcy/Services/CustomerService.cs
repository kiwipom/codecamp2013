using System.Collections.Generic;
using Funcy.Domain;

namespace Funcy.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICacheService _cacheService;
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICacheService cacheService, IOrdersRepository ordersRepository, ICustomerRepository customerRepository)
        {
            _cacheService = cacheService;
            _ordersRepository = ordersRepository;
            _customerRepository = customerRepository;
        }


        public Customer GetCustomerDetails(int customerId)
        {
            // create the cache key
            var cacheKey = string.Format(@"CustomerDetails{0}", customerId);

            // check the cache
            var details = _cacheService.Get<Customer>(cacheKey);

            if (details == null)
            {
                //  Nothing in the cache - go get the details...
                details = _customerRepository.GetById(customerId);
            }

            return details;
        }

        public IEnumerable<Order> GetOrdersForCustomer(int customerId)
        {
            // create the cache key
            var cacheKey = string.Format(@"OrdersForCustomer{0}", customerId);

            // check the cache
            var orders = _cacheService.Get<IEnumerable<Order>>(cacheKey);

            if (orders == null)
            {
                //  Nothing in the cache - go get the orders...
                orders = _ordersRepository.GetByCustomer(customerId);
            }

            return orders;
        }
    }
}