using Pedidos.Application.Interfaces;
using Pedidos.Domain.Interfaces.Repositories;
using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
        {
            this.cargoRepository = cargoRepository;
        }

        public void Add(Cargo cargo)
        {
            cargoRepository.Add(cargo);
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
