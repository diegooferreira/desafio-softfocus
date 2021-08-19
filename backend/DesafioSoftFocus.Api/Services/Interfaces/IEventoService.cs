using DesafioSoftFocus.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Services.Interfaces
{
    public interface IEventoService
    {
        Task<List<Evento>> GetAll();
    }
}
