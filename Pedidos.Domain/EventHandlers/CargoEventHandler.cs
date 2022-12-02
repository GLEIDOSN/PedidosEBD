using Pedidos.Domain.Events;
using Pedidos.Domain.Interfaces.Repositories;
using Pedidos.Domain.Models;
using PedidosEBD.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain.EventHandlers
{
    public class CargoEventHandler : IEventHandler<CargoCreatedEvent>
    {
        private readonly ICargoRepository cargoRepository;

        public CargoEventHandler(ICargoRepository cargoRepository)
        {
            this.cargoRepository = cargoRepository; 
        }

        public Task Handle(CargoCreatedEvent @event)
        {
            cargoRepository.Add(new Cargo()
            {
                Descricao = @event.Descricao,
            });

            return Task.CompletedTask;
        }
    }
}
