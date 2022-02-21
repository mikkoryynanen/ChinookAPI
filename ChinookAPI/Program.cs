using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChinookAPI.Misc;
using ChinookAPI.Models;
using ChinookAPI.Repositories;
using Microsoft.Data.SqlClient;

namespace ChinookAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            IChinookRepository repository = new ChinookRepository();
            //if(repository.CreateCustomer(new Customer { FirstName = "Hello", LastName = "World" , Email = "google@google.com"}))
            //{
            //    Console.WriteLine("customer generated");
            //}
            //else
            //{
            //    Console.WriteLine("customer generation failed");
            //}

            static void AllCustomers(IChinookRepository repository)
            {
                IEnumerable<Customer> allCustomers = repository.GetAllCustomers();
                foreach (Customer customer in allCustomers)
                {
                    Console.WriteLine(customer.ToString());
                }
            }

            //AllCustomers(repository);

            static void UserById(IChinookRepository repository)
            {
                Customer customerById = repository.GetCustomer(2);
                Console.WriteLine(customerById.ToString());
            }

            //UserById(repository);

            static void UserByName(IChinookRepository repository)
            {
                Customer customerByName = repository.FindMatchingCustomerWithName("Sullivan");
                Console.WriteLine(customerByName.ToString());
            }

            //UserByName(repository);

            static void PageOfCustomers(IChinookRepository repository)
            {
                IEnumerable<Customer> pageOfCustomers = repository.GetNumberOfCustomers(2, 4);
                foreach (Customer customer in pageOfCustomers)
                {
                    Console.WriteLine(customer.ToString());
                }
            }

            //PageOfCustomers(repository);

            static void CreateCustomer(IChinookRepository repository)
            {
               // TEST
            }
            
            //CreateCustomer(repository);

            static void UpdateCustomer(IChinookRepository repository)
            {
                // TEST
            }

            //UpdateCustomer(repository);

            static void CustomersPerCountry(IChinookRepository repository)
            {
                IEnumerable<CustomerCountry> customersPerCountry = repository.GetUserCountPerCountry();
                foreach (CustomerCountry customerPerCountry in customersPerCountry)
                {
                    Console.WriteLine(customerPerCountry.ToString());
                }
            }

            //CustomersPerCountry(repository);

            static void HighestSpendingCustomers(IChinookRepository repository)
            {
                IEnumerable<CustomerSpender> highestSpendingCustomers = repository.GetHighestSpendingCustomers();
                foreach (CustomerSpender highestSpendingCustomer in highestSpendingCustomers)
                {
                    Console.WriteLine(highestSpendingCustomer.ToString());
                }
            }

            //HighestSpendingCustomers(repository);

            static void MostPopularGenre(IChinookRepository repository)
            {
                IEnumerable<CustomerGenre> mostPopularGenre = repository.GetMostPopularGenreForCustomer(1);
                foreach (CustomerGenre customerGenre in mostPopularGenre)
                {
                    Console.WriteLine(customerGenre.ToString());
                }
            }

            //MostPopularGenre(repository);

        }
    }
}
