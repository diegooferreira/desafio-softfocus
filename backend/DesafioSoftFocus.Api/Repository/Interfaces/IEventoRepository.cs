using DesafioSoftFocus.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Repository.Interfaces
{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAll();
    }
}
