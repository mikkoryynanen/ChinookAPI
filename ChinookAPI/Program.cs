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

        public static IEnumerable<Customer> AllCustomers(IChinookRepository repository)
        {
            IEnumerable<Customer> allCustomers = repository.GetAllCustomers();
            return allCustomers;     
        }

        public static Customer UserById(IChinookRepository repository)
        {
            Customer customerById = repository.GetCustomer(2);
            return customerById;
        }

        public static Customer UserByName(IChinookRepository repository)
        {
            Customer customerByName = repository.FindMatchingCustomerWithName("Sullivan");
            return customerByName;
        }

        public static IEnumerable<Customer> PageOfCustomers(IChinookRepository repository)
        {
            IEnumerable<Customer> pageOfCustomers = repository.GetNumberOfCustomers(2, 4);
            return pageOfCustomers;
        }

        public static Customer CreateCustomer(IChinookRepository repository)
        {
            Customer createCustomer = repository.CreateCustomer("first", "last", "country", "postal", "phone", "email");
            return createCustomer;
        }

        public static Customer UpdateCustomer(IChinookRepository repository)
        {
            Customer updateCustomer = repository.UpdateCustomer(59, "123123", "gg@email.com");
            return updateCustomer;
        }

        public static IEnumerable<CustomerCountry> CustomersPerCountry(IChinookRepository repository)
        {
            IEnumerable<CustomerCountry> customersPerCountry = repository.GetUserCountPerCountry();
            return customersPerCountry;
        }

        public static IEnumerable<CustomerSpender> HighestSpendingCustomers(IChinookRepository repository)
        {
            IEnumerable<CustomerSpender> highestSpendingCustomers = repository.GetHighestSpendingCustomers();
            return highestSpendingCustomers;
        }

        public static IEnumerable<CustomerGenre> MostPopularGenre(IChinookRepository repository)
        {
            IEnumerable<CustomerGenre> mostPopularGenre = repository.GetMostPopularGenreForCustomer(2);
            return mostPopularGenre;
        }
    }
}