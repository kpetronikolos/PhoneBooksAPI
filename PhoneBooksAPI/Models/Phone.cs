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

        //public PhoneType Type { get; set; }

        private string type;
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (!value.Equals("Work") && !value.Equals("CellPhone") && !value.Equals("Home"))
                {
                    throw new System.ArgumentException("Error");
                }
                else
                {
                    this.type = value;
                }

            }
        }

        public string Number { get; set; }

    }
}
