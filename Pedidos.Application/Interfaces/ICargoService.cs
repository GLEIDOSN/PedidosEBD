using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Application.Interfaces
{
    public interface ICargoService
    {
        public Task<IEnumerable<Cargo>> GetCargos();
        public Task<Cargo> GetByID(int id);
        void Add(Cargo cargo);
        void Update(Cargo cargo);
        bool Remove(int id);
    }
}
