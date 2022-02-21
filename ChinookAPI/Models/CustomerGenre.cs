using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookAPI.Models
{
    public class CustomerGenre
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Name}";
        }
    }
}
