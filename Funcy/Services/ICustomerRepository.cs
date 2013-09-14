using Funcy.Domain;

namespace Funcy.Services
{
    public interface ICustomerRepository
    {
        Customer GetById(int customerId);
    }
}