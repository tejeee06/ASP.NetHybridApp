using MongoDB.Driver;
using MongoDB.Bson.Serialization; // <-- NUEVO USING MUY IMPORTANTE
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisitesMediques.Domain.Entities;
using VisitesMediques.Domain.Interfaces;

namespace VisitesMediques.Infrastructure.MongoDb.Repositories
{
    public class MongoDbVisitaMedicaRepository : IVisitaMedicaRepository
    {
        private readonly IMongoCollection<VisitaMedica> _collection;

        public MongoDbVisitaMedicaRepository(IMongoClient client)
        {
            // EL TRUCO DE CLEAN ARCHITECTURE: 
            // Le decimos a MongoDB que "IdVisita" es su clave principal "_id"
            if (!BsonClassMap.IsClassMapRegistered(typeof(VisitaMedica)))
            {
                BsonClassMap.RegisterClassMap<VisitaMedica>(cm =>
                {
                    cm.AutoMap(); // Mapea nombre, fecha, etc. de forma automática
                    cm.MapIdProperty(v => v.IdVisita); // Convierte IdVisita en el _id de Mongo
                    cm.SetIgnoreExtraElements(true); // Si hay campos raros, los ignora para no petar
                });
            }

            var database = client.GetDatabase("VisitasMedicasDB");
            _collection = database.GetCollection<VisitaMedica>("VisitesMediques");
        }

        public async Task<IEnumerable<VisitaMedica>> GetAllAsync() => 
            await _collection.Find(_ => true).ToListAsync();

        public async Task<VisitaMedica> GetByIdAsync(long id) => 
            await _collection.Find(v => v.IdVisita == id).FirstOrDefaultAsync();

        public async Task AddAsync(VisitaMedica visita)
        {
            // Si el ID es 0 (nuevo), le generamos uno numérico único
            if (visita.IdVisita == 0) 
            {
                visita.IdVisita = DateTime.Now.Ticks; 
            }
            await _collection.InsertOneAsync(visita);
        }

        public async Task UpdateAsync(VisitaMedica visita) => 
            await _collection.ReplaceOneAsync(v => v.IdVisita == visita.IdVisita, visita);

        public async Task DeleteAsync(long id) => 
            await _collection.DeleteOneAsync(v => v.IdVisita == id);
    }
}