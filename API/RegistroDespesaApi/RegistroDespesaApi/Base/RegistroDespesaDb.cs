using RegistroDespesaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroDespesaApi.Base
{
    public class RegistroDespesaDb : DbContext
    {
        public RegistroDespesaDb(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<DespesaModel> Despesas { get; set; }
    }
}
