using Microsoft.EntityFrameworkCore;
using VisitesMediques.Domain.Entities;

namespace VisitesMediques.Infrastructure.SQLServer.Context
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }

        public DbSet<VisitaMedica> VisitasMedicas { get; set; }
    }
}