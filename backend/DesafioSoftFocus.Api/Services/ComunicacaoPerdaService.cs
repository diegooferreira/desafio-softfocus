using DesafioSoftFocus.Api.Models;
using DesafioSoftFocus.Api.Models.Request;
using DesafioSoftFocus.Api.Models.Response;
using DesafioSoftFocus.Api.Repository.Interfaces;
using DesafioSoftFocus.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Services
{
    public class ComunicacaoPerdaService : IComunicacaoPerdaService
    {
        private readonly IComunicacaoPerdaRepository _repository;

        public ComunicacaoPerdaService(IComunicacaoPerdaRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ComunicacaoPerda> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<ComunicacaoPerdaGetAllResponse>> GetAll()
        {
            var result = await _repository.GetAll();

            return result.Select(x => new ComunicacaoPerdaGetAllResponse
            {
                Cpf = x.Cpf,
                DataColheita = x.DataColheita,
                Email = x.Email,
                EventoOcorrido = x.EventoOcorrido,
                Id = x.Id,
                Nome = x.Nome,
                TipoLavoura = x.TipoLavoura
            }).ToList();
        }

        public async Task<List<ComunicacaoPerdaGetByCpfResponse>> GetByCpf(string cpf)
        {
            var result = await _repository.GetByCpf(cpf);

            return result.Select(x => new ComunicacaoPerdaGetByCpfResponse
            {
                Cpf = x.Cpf,
                DataColheita = x.DataColheita,
                Email = x.Email,
                EventoOcorrido = x.EventoOcorrido,
                Id = x.Id,
                Nome = x.Nome,
                TipoLavoura = x.TipoLavoura
            }).ToList();
        }

        public async Task<List<ComunicacaoPerda>> GetComunicacaoPerdaExistente(GetComunicacaoPerdaExistenteRequest requestData)
        {
            return await _repository.GetComunicacaoPerdaExistente(requestData);
        }

        public async Task<int> Insert(PostComunicacaoPerdaRequest requestData)
        {
            var model = new ComunicacaoPerda();

            model.Cpf = requestData.Cpf;
            model.DataColheita = requestData.DataColheita;
            model.Email = requestData.Email;
            model.EventoOcorrido = requestData.EventoOcorrido;
            model.Nome = requestData.Nome;
            model.TipoLavoura = requestData.TipoLavoura;
            model.LocalizacaoLatitude = requestData.LocalizacaoLatitude;
            model.LocalizacaoLongitude = requestData.LocalizacaoLongitude;

            model.Validar();

            return await _repository.Insert(model);
        }

        public async Task Update(int id, PutComunicacaoPerdaRequest requestData)
        {
            var model = new ComunicacaoPerda();

            model.Cpf = requestData.Cpf;
            model.DataColheita = requestData.DataColheita;
            model.Email = requestData.Email;
            model.EventoOcorrido = requestData.EventoOcorrido;
            model.Nome = requestData.Nome;
            model.TipoLavoura = requestData.TipoLavoura;
            model.LocalizacaoLatitude = requestData.LocalizacaoLatitude;
            model.LocalizacaoLongitude = requestData.LocalizacaoLongitude;

            model.Validar();

            await _repository.Update(id, model);
        }
    }
}
