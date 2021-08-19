using Dapper;
using System.Threading.Tasks;
using DesafioSoftFocus.Api.Repository.Context;
using DesafioSoftFocus.Api.Models;
using DesafioSoftFocus.Api.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DesafioSoftFocus.Api.Models.Request;
using DesafioSoftFocus.Api.Models.DbQuery;

namespace DesafioSoftFocus.Api.Repository
{
    public class ComunicacaoPerdaRepository : IComunicacaoPerdaRepository
    {
        private readonly DbContext _dbContext;

        public ComunicacaoPerdaRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ComunicacaoPerdaGetAllDbQuery>> GetAll()
        {
            using (var conn = await _dbContext.getConnectionAsync())
            {
                var result = await conn.QueryAsync<ComunicacaoPerdaGetAllDbQuery>(@"select cp.id, cp.nome, cp.email, cp.cpf, cp.TIPO_LAVOURA as TIPOLAVOURA,
                                                                       cp.DATA_COLHEITA as DATACOLHEITA, E.DESCRICAO as EVENTOOCORRIDO
                                                                       from COMUNICACAO_PERDA CP, EVENTO E WHERE E.ID = CP.ID_EVENTO");

                return result.ToList();
            }
        }

        public async Task<ComunicacaoPerda> Get(int id)
        {
            using (var conn = await _dbContext.getConnectionAsync())
            {
                var result = await conn.QueryFirstAsync<ComunicacaoPerda>(@"select id, nome, email, cpf, Localizacao_Latitude as LocalizacaoLatitude, 
                                                                       LOCALIZACAO_LONGITUDE as LOCALIZACAOLONGITUDE, TIPO_LAVOURA as TIPOLAVOURA,
                                                                       DATA_COLHEITA as DATACOLHEITA, ID_EVENTO as EVENTOOCORRIDO 
                                                                        from COMUNICACAO_PERDA where Id = @Id", new { @Id = id });

                return result;
            }
        }

        public async Task<List<ComunicacaoPerdaGetByCpfDbQuery>> GetByCpf(string cpf)
        {
            using (var conn = await _dbContext.getConnectionAsync())
            {
                var result = await conn.QueryAsync<ComunicacaoPerdaGetByCpfDbQuery>(@"select cp.id, cp.nome, cp.email, cp.cpf, cp.TIPO_LAVOURA as TIPOLAVOURA,
                                                                       cp.DATA_COLHEITA as DATACOLHEITA, E.DESCRICAO as EVENTOOCORRIDO
                                                                       from COMUNICACAO_PERDA CP, EVENTO E WHERE E.ID = CP.ID_EVENTO and cp.Cpf = @Cpf", new { @Cpf = cpf });

                return result.ToList();
            }
        }

        public async Task<List<ComunicacaoPerda>> GetComunicacaoPerdaExistente(GetComunicacaoPerdaExistenteRequest requestData)
        {
            using (var conn = await _dbContext.getConnectionAsync())
            {
                var result = await conn.QueryAsync<ComunicacaoPerda>(@"SELECT id, nome, email, cpf, Localizacao_Latitude as LocalizacaoLatitude, 
                                                                       LOCALIZACAO_LONGITUDE as LOCALIZACAOLONGITUDE, TIPO_LAVOURA as TIPOLAVOURA,
                                                                       DATA_COLHEITA as DATACOLHEITA, ID_EVENTO as EVENTOOCORRIDO, 
                                                                       (6371 * acos(cos(radians(@LOCALIZACAO_LATITUDE)) * cos(radians(LOCALIZACAO_LATITUDE)) * 
                                                                       cos(radians(@LOCALIZACAO_LONGITUDE) - radians(LOCALIZACAO_LONGITUDE)) + sin(radians(@LOCALIZACAO_LATITUDE)) * 
                                                                       sin(radians(LOCALIZACAO_LATITUDE)) )) AS distance 
                                                                       FROM COMUNICACAO_PERDA where ID <> @ID and DATE(Data_Colheita) = DATE(@DATA_COLHEITA) and ID_EVENTO <> @EVENTO_OCORRIDO 
                                                                       HAVING distance <= 10",
                                                                     new
                                                                     {
                                                                         DATA_COLHEITA = requestData.Data,
                                                                         @LOCALIZACAO_LONGITUDE = requestData.LocalizacaoLongitude,
                                                                         @LOCALIZACAO_LATITUDE = requestData.LocalizacaoLatitude,
                                                                         @EVENTO_OCORRIDO = requestData.Evento,
                                                                         @ID = requestData.Id
                                                                     });

                return result.ToList();
            }
        }

        public async Task<int> Insert(ComunicacaoPerda model)
        {
            using (var conn = await _dbContext.getConnectionAsync())
            {
                var insertedId = await conn.QueryFirstAsync<int>(@"INSERT INTO comunicacao_perda (NOME,EMAIL,CPF,LOCALIZACAO_LATITUDE,LOCALIZACAO_LONGITUDE,
                                                                            TIPO_LAVOURA,DATA_COLHEITA, ID_EVENTO) 
                                                                            VALUES(@NOME,@EMAIL,@CPF,@LOCALIZACAO_LATITUDE,@LOCALIZACAO_LONGITUDE,@TIPO_LAVOURA,
                                                                            DATE(@DATA_COLHEITA),@ID_EVENTO); select LAST_INSERT_ID();",
                                                                             new
                                                                             {
                                                                                 @NOME = model.Nome,
                                                                                 @EMAIL = model.Email,
                                                                                 @CPF = model.Cpf,
                                                                                 @LOCALIZACAO_LATITUDE = model.LocalizacaoLatitude,
                                                                                 @LOCALIZACAO_LONGITUDE = model.LocalizacaoLongitude,
                                                                                 @TIPO_LAVOURA = model.TipoLavoura,
                                                                                 @DATA_COLHEITA = model.DataColheita,
                                                                                 @ID_EVENTO = model.EventoOcorrido
                                                                             });

                return insertedId;
            }
        }

        public async Task Update(int id, ComunicacaoPerda requestData)
        {
            using (var conn = await _dbContext.getConnectionAsync())
            {
                await conn.ExecuteAsync(@"UPDATE comunicacao_perda SET NOME = @NOME,EMAIL = @EMAIL,CPF = @CPF,
                                                                            LOCALIZACAO_LATITUDE = @LOCALIZACAO_LATITUDE,LOCALIZACAO_LONGITUDE = @LOCALIZACAO_LONGITUDE,
                                                                            TIPO_LAVOURA = @TIPO_LAVOURA,DATA_COLHEITA = @DATA_COLHEITA, ID_EVENTO = @EVENTO_OCORRIDO 
                                                                            Where Id = @ID",
                                                                             new
                                                                             {
                                                                                 @NOME = requestData.Nome,
                                                                                 @EMAIL = requestData.Email,
                                                                                 @CPF = requestData.Cpf,
                                                                                 @LOCALIZACAO_LATITUDE = requestData.LocalizacaoLatitude,
                                                                                 @LOCALIZACAO_LONGITUDE = requestData.LocalizacaoLongitude,
                                                                                 @TIPO_LAVOURA = requestData.TipoLavoura,
                                                                                 @DATA_COLHEITA = requestData.DataColheita,
                                                                                 @EVENTO_OCORRIDO = requestData.EventoOcorrido,
                                                                                 @ID = id
                                                                             });
            }
        }

        public async Task Delete(int id)
        {
            using (var conn = await _dbContext.getConnectionAsync())
            {
                await conn.ExecuteAsync(@"delete from COMUNICACAO_PERDA where Id = @Id", new { @Id = id });
            }
        }
    }
}
