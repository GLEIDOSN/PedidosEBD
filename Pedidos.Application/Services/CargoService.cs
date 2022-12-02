using Pedidos.Application.Interfaces;
using Pedidos.Domain.Commands;
using Pedidos.Domain.Interfaces.Repositories;
using Pedidos.Domain.Models;
using PedidosEBD.Domain.Core.Bus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository cargoRepository;
        private readonly IEventBus _bus;

        public CargoService(ICargoRepository cargoRepository, IEventBus bus)
        {
            this.cargoRepository = cargoRepository;
            _bus = bus;
        }

        public void Add(Cargo cargo)
        {
            var createCargoCommand = new CreateCargoCommand(
                cargo.Id,
                cargo.Descricao);

            _bus.SendCommand(createCargoCommand);
        }

        public async Task<Cargo> GetByID(int id)
        {
            return await cargoRepository.GetByID(id);
        }

        public async Task<IEnumerable<Cargo>> GetCargos()
        {
            return await cargoRepository.GetAll();
        }

        public bool Remove(int id)
        {
            return cargoRepository.Remove(id);
        }

        public void Update(Cargo cargo)
        {
            cargoRepository.Update(cargo);
        }
    }
}
