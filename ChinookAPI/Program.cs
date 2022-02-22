using System;
using System.Collections.Generic;
using ChinookAPI.Models;
using ChinookAPI.Repositories;

namespace ChinookAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            IChinookRepository repository = new ChinookRepository();

            AllCustomers(repository);
            UserById(repository);
            UserByName(repository);
            PageOfCustomers(repository);
            CreateCustomer(repository);
            UpdateCustomer(repository);
            CustomersPerCountry(repository);
            HighestSpendingCustomers(repository);
            MostPopularGenre(repository);
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>List of all customers</returns>
        public static IEnumerable<Customer> AllCustomers(IChinookRepository repository)
        {
            IEnumerable<Customer> allCustomers = repository.GetAllCustomers();
            return allCustomers;     
        }

        /// <summary>
        /// Get individual customer by given id
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>Customer by id</returns>
        public static Customer UserById(IChinookRepository repository)
        {
            Customer customerById = repository.GetCustomer(2);
            return customerById;
        }

        /// <summary>
        /// Get customer by matching part of name
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>Customer with matching part of name</returns>
        public static Customer UserByName(IChinookRepository repository)
        {
            Customer customerByName = repository.FindMatchingCustomerWithName("Sullivan");
            return customerByName;
        }

        /// <summary>
        /// Get limit value of customers, starting from offset value
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>List of customers with given offset and limit values</returns>
        public static IEnumerable<Customer> PageOfCustomers(IChinookRepository repository)
        {
            IEnumerable<Customer> pageOfCustomers = repository.GetNumberOfCustomers(2, 4);
            return pageOfCustomers;
        }

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>Created customer or null</returns>
        public static Customer CreateCustomer(IChinookRepository repository)
        {
            Customer createCustomer = repository.CreateCustomer("first", "last", "country", "postal", "phone", "email");
            return createCustomer;
        }

        /// <summary>
        /// Update existing customer with given values
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>Updated customer or null</returns>
        public static Customer UpdateCustomer(IChinookRepository repository)
        {
            Customer updateCustomer = repository.UpdateCustomer(59, "123123", "gg@email.com");
            return updateCustomer;
        }

        /// <summary>
        /// Get countries with amount of customers in descending order
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>List of coutries with amount of customers</returns>
        public static IEnumerable<CustomerCountry> CustomersPerCountry(IChinookRepository repository)
        {
            IEnumerable<CustomerCountry> customersPerCountry = repository.GetUserCountPerCountry();
            return customersPerCountry;
        }

        /// <summary>
        /// Get highest spending customers in descending order
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>yList of highest spending customers</returns>
        public static IEnumerable<CustomerSpender> HighestSpendingCustomers(IChinookRepository repository)
        {
            IEnumerable<CustomerSpender> highestSpendingCustomers = repository.GetHighestSpendingCustomers();
            return highestSpendingCustomers;
        }

        /// <summary>
        /// Get selected customer's most popular genre(s)
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>List of selected customer's most popular genre(s)</returns>
        public static IEnumerable<CustomerGenre> MostPopularGenre(IChinookRepository repository)
        {
            IEnumerable<CustomerGenre> mostPopularGenre = repository.GetMostPopularGenreForCustomer(2);
            return mostPopularGenre;
        }
    }
}