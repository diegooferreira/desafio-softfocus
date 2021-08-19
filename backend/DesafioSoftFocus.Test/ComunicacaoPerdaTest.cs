using DesafioSoftFocus.Api.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DesafioSoftFocus.Test
{
    public class ComunicacaoPerdaTest
    {
        [Fact]
        public void DeveSerUmaComunicacaoPerdaValida()
        {
            var model = new ComunicacaoPerda();

            model.Cpf = "60418526001";
            model.DataColheita = DateTime.Now.Date;
            model.Email = "email@gmail.com";
            model.EventoOcorrido = 1;
            model.Nome = "NOME PRODUTOR";
            model.TipoLavoura = "LAVOURA";
            model.LocalizacaoLatitude = 0;
            model.LocalizacaoLongitude = 0;

            model.Validar();

            Assert.Equal("OK", "OK");
        }

        [Fact]
        public void DeveSerUmaComunicacaoPerdaComCpfInvalido()
        {
            var model = new ComunicacaoPerda();

            model.Cpf = "99999999999";
            model.DataColheita = DateTime.Now.Date;
            model.Email = "diegooferreira@gmail.com";
            model.EventoOcorrido = 1;
            model.Nome = "NOME PRODUTOR";
            model.TipoLavoura = "LAVOURA";
            model.LocalizacaoLatitude = 0;
            model.LocalizacaoLongitude = 0;

            var ex = Assert.Throws<Exception>(() => model.Validar());

            Assert.Equal("O CPF informado é inválido", ex.Message);
        }

        [Fact]
        public void DeveSerUmaComunicacaoPerdaComEmailInvalido()
        {
            var model = new ComunicacaoPerda();

            model.Cpf = "99999999999";
            model.DataColheita = DateTime.Now.Date;
            model.Email = "------";
            model.EventoOcorrido = 1;
            model.Nome = "NOME PRODUTOR";
            model.TipoLavoura = "LAVOURA";
            model.LocalizacaoLatitude = 0;
            model.LocalizacaoLongitude = 0;

            var ex = Assert.Throws<Exception>(() => model.Validar());

            Assert.Equal("O e-mail informado é inválido", ex.Message);
        }

        [Fact]
        public void DeveSerUmaComunicacaoPerdaComLongitudeInvalida()
        {
            var model = new ComunicacaoPerda();

            model.Cpf = "60418526001";
            model.DataColheita = DateTime.Now.Date;
            model.Email = "diegooferreira@gmail.com";
            model.EventoOcorrido = 1;
            model.Nome = "NOME PRODUTOR";
            model.TipoLavoura = "LAVOURA";
            model.LocalizacaoLatitude = 0;
            model.LocalizacaoLongitude = 500;

            var ex = Assert.Throws<Exception>(() => model.Validar());

            Assert.Equal("A longitude informada é inválida", ex.Message);
        }

        [Fact]
        public void DeveSerUmaComunicacaoPerdaComLatitudeInvalida()
        {
            var model = new ComunicacaoPerda();

            model.Cpf = "60418526001";
            model.DataColheita = DateTime.Now.Date;
            model.Email = "diegooferreira@gmail.com";
            model.EventoOcorrido = 1;
            model.Nome = "NOME PRODUTOR";
            model.TipoLavoura = "LAVOURA";
            model.LocalizacaoLatitude = 500;
            model.LocalizacaoLongitude = 0;

            var ex = Assert.Throws<Exception>(() => model.Validar());

            Assert.Equal("A latitude informada é inválida", ex.Message);
        }
    }
}
