using CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ClientePf> Clientes { get; set; }
        public DbSet<ClientePJ> ClientePJ { get; set; }
    }
}
