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

            //var customers = repository.GetAllCustomers();
            //foreach (var c in customers)
            //{
            //    Console.WriteLine(ConsumerInformationPrinter.BuildConsumerData(c));
            //}

            //var c = repository.GetCustomer(1);
            //Console.WriteLine(c);

            static void AllCustomers(IChinookRepository repository)
            {
                IEnumerable<Customer> allCustomers = repository.GetAllCustomers();
                foreach (Customer customer in allCustomers)
                {
                    Console.WriteLine(customer.ToString());
                }
            }

            AllCustomers(repository);

            static void HighestSpendingCustomers(IChinookRepository repository)
            {
                IEnumerable<HighestSpending> highestSpendingCustomers = repository.GetHighestSpendingCustomers();
                foreach (HighestSpending highestSpendingCustomer in highestSpendingCustomers)
                {
                    Console.WriteLine(highestSpendingCustomer.ToString());
                }
            }

            HighestSpendingCustomers(repository);

            static void CustomersPerCountry(IChinookRepository repository)
            {
                IEnumerable<PerCountry> customersPerCountry = repository.GetUserCountPerCountry();
                foreach (PerCountry customerPerCountry in customersPerCountry)
                {
                    Console.WriteLine(customerPerCountry.ToString());
                }
            }

            CustomersPerCountry(repository);
        }
    }
}
