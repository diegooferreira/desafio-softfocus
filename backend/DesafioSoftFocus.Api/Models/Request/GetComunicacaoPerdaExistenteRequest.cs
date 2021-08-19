using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Models.Request
{
    public class GetComunicacaoPerdaExistenteRequest
    {
        public int Id { get; set; }
        public int Evento { get; set; }
        public decimal LocalizacaoLatitude { get; set; }
        public decimal LocalizacaoLongitude { get; set; }
        public DateTime Data { get; set; }
    }
}
