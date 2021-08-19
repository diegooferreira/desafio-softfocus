using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Models.Request
{
    public class PostComunicacaoPerdaRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public decimal LocalizacaoLatitude { get; set; }
        public decimal LocalizacaoLongitude { get; set; }
        public string TipoLavoura { get; set; }
        public DateTime DataColheita { get; set; }
        public int EventoOcorrido { get; set; }
    }
}
