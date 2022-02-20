using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookAPI.Models
{
    public class HighestSpending
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }    
        public decimal Total { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, ${Total}";
        }
    }
}
