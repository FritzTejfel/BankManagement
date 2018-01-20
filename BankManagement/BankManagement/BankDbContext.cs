using BankManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagement
{
    class BankDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder
                .UseSqlServer("Server=DESKTOP-B4RNTT3;Database=BankDB;Integrated Security=True;MultipleActiveResultSets=true");
        }
       
    }
}
