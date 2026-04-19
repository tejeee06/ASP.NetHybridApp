using Microsoft.EntityFrameworkCore;
using VisitesMediques.Domain.Entities;

namespace VisitesMediques.Infrastructure.MySQL.Context
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }

        public DbSet<VisitaMedica> VisitasMedicas { get; set; }
    }
}