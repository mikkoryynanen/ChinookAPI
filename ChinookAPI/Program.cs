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
        }

        static void AllCustomers(IChinookRepository repository)
        {
            IEnumerable<Customer> allCustomers = repository.GetAllCustomers();
            foreach (Customer customer in allCustomers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        static void UserById(IChinookRepository repository)
        {
            Customer customerById = repository.GetCustomer(2);
            Console.WriteLine(customerById.ToString());
        }

        static void UserByName(IChinookRepository repository)
        {
            Customer customerByName = repository.FindMatchingCustomerWithName("Sullivan");
            Console.WriteLine(customerByName.ToString());
        }

        static void PageOfCustomers(IChinookRepository repository)
        {
            IEnumerable<Customer> pageOfCustomers = repository.GetNumberOfCustomers(2, 4);
            foreach (Customer customer in pageOfCustomers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        static void CreateCustomer(IChinookRepository repository)
        {
            // TEST
        }

        static void UpdateCustomer(IChinookRepository repository)
        {
            // TEST
        }

        static void CustomersPerCountry(IChinookRepository repository)
        {
            IEnumerable<CustomerCountry> customersPerCountry = repository.GetUserCountPerCountry();
            foreach (CustomerCountry customerPerCountry in customersPerCountry)
            {
                Console.WriteLine(customerPerCountry.ToString());
            }
        }

        static void HighestSpendingCustomers(IChinookRepository repository)
        {
            IEnumerable<CustomerSpender> highestSpendingCustomers = repository.GetHighestSpendingCustomers();
            foreach (CustomerSpender highestSpendingCustomer in highestSpendingCustomers)
            {
                Console.WriteLine(highestSpendingCustomer.ToString());
            }
        }

        static void MostPopularGenre(IChinookRepository repository)
        {
            IEnumerable<CustomerGenre> mostPopularGenre = repository.GetMostPopularGenreForCustomer(1);
            foreach (CustomerGenre customerGenre in mostPopularGenre)
            {
                Console.WriteLine(customerGenre.ToString());
            }
        }
    }
}