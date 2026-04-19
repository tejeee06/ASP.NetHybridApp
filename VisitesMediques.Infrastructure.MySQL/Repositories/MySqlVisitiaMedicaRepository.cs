using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisitesMediques.Domain.Entities;
using VisitesMediques.Domain.Interfaces;
using VisitesMediques.Infrastructure.MySQL.Context;

namespace VisitesMediques.Infrastructure.MySQL.Repositories
{
    public class MySqlVisitaMedicaRepository : IVisitaMedicaRepository
    {
        private readonly MySqlDbContext _context;

        public MySqlVisitaMedicaRepository(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VisitaMedica>> GetAllAsync() => await _context.VisitasMedicas.ToListAsync();
        
        public async Task<VisitaMedica> GetByIdAsync(long id) => await _context.VisitasMedicas.FindAsync(id);

        public async Task AddAsync(VisitaMedica visita)
        {
            await _context.VisitasMedicas.AddAsync(visita);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VisitaMedica visita)
        {
            _context.VisitasMedicas.Update(visita);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var visita = await _context.VisitasMedicas.FindAsync(id);
            if (visita != null)
            {
                _context.VisitasMedicas.Remove(visita);
                await _context.SaveChangesAsync();
            }
        }
    }
}