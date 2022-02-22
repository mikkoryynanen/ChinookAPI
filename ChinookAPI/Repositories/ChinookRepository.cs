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
        /// <summary>
        /// Get all customers from database
        /// </summary>
        /// <returns>List of all customers</returns>
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

        /// <summary>
        /// Get individual customer by selected id from database
        /// </summary>
        /// <param name="customerId">Id of customer</param>
        /// <returns>Customer by id</returns>
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

        /// <summary>
        /// Get customer by matching part of name from database
        /// </summary>
        /// <param name="namePart">Part of customer's name</param>
        /// <returns>Customer by matching part of name</returns>
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

        /// <summary>
        /// Get limit value of customers, starting from offset value, from database
        /// </summary>
        /// <param name="offset">Offset of results</param>
        /// <param name="limit">Limit of results</param>
        /// <returns>List of customers with offset and limit values</returns>
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

        /// <summary>
        /// Create new customer with given values to database
        /// </summary>
        /// <param name="firstName">First name of customer</param>
        /// <param name="lastName">Last name of customer</param>
        /// <param name="country">Country of customer</param>
        /// <param name="postalCode">Postal code of customer</param>
        /// <param name="phone">Phone of customer</param>
        /// <param name="email">Email of customer</param>
        /// <returns>New customer if user is created or null if user is not created</returns>
        public Customer CreateCustomer(string firstName, string lastName, string country, string postalCode, string phone, string email)
        {
            string query = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) " +
                           "VALUES (@firstname, @lastname, @customercountry, @postalcode, @customerphone, @customeremail)";

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

                        bool createRowsAffected = command.ExecuteNonQuery() > 0;

                        return createRowsAffected ? new Customer
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Country = country,
                            PostalCode = postalCode,
                            Phone = phone,
                            Email = email
                        } : null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Update existing customer with given values in database
        /// </summary>
        /// <param name="customerId">Id of customer</param>
        /// <param name="updatedPhone">Updated phone number of customer</param>
        /// <param name="updatedEmail">Updated email address of customer</param>
        /// <returns>Updated customer if customer is updated or null if customer is not updated</returns>
        public Customer UpdateCustomer(int customerId, string updatedPhone, string updatedEmail)
        {
            string query = "UPDATE Customer " +
                           "SET Phone = @updatedphone, Email = @updatedemail " +
                           "WHERE CustomerId = @id";

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

                        bool updateRowsAffected = command.ExecuteNonQuery() > 0;
                        return updateRowsAffected ? GetCustomer(customerId) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Get highest spending customers in descending order from database
        /// </summary>
        /// <returns>List of highest spending customers</returns>
        public IEnumerable<CustomerSpender> GetHighestSpendingCustomers()
        {
            string query = "SELECT customer.FirstName, customer.LastName, SUM(invoice.Total) AS total " +
                           "FROM Invoice AS invoice " +
                           "JOIN Customer AS customer ON customer.CustomerId = invoice.CustomerId " +
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

        /// <summary>
        /// Get countries with amount of customers in descending order from database
        /// </summary>
        /// <returns>List of countries with amount of customers</returns>
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

        /// <summary>
        /// Get most popular genre(s) of given customer from database
        /// </summary>
        /// <param name="customerId">Id of customer</param>
        /// <returns>List of most popular genre(s)</returns>
        public IEnumerable<CustomerGenre> GetMostPopularGenreForCustomer(int customerId)
        {
            string query = "SELECT TOP 1 genre.Name, COUNT(genre.Name) AS count " +
                           "FROM Customer AS customer " +
                           "JOIN Invoice AS invoice ON customer.CustomerId = invoice.CustomerId " +
                           "JOIN InvoiceLine AS invoiceline ON invoice.InvoiceId = invoiceline.InvoiceId " +
                           "JOIN Track AS track ON invoiceline.TrackId = track.TrackId " +
                           "JOIN Genre AS genre ON track.GenreId = genre.GenreId " +
                           "WHERE customer.CustomerId = @id " +
                           "GROUP BY genre.Name " +
                           "ORDER BY count DESC";

            List<CustomerGenre> genreList = new List<CustomerGenre>();

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
                            while (reader.Read())
                            {
                                CustomerGenre temp = new CustomerGenre()
                                {
                                    GenreName = GetSafeData.SafeGetString(reader, 0)
                                    
                                };

                                genreList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return genreList;
        }
    }
}
