using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Models
{
    public class ComunicacaoPerda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public decimal LocalizacaoLatitude { get; set; }
        public decimal LocalizacaoLongitude { get; set; }
        public string TipoLavoura { get; set; }
        public DateTime DataColheita { get; set; }
        public int EventoOcorrido { get; set; }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Cpf))
            {
                throw new Exception("CPF deve ser informado");
            }

            if (!Cpf.IsCpf())
            {
                throw new Exception("O CPF informado é inválido");
            }

            if (String.IsNullOrWhiteSpace(Nome))
            {
                throw new Exception("Nome deve ser informado");
            }

            if (String.IsNullOrWhiteSpace(Email))
            {
                throw new Exception("E-mail deve ser informado");
            }

            if (!new EmailAddressAttribute().IsValid(Email))
            {
                throw new Exception("O e-mail informado é inválido");
            }

            if (String.IsNullOrWhiteSpace(TipoLavoura))
            {
                throw new Exception("Tipo de lavoura deve ser informado");
            }

            if (DataColheita == DateTime.MinValue)
            {
                throw new Exception("Uma data de colheita deve ser informada");
            }

            if (EventoOcorrido < 1)
            {
                throw new Exception("Um evento ocorrido deve ser informado");
            }

            if (!LocalizacaoLongitude.IsValidLongitude())
            {
                throw new Exception("A longitude informada é inválida");
            }

            if (!LocalizacaoLatitude.IsValidLatitude())
            {
                throw new Exception("A latitude informada é inválida");
            }
        }
    }
}