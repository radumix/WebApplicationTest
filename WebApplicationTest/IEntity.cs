using WebApplicationTest.Models;

namespace WebApplicationTest
{
    public interface IEntity
    {
        bool Save(Customer customer);
        List<Customer> GetCustomer();
        Customer GetCustomerById(string Id);
        bool update(Customer customer);
        bool delete(string Id);
    }
}
