using System.Collections.Generic;
using ChinookAPI.Models;

namespace ChinookAPI.Repositories
{
    public interface IChinookRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int customerId);
        Customer FindMatchingCustomerWithName(string namePart);
        IEnumerable<Customer> GetNumberOfCustomers(int offset, int limit);
        bool CreateCustomer(string firstName, string lastName, string country, string postalCode, string phone, string email);
        bool UpdateCustomer(int customerId, string updatedPhone, string updatedEmail);
        IEnumerable<CustomerCountry> GetUserCountPerCountry();
        IEnumerable<CustomerSpender> GetHighestSpendingCustomers();
        IEnumerable<CustomerGenre> GetMostPopularGenreForCustomer(int customerId);
    }
}
