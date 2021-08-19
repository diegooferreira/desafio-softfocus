using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Models.Response
{
    public class ComunicacaoPerdaGetAllResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string TipoLavoura { get; set; }
        public DateTime DataColheita { get; set; }
        public string EventoOcorrido { get; set; }
    }
}