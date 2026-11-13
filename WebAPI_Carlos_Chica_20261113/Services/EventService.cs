using WebAPI_Carlos_Chica_20261113.Entity;
using WebAPI_Carlos_Chica_20261113.Repository;

namespace WebAPI_Carlos_Chica_20261113.Services
{
    public class EventService
    {
        private readonly EventReposi _repository;
        public EventService(EventReposi repoevent)
        {
            _repository = repoevent;
        }

        public async Task<IEnumerable<Evento>> ObtenertodosEventos()
        {
            return await _repository.ObtenerTodasAsync();
        }
        public async Task<Evento> ObtenerPorIdAsync(int id)
        {
            var vuelo = await _repository.ObtenerPorIdAsync(id);
            if (vuelo == null)
            {
                throw new KeyNotFoundException($"El Evento con ID {id} no fue encontrado.");
            }
            return vuelo;
        }


        public async Task<int> CrearAsync(Evento evento)
        {
            return await _repository.CrearAsync(evento);
        }

        public async Task ActualizarAsync(Evento evento)
        {
            var existe = await _repository.ObtenerPorIdAsync(evento.Id);
            if (existe == null)
            {
                throw new KeyNotFoundException($"No se puede actualizar. El evento con ID {evento.Id} no existe.");
            }

            await _repository.ActualizarAsync(evento);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var existe = await _repository.ObtenerPorIdAsync(id);
            if (existe == null)
            {
                throw new KeyNotFoundException($"No se puede eliminar. El evento con ID {id} no existe.");
            }

            return await _repository.EliminarAsync(id);
        }
    }
}
