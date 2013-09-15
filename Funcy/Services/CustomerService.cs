using System;
using System.Collections.Generic;
using Funcy.Domain;

namespace Funcy.Services
{
    public class CustomerService
    {
        private readonly ICacheService _cacheService;
        private readonly ICustomerRepository _customerRepository;

        public Func<int, Customer> GetCustomerDetails;

        public CustomerService(ICacheService cacheService, IOrdersRepository ordersRepository, ICustomerRepository customerRepository)
        {
            _cacheService = cacheService;
            _customerRepository = customerRepository;


            GetCustomerDetails =
            _cacheService.Encachify(
                (int i) => string.Format(@"CustomerDetails{0}", i),
                GetCustomerDetailsCore);
        }


        private Customer GetCustomerDetailsCore(int customerId)
        {
            return _customerRepository.GetById(customerId);
        }

    }
}