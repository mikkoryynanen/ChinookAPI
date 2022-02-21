using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookAPI.Models
{
    public class CustomerCountry
    {
        public string Country { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Country}, {Count}";
        }
    }
}
