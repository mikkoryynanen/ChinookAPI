using System;
using System.Linq;
using System.Collections.Generic;
using ChinookAPI.Models;
using Microsoft.Data.SqlClient;

namespace ChinookAPI.Repositories
{
    public class ChinookRepository: IChinookRepository
    {
        public bool CreateCustomer(Customer newCustomer)
        {
            using (ChinookContext context = new ChinookContext())
            {
                context.Customers.Add(newCustomer);
                return context.SaveChanges() > 0;
            }
        }

        public List<Customer> FindMatchingCustomerWithName(string name)
        {
            using (ChinookContext context = new ChinookContext())
            {
                return context.Customers.Where(customer => customer.FirstName.Contains(name) || customer.LastName.Contains(name)).ToList();
            }
        }

        public Customer GetCustomer(int customerId)
        {
            using (ChinookContext context = new ChinookContext())
            {
                return context.Customers.FirstOrDefault(customer => customer.CustomerId == customerId);
            }
        }

        public IEnumerable<HighestSpending> GetHighestSpendingCustomers()
        {
            string query = "SELECT customer.FirstName, customer.LastName, SUM(invoice.Total) AS total " +
                           "FROM Invoice AS invoice JOIN Customer AS customer ON customer.CustomerId = invoice.CustomerId " +
                           "GROUP BY invoice.CustomerId, customer.FirstName, customer.LastName " +
                           "ORDER BY total DESC";

            List<HighestSpending> spenderList = new();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();  

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HighestSpending temp = new HighestSpending()
                                {
                                    FirstName = reader.GetString(0),
                                    LastName = reader.GetString(1),
                                    Total = reader.GetDecimal(2)
                                };

                                spenderList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return spenderList;
        }

        public List<Genre> GetMostPopularGenreForCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetNumberOfCustomers(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PerCountry> GetUserCountPerCountry()
        { 
            string query = "SELECT customer.Country, COUNT(*) AS count " +
                           "FROM Customer AS customer " +
                           "GROUP BY Country " +
                           "ORDER BY count DESC";

            List<PerCountry> perCountryList = new List<PerCountry>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PerCountry temp = new PerCountry()
                                {
                                    Country = reader.GetString(0),
                                    Count = reader.GetInt32(1)
                                };

                                perCountryList.Add(temp);
                            }
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return perCountryList;
        }

        public List<Customer> GetAllCustomers()
        {
            using (ChinookContext context = new ChinookContext())
            {
                return context.Customers.ToList();
            }
        }

        public bool UpdateCustomer(int customerId, Customer updatedCustomerData)
        {
            using (ChinookContext context = new ChinookContext())
            {
                Customer foundCustomer = context.Customers.FirstOrDefault(customer => customer.CustomerId == customerId);
                if (foundCustomer != null)
                {
                    foundCustomer.FirstName = updatedCustomerData.FirstName;
                    foundCustomer.LastName = updatedCustomerData.LastName;
                    foundCustomer.Company = updatedCustomerData.Company;
                    foundCustomer.Address = updatedCustomerData.Address;
                    foundCustomer.City = updatedCustomerData.City;
                    foundCustomer.State = updatedCustomerData.State;
                    foundCustomer.Country = updatedCustomerData.Country;
                    foundCustomer.PostalCode = updatedCustomerData.PostalCode;
                    foundCustomer.Phone = updatedCustomerData.Phone;
                    foundCustomer.Fax = updatedCustomerData.Fax;
                    foundCustomer.Email = updatedCustomerData.Email;
                    foundCustomer.SupportRepId = updatedCustomerData.SupportRepId;
                    foundCustomer.SupportRep = updatedCustomerData.SupportRep;
                    foundCustomer.Invoices = foundCustomer.Invoices;
                }

                return context.SaveChanges() > 0;
            }
        }
    }
}
