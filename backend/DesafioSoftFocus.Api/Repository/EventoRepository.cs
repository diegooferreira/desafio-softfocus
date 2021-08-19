using Dapper;
using System.Threading.Tasks;
using DesafioSoftFocus.Api.Repository.Context;
using DesafioSoftFocus.Api.Models;
using DesafioSoftFocus.Api.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DesafioSoftFocus.Api.Models.Request;

namespace DesafioSoftFocus.Api.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly DbContext _dbContext;

        public EventoRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Evento>> GetAll()
        {
            using (var conn = await _dbContext.getConnectionAsync())
            {
                var result = await conn.QueryAsync<Evento>(@"select id, descricao from EVENTO");

                return result.ToList();
            }
        }
    }
}
