using MediatR;
using Pedidos.Domain.Commands;
using Pedidos.Domain.Events;
using PedidosEBD.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Domain.CommandHandlers
{
    public class CargoCommandHandler : IRequestHandler<CreateCargoCommand, bool>
    {
        private readonly IEventBus _bus;

        public CargoCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateCargoCommand request, CancellationToken cancellationToken)
        {
            //Publica Evento para RabbitMQ
            _bus.Publish(new CargoCreatedEvent(request.Id, request.Descricao));
            return Task.FromResult(true);
        }
    }
}
