using System.Collections.Generic;
using System.Threading.Tasks;
using VisitesMediques.Domain.Entities;

namespace VisitesMediques.Domain.Interfaces
{
    public interface IVisitaMedicaRepository
    {
        Task<IEnumerable<VisitaMedica>> GetAllAsync();
        Task<VisitaMedica> GetByIdAsync(long id);
        Task AddAsync(VisitaMedica visita);
        Task UpdateAsync(VisitaMedica visita);
        Task DeleteAsync(long id);
    }
}