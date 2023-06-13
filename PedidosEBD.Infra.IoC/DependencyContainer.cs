using Microsoft.Extensions.DependencyInjection;
using Pedidos.Application.Interfaces;
using Pedidos.Application.Services;
using Pedidos.Domain.Interfaces.Repositories;
using PedidosEBD.Infra.Data;
using PedidosEBD.Infra.Data.Repository;

namespace PedidosEBD.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<ICongregacaoService, CongregacaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            // Data
            services.AddScoped<PedidosEBDContext>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<ICongregacaoRepository, CongregacaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
