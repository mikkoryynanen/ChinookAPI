using System.Collections.Generic;
using ChinookAPI.Models;

namespace ChinookAPI.Repositories
{
    public interface IChinookRepository
    {
        List<Customer> GetAllCustomers();
        List<Customer> GetNumberOfCustomers(int limit, int offset);
        Customer GetCustomer(int customerId);
        List<Customer> FindMatchingCustomerWithName(string name);
        bool CreateCustomer(Customer newCustomer);
        bool UpdateCustomer(int customerId, Customer updatedCustomerData);
        Dictionary<string, int> GetUserCountPerCountry();
        IEnumerable<HighestSpending> GetHighestSpendingCustomers();
        List<Genre> GetMostPopularGenreForCustomer(int customerId);
    }
}
