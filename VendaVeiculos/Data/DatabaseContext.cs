using Microsoft.EntityFrameworkCore;
using VendaVeiculos.Models.Concessionaria;
using VendaVeiculos.Models.Veiculo;

namespace VendaVeiculos.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<Concessionaria> Concessionaria { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
    }
}
