using RegistroDespesaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroDespesaApi.Base
{
    public class RegistroDespesaDbContext : DbContext
    {
        public RegistroDespesaDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Despesa> Despesas { get; set; }
    }
}
