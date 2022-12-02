using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Interfaces.Repositories;
using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidosEBD.Infra.Data.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly PedidosEBDContext context;

        public CargoRepository(PedidosEBDContext context)
        {
            this.context = context;
        }

        public void Add(Cargo cargo)
        {
            context.Add(cargo);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Cargo>> GetAll()
        {
            return await context.Cargos.ToListAsync();
        }

        public async Task<Cargo> GetByID(int id)
        {
            return await context.Cargos.FindAsync(id);
        }

        public bool Remove(int id)
        {
            var cargo = context.Cargos.Find(id);
            if (cargo == null)
                return false;
            else
            {
                context.Remove(cargo);
                context.SaveChanges();
                return true;
            }
        }

        public void Update(Cargo cargo)
        {
            context.Update(cargo);
            try
            {
                context.SaveChanges();
            }
            catch
            {
                throw;
            }

        }
    }
}
