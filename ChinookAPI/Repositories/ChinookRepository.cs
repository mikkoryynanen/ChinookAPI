﻿using System;
using System.Linq;
using System.Collections.Generic;
using ChinookAPI.Models;

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

        public List<Customer> GetHighestSpendingCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetMostPopularGenreForCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetNumberOfCustomers(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetUserCountPerCountry()
        {
            throw new NotImplementedException();
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
