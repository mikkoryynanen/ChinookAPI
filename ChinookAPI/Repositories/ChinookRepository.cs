using System;
using System.Linq;
using System.Collections.Generic;
using ChinookAPI.Models;
using Microsoft.Data.SqlClient;
using ChinookAPI.Misc;

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
                                    FirstName = GetSafeData.SafeGetString(reader, 1),
                                    LastName = GetSafeData.SafeGetString(reader, 2),
                                    Country = GetSafeData.SafeGetString(reader, 3),
                                    PostalCode = GetSafeData.SafeGetString(reader, 4),
                                    Phone = GetSafeData.SafeGetString(reader, 5),
                                    Email = GetSafeData.SafeGetString(reader, 6)
                                };

                                customersList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex);
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
                                    FirstName = GetSafeData.SafeGetString(reader,1),
                                    LastName = GetSafeData.SafeGetString(reader,2),
                                    Country = GetSafeData.SafeGetString(reader,3),
                                    PostalCode = GetSafeData.SafeGetString(reader,4),
                                    Phone = GetSafeData.SafeGetString(reader,5),
                                    Email = GetSafeData.SafeGetString(reader,6)
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

        public Customer FindMatchingCustomerWithName(string namePart)
        {
            string query = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                           "FROM Customer " +
                           "WHERE FirstName LIKE @namepart OR LastName LIKE @namepart";

            Customer customerByName = new Customer();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@namepart", namePart);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                           while (reader.Read())
                            {
                                customerByName = new Customer()
                                {
                                    CustomerId = reader.GetInt32(0),
                                    FirstName = GetSafeData.SafeGetString(reader,1),
                                    LastName = GetSafeData.SafeGetString(reader,2),
                                    Country = GetSafeData.SafeGetString(reader,3),
                                    PostalCode = GetSafeData.SafeGetString(reader,4),
                                    Phone = GetSafeData.SafeGetString(reader,4),
                                    Email = GetSafeData.SafeGetString(reader,6)
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

            return customerByName;
        }

        public IEnumerable<Customer> GetNumberOfCustomers(int offset, int limit)
        {
            string query = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                           "FROM Customer " +
                           "ORDER BY CustomerId " +
                           "OFFSET @resultsoffset ROWS " +
                           "FETCH NEXT @resultslimit ROWS ONLY";

            List<Customer> customersPageList = new List<Customer>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        ;
                        command.Parameters.AddWithValue("@resultsoffset", offset);
                        command.Parameters.AddWithValue("@resultslimit", limit);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer()
                                {
                                    CustomerId = reader.GetInt32(0),
                                    FirstName = GetSafeData.SafeGetString(reader,1),
                                    LastName = GetSafeData.SafeGetString(reader,2),
                                    Country = GetSafeData.SafeGetString(reader,3),
                                    PostalCode = GetSafeData.SafeGetString(reader,4),
                                    Phone = GetSafeData.SafeGetString(reader,5),
                                    Email = GetSafeData.SafeGetString(reader,6)
                                };

                                customersPageList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customersPageList;
        }

        public bool CreateCustomer(string firstName, string lastName, string country, string postalCode, string phone, string email)
        {
            string query = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) " +
                           "VALUES (@firstname, @lastname, @customercountry, @postalcode, @customerphone, @customeremail)";

            bool createRowsAffected = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@firstname", firstName);
                        command.Parameters.AddWithValue("@lastname", lastName);
                        command.Parameters.AddWithValue("@customercountry", country);
                        command.Parameters.AddWithValue("@postalcode", postalCode);
                        command.Parameters.AddWithValue("@customerphone", phone);
                        command.Parameters.AddWithValue("@customeremail", email);

                        createRowsAffected = command.ExecuteNonQuery() > 0;
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return createRowsAffected;
        }

        public bool UpdateCustomer(int customerId, string updatedPhone, string updatedEmail)
        {
            string query = "UPDATE Customer " +
                           "SET Phone = @updatedphone AND Email = @updatedemail " +
                           "WHERE CustomerId = @id";

            bool updateRowsAffected = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", customerId);
                        command.Parameters.AddWithValue("@updatedphone", updatedPhone);
                        command.Parameters.AddWithValue("@updatedemail", updatedEmail);

                        updateRowsAffected = command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return updateRowsAffected;
        }

        public IEnumerable<CustomerSpender> GetHighestSpendingCustomers()
        {
            string query = "SELECT customer.FirstName, customer.LastName, SUM(invoice.Total) AS total " +
                           "FROM Invoice AS invoice JOIN Customer AS customer ON customer.CustomerId = invoice.CustomerId " +
                           "GROUP BY invoice.CustomerId, customer.FirstName, customer.LastName " +
                           "ORDER BY total DESC";

            List<CustomerSpender> spenderList = new();

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
                                CustomerSpender temp = new CustomerSpender()
                                {
                                    FirstName = GetSafeData.SafeGetString(reader,0),
                                    LastName = GetSafeData.SafeGetString(reader,1),
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

        public IEnumerable<CustomerCountry> GetUserCountPerCountry()
        { 
            string query = "SELECT customer.Country, COUNT(*) AS count " +
                           "FROM Customer AS customer " +
                           "GROUP BY Country " +
                           "ORDER BY count DESC";

            List<CustomerCountry> perCountryList = new List<CustomerCountry>();

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
                                CustomerCountry temp = new CustomerCountry()
                                {
                                    Country = GetSafeData.SafeGetString(reader,0),
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

        public IEnumerable<CustomerGenre> GetMostPopularGenreForCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
