using System.Collections.Generic;
using ChinookAPI.Models;

namespace ChinookAPI.Repositories
{
    public interface IChinookRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int customerId);
        Customer FindMatchingCustomerWithName(string namePart);
        List<Customer> GetNumberOfCustomers(int limit, int offset);
        bool CreateCustomer(Customer newCustomer);
        bool UpdateCustomer(int customerId, Customer updatedCustomerData);
        IEnumerable<PerCountry> GetUserCountPerCountry();
        IEnumerable<HighestSpending> GetHighestSpendingCustomers();
        List<Genre> GetMostPopularGenreForCustomer(int customerId);
    }
}
