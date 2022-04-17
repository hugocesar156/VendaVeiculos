using Microsoft.EntityFrameworkCore;
using VendaVeiculos.Models.Concessionaria;

namespace VendaVeiculos.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<Concessionaria> Concessionaria { get; set; }
    }
}
