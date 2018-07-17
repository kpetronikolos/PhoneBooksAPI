using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBooksAPI.Models
{
    public class PhoneBooksAPIContext : DbContext
    {
        public PhoneBooksAPIContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Phone> Phones { get; set; }
    }
}
