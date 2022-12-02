using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Application.Interfaces;
using Pedidos.Application.Services;
using Pedidos.Domain.CommandHandlers;
using Pedidos.Domain.Commands;
using Pedidos.Domain.EventHandlers;
using Pedidos.Domain.Events;
using Pedidos.Domain.Interfaces.Repositories;
using PedidosEBD.Domain.Core.Bus;
using PedidosEBD.Infra.Bus;
using PedidosEBD.Infra.Data;
using PedidosEBD.Infra.Data.Repository;

namespace PedidosEBD.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Pedidos - Domain CommandHandlers
            services.AddTransient<IRequestHandler<CreateCargoCommand, bool>, CargoCommandHandler>();

            //Pedidos - Events
            services.AddTransient<IEventHandler<CargoCreatedEvent>, CargoEventHandler>();

            //Services
            services.AddScoped<ICargoService, CargoService>();

            // Data
            services.AddScoped<PedidosEBDContext>();
            services.AddScoped<ICargoRepository, CargoRepository>();
        }
    }
}
