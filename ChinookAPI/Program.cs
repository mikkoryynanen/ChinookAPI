using System;
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

            var customers = repository.GetAllCustomers();
            foreach (var c in customers)
            {
                Console.WriteLine(ConsumerInformationPrinter.BuildConsumerData(c));
            }

            //var c = repository.GetCustomer(1);
            //Console.WriteLine(c);
        }
    }
}
