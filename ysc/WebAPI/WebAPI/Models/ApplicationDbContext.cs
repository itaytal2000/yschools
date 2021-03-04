using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Candy> tblCandy { get; set; }
        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<CandiesAmount> tblCandyAmount { get; set; }
        public DbSet<Order> tblOrder { get; set; }
    }
}
