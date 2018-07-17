using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBooksAPI.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Type { get; set; }

        public string Number { get; set; }

    }
}
