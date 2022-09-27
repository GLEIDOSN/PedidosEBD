using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Domain.Interfaces.Repositories
{
    public interface ICargoRepository
    {
        public Task<IEnumerable<Cargo>> GetAll();
        public Task<Cargo> GetByID(int id);
        public void Add(Cargo cargo);
        public void Update(Cargo cargo);
        public bool Remove(int id);
    }
}
