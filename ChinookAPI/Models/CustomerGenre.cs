using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookAPI.Models
{
    public class CustomerGenre
    {
        public string GenreName { get; set; }

        public override string ToString()
        {
            return $"{GenreName}";
        }
    }
}
