using System;
using System.Text;
using ChinookAPI.Models;

namespace ChinookAPI.Misc
{
    public class ConsumerInformationPrinter
    {
        public static string BuildConsumerData(Customer customer)
        {
            StringBuilder costumerStr = new StringBuilder();
            costumerStr.AppendLine($"ID: {customer.CustomerId}");
            costumerStr.AppendLine($"Name: {customer.FirstName} {customer.LastName}");
            costumerStr.AppendLine($"Country: {customer.Country}");
            costumerStr.AppendLine($"Postal Code: {customer.PostalCode}");
            costumerStr.AppendLine($"Phone: {customer.Phone}");
            costumerStr.AppendLine($"Email: {customer.Email}");
            costumerStr.AppendLine("");
            return costumerStr.ToString();
        }
    }
}
