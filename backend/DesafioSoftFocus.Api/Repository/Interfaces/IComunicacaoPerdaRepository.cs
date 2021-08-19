using DesafioSoftFocus.Api.Models;
using DesafioSoftFocus.Api.Models.DbQuery;
using DesafioSoftFocus.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Repository.Interfaces
{
    public interface IComunicacaoPerdaRepository
    {
        Task<List<ComunicacaoPerdaGetAllDbQuery>> GetAll();
        Task<ComunicacaoPerda> Get(int id);
        Task<List<ComunicacaoPerdaGetByCpfDbQuery>> GetByCpf(string cpf);
        Task<List<ComunicacaoPerda>> GetComunicacaoPerdaExistente(GetComunicacaoPerdaExistenteRequest requestData);
        Task<int> Insert(ComunicacaoPerda requestData);
        Task Update(int id, ComunicacaoPerda requestData);
        Task Delete(int id);
    }
}
