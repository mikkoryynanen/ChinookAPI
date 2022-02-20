using System;
using System.Linq;
using System.Collections.Generic;
using ChinookAPI.Models;
using Microsoft.Data.SqlClient;

namespace ChinookAPI.Repositories
{
    public class ChinookRepository: IChinookRepository
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            string query = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                           "FROM Customer";

            List<Customer> customersList = new List<Customer>();

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
                                Customer temp = new Customer()
                                {
                                    CustomerId = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Country = reader.GetString(3),
                                    PostalCode = reader.GetString(4),
                                    Phone = reader.GetString(5),
                                    Email = reader.GetString(6)
                                };

                                customersList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customersList;
        }

        public Customer GetCustomer(int customerId)
        {
            string query = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                           "FROM Customer " +
                           "WHERE CustomerId = @id";

            Customer customerById = new Customer();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", customerId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while ( reader.Read())
                            {
                                customerById = new Customer()
                                {
                                    CustomerId = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Country = reader.GetString(3),
                                    PostalCode = reader.GetString(4),
                                    Phone = reader.GetString(5),
                                    Email = reader.GetString(6)
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customerById;
        }

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
