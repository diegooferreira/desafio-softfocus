using DesafioSoftFocus.Api.Models;
using DesafioSoftFocus.Api.Models.Request;
using DesafioSoftFocus.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Services.Interfaces
{
    public interface IComunicacaoPerdaService
    {
        Task<List<ComunicacaoPerdaGetAllResponse>> GetAll();
        Task<ComunicacaoPerda> Get(int id);
        Task<List<ComunicacaoPerdaGetByCpfResponse>> GetByCpf(string cpf);
        Task<List<ComunicacaoPerda>> GetComunicacaoPerdaExistente(GetComunicacaoPerdaExistenteRequest requestData);
        Task<int> Insert(PostComunicacaoPerdaRequest requestData);
        Task Update(int id, PutComunicacaoPerdaRequest requestData);
        Task Delete(int id);
    }
}
