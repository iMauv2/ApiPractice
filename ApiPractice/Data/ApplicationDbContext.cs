using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Clients> clients { get; set; }
        public DbSet<Invoices> invoices { get; set; }
    }
}
