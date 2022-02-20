using System.Collections.Generic;
using ChinookAPI.Models;

namespace ChinookAPI.Repositories
{
    public interface IChinookRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int customerId);
        List<Customer> GetNumberOfCustomers(int limit, int offset);
        
        List<Customer> FindMatchingCustomerWithName(string name);
        bool CreateCustomer(Customer newCustomer);
        bool UpdateCustomer(int customerId, Customer updatedCustomerData);
        IEnumerable<PerCountry> GetUserCountPerCountry();
        IEnumerable<HighestSpending> GetHighestSpendingCustomers();
        List<Genre> GetMostPopularGenreForCustomer(int customerId);
    }
}
