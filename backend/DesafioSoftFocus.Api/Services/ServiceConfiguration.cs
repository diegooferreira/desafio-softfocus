using DesafioSoftFocus.Api.Repository;
using DesafioSoftFocus.Api.Repository.Context;
using DesafioSoftFocus.Api.Repository.Interfaces;
using DesafioSoftFocus.Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioSoftFocus.Api.Services
{
    public static class ServiceConfiguration
    {
        public static void ConfigureService(IServiceCollection services)
        {
            //services.AddScoped<IConfiguration>();
            services.AddScoped<DbContext>();
            services.AddScoped<IComunicacaoPerdaService, ComunicacaoPerdaService>();
            services.AddScoped<IComunicacaoPerdaRepository, ComunicacaoPerdaRepository>();

            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEventoRepository, EventoRepository>();
        }
    }
}