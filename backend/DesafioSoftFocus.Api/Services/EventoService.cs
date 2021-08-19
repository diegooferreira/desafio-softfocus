using DesafioSoftFocus.Api.Models;
using DesafioSoftFocus.Api.Repository.Interfaces;
using DesafioSoftFocus.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _repository;

        public EventoService(IEventoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Evento>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
