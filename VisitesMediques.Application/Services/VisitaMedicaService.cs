using System.Collections.Generic;
using System.Threading.Tasks;
using VisitesMediques.Domain.Entities;
using VisitesMediques.Domain.Interfaces;

namespace VisitesMediques.Application.Services
{
    public class VisitaMedicaService : IVisitaMedicaService
    {
        private readonly IVisitaMedicaRepository _repository;

        public VisitaMedicaService(IVisitaMedicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VisitaMedica>> ObtenerTodasAsync() => await _repository.GetAllAsync();
        public async Task<VisitaMedica> ObtenerPorIdAsync(long id) => await _repository.GetByIdAsync(id);
        public async Task CrearAsync(VisitaMedica visita) => await _repository.AddAsync(visita);
        public async Task ActualizarAsync(VisitaMedica visita) => await _repository.UpdateAsync(visita);
        public async Task EliminarAsync(long id) => await _repository.DeleteAsync(id);
    }
}