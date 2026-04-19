using System.Collections.Generic;
using System.Threading.Tasks;
using VisitesMediques.Domain.Entities;

namespace VisitesMediques.Application.Services
{
    public interface IVisitaMedicaService
    {
        Task<IEnumerable<VisitaMedica>> ObtenerTodasAsync();
        Task<VisitaMedica> ObtenerPorIdAsync(long id);
        Task CrearAsync(VisitaMedica visita);
        Task ActualizarAsync(VisitaMedica visita);
        Task EliminarAsync(long id);
    }
}