using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Interfaces.Repositories;
using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidosEBD.Infra.Data.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly PedidosEBDContext _context;

        public CargoRepository(PedidosEBDContext context)
        {
            _context = context;
        }

        public void Add(Cargo cargo)
        {
            _context.Add(cargo);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Cargo>> GetAll()
        {
            return await _context.Cargos.ToListAsync();
        }

        public async Task<Cargo> GetByID(int id)
        {
            return await _context.Cargos.FindAsync(id);
        }

        public bool Remove(int id)
        {
            var cargo = _context.Cargos.Find(id);
            if (cargo == null)
                return false;
            else
            {
                _context.Remove(cargo);
                _context.SaveChanges();
                return true;
            }
        }

        public void Update(Cargo cargo)
        {
            _context.Update(cargo);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

        }
    }
}
