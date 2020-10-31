using agenda_medica_dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace agenda_medica_infraestrutura
{
    public class ContextoDb : DbContext
    {
        public ContextoDb(DbContextOptions options) : base(options) { }

        public DbSet<Agenda> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
