using Microsoft.Extensions.DependencyInjection;
using PedidosEBD.Infra.Data;

namespace PedidosEBD.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<PedidosEBDContext>();
        }
    }
}
